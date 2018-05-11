using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class CharacterMovement3D: MonoBehaviour {

    InteractableObjectControl iOC;

    Rigidbody characterRigidBody;
    Collider playerCol;

    Rect colliderBounds; //boundaries of where we castin thr raycast frum

    // the actual 3D model of the character
    public GameObject playerModel; 

    public bool inputAllowed = true; 


    // THis is the number of raycasts that will be shot down from the character to have more accurate ground detection. 
    public int downRaycasts = 6;
    public int upRaycasts = 6;
    public int leftRaycasts = 4;
    public int rightRaycasts = 4;

    public KeyCode MoveRightKey = KeyCode.RightArrow;
    public KeyCode MoveLeftKey = KeyCode.LeftArrow;
    public KeyCode InteractKey = KeyCode.LeftControl;
    public KeyCode JumpKey = KeyCode.UpArrow;

    // bools that are checking the states of the character to determine if they can move or not
    // these are public because other scripts access them, but are hidden in the inspector
    [HideInInspector]
    bool canMoveUp;
    [HideInInspector]
    bool hasJumped;
    [HideInInspector]
    bool falling;
    [HideInInspector]
    public bool canMoveRight = true;
    [HideInInspector]
    public bool canMoveLeft = true;
    [HideInInspector]
    public bool canJump; //secret littol raycast that lets u jump a little bit before u actually hit ground ;u;
    [HideInInspector]
    public bool onGround;
    [HideInInspector]
    public bool isPulling = false;
    [HideInInspector]
    public bool facingRight;
    [HideInInspector]
    public Vector3 velocity;
    [HideInInspector]
    public Vector3 direction;
    [HideInInspector]
    public bool AmJumping = false;

    public Animator playerAnimator;

    //[Header("THESE ARE ALL OF THE ADJUSTABLE PLAYER PHYSICS VALUES")
    //[Header("TWEAK THEM TO YOUR LIKING")]
    public float moveSpeed = 2.5f; //minimum velocity 
    public float maxSpeed = 6; //max velocity
    public float jumpForce = 13;
    //[Tooltip("CONTROLS GRAVITY AFFECTING PLAYER")]
    public float gravity = 0.4f;
    public float maxFallSpeed = 12f;

    // All rays use this mask
    public LayerMask rayMask; //she tuch foreground layer ok

    // Variables related to the controller itself, and where between 0 and 1 the x value of the joystick is. 
    private InputDevice controller;
    private float leftStickXVal;
    


    // NOTE: groundCheckHit is just the name for all of the raycast hit information, not just the ground. 

	    // Use this for initialization
	    void Start ()
        {
	        characterRigidBody = gameObject.GetComponent<Rigidbody>();
	        playerCol = gameObject.GetComponent<CapsuleCollider>(); 
	        playerAnimator = gameObject.GetComponent<Animator>();
	        iOC = gameObject.GetComponent<InteractableObjectControl>(); 
		
	    }
	
	    // Added FixedUpdate because normal update was causing the model to wobble. 
	    // This equalizes the framerate and thus, smooths out the motion.
	    void FixedUpdate () 
	    {
		    // this initializes the controller that is plugged in 
		    controller = InputManager.ActiveDevice;
		    leftStickXVal = controller.LeftStickX;

		    // constantly keeps the parent in line with the girl herself. 
		    // We need something that keeps the parent properly overlaid with the avatar herself. 

		    // only if we are not in a cutscene, then we will allow them to move. 
		    if (inputAllowed)
		    {
			    // callin all functions!!!!!
			    GroundCheck();
	            //GroundNormalizer();
			
			    UpCheck(); 
			    Gravity ();
			    Jump ();
			    MovementControl(); 
			    // We moved these functions here for purposes in order to make her slow down properly while she's moving a crate, 
			    // and so that crates move properly and are properly impacted by the environment. 
			    // This is because left and right checks are used in Pull.
			    // We put Movement above because it's information and Pull's information conflicted.
			    LeftCheck();
			    RightCheck();
			    iOC.Pull(); 

			    // caps the max speed left and right
			    if (velocity.x > maxSpeed) {
				    velocity = new Vector3 (maxSpeed, velocity.y);
			    }
			    if (velocity.x < -maxSpeed) {
				    velocity = new Vector3 (-maxSpeed, velocity.y);
			    }
				

			    characterRigidBody.MovePosition(transform.position + (velocity *  0.015f));
		    }

	    }

	    // This is where all of the movement inputs go, and are how you actual  
	    void MovementControl()
	    {
		    // looks for movement to the right
		    if (Input.GetKey (MoveRightKey) || leftStickXVal > 0.3f || Input.GetKey (KeyCode.D)) 
		    {
			     //if there's nothing in our way
			    if (onGround) 
			    {
				    playerAnimator.SetBool ("running", true);
			    }
			    if (canMoveRight)
			    {
				    // and if we're not going at maxspeed
				    if (velocity.x < maxSpeed) 
				    {
					    // increase our x velocity by movespeed and set right facing to true
					    velocity += new Vector3 (moveSpeed, 0f);
				    }

				    if (playerModel.transform.rotation.y != 90 && !isPulling) 
				    {
					    playerModel.transform.rotation = Quaternion.Euler(0,90,0);
					    facingRight = true; 
					
				    }
			    }

		    } 
		    // looks for movement to the left
		    else if (Input.GetKey (MoveLeftKey) || leftStickXVal < -0.3f || Input.GetKey (KeyCode.A)) 
		    {
			    // if there's nothing in our way
			    if (onGround) 
			    {
				    playerAnimator.SetBool ("running", true);
			    }
			    if (canMoveLeft) 
			    {
				    // and if we're not going at maxspeed
				    if (velocity.x > -maxSpeed)
				    {
					    // increase our x velocity by movespeed and set right facing to true
					    velocity -= new Vector3 (moveSpeed, 0f);

				    }

				    if (playerModel.transform.rotation.y != -90 && !isPulling) // ADD: Not pulling 
				    {
				    //she flip, her mesh flipppin
					    playerModel.transform.rotation = Quaternion.Euler(0,-90,0);
					    facingRight = false; 
				    }

			    }
		    }

		    else 
		    {
		        // if we're not moving laterally at all, set our horizontal velocty to 0
		        playerAnimator.SetBool("running", false);
		        playerAnimator.SetBool("pulling",false);
		        velocity = new Vector3 (0f, velocity.y);
		    }

		    // if we CANNOT move right (there's something in our way)
		    if (canMoveRight == false) 
		    {
			    // and we're not moving left already
			    if (velocity.x > 0) 
			    {
				    // set our horizontal velocity to 0
				    velocity = new Vector3 (0f, velocity.y);
			    }
		    }

		    // if we CANNOT move left (there's something in our way)
		    if (canMoveLeft == false) 
		    {
			    // and we're not moving left already
			    if (velocity.x < 0) 
			    {
				    // set our horizontal velocity to 0
				    velocity = new Vector3 (0f, velocity.y);
			    }
		    }
		
	    }


	    // function to check whether or not we're hitting the ground
	    void GroundCheck ()
	    {
		    // make a rectangle equal to the size of our box collider
		    colliderBounds = new Rect (
			    playerCol.bounds.min.x,
			    playerCol.bounds.min.y,
			    playerCol.bounds.size.x,
			    playerCol.bounds.size.y
		    );

		    // because we're gonna be making multiple equidistant raycasts, we need to figure out the distance between them
		    // this divides the total length we need to make raycatss across by the number of raycasts we need to make
		    // This represents the distance between each raycast on the player's body itself.
		    float raySegmentDistance = (playerCol.bounds.size.x / downRaycasts);

		    // Allows for the creation of multiple raycasts
		    for (int i = 0; i <= downRaycasts; i++)
            {
		        // with this if we skip the first and last lines of raycasts because they're at the edges of the box collider and sometimes do weird stuff like hitting walls
			    if (i > 0 && i < downRaycasts)
                { 
			        // define the origin of the raycast as the xmin + the segment distance (what we calculated earlier) * i.
			        // So, basically, makes a raycast that far apart from the last
				    Vector3 raycastOrigin = new Vector3 ((colliderBounds.xMin + (raySegmentDistance * i)), colliderBounds.yMin +0.1f,transform.position.z);
				    RaycastHit groundCheckHit;

				    bool raycastCheck = Physics.Raycast (raycastOrigin, Vector3.down, out groundCheckHit, .1f, rayMask);
				    Debug.DrawRay (raycastOrigin, Vector3.down * .1f, Color.red);
				    if (raycastCheck)
                    {
					    //Debug.Log ("I hit a " + groundCheckHit.collider.gameObject.tag);

					    //if we hit a platform, we can stop raycasting and set "onGround" to true
					    if (groundCheckHit.collider.gameObject.tag == "Platform")
                        {
						    onGround = true;
						    playerAnimator.SetBool("jumping", false);
                            AmJumping = false;
						    //playerAnimator.SetBool("falling", false);
						    break;
					    }
					    // if we hit nothing, we're not on the ground and it's false
				    }
                    else
                    {
					    onGround = false;
				    }
			    }
		    }

	    // DO THE SAME THING but with a slightly higher raycast length. This is for jumping: we want players to be able to jump slightly before they hit the 
	    // platform because it feels correct
	    // This runs in parallel to the one that checks the ground,and is longer for jump detetction only. 
		    for (int i = 0; i <= downRaycasts; i++) 
		    {
			    if (i > 0 && i < downRaycasts) 
			    { 
				    //We needed to add some distance to the yMin beacuse it was never colliding the with the plane of the capsule collider, 
				    // which made it seem like she was never on the ground! 
				    Vector3 raycastOrigin = new Vector3 ((colliderBounds.xMin + (raySegmentDistance * i)), colliderBounds.yMin+.01f,transform.position.z);
				    RaycastHit groundCheckHit;
				    bool raycastCheck = Physics.Raycast (raycastOrigin, Vector3.down, out groundCheckHit, .3f, rayMask);
				    Debug.DrawRay (raycastOrigin, Vector3.down * .3f, Color.blue);
				    if (raycastCheck) 
				    {
					    //Debug.Log ("I hit a " + groundCheckHit.collider.gameObject.tag);
					    if (groundCheckHit.collider.gameObject.tag == "Platform") 
					    {
						    canJump = true;
						    //playerAnimator.SetBool("groundhit", true);

						    break;
					    }
				    }

				    else
				    { 
					    canJump = false;

				    }
			    }
		    }

	    }


	    // This function standardizes where you will arrive when you hit the ground, because before the spot was always changing.
	    // Prevents our character from sinking into the ground by adding a constant distance to the raycast hit 
	    void GroundNormalizer ()
	    {
		
		    if (onGround)
            {
			    colliderBounds = new Rect (
			    playerCol.bounds.min.x,
			    playerCol.bounds.min.y,
			    playerCol.bounds.size.x,
			    playerCol.bounds.size.y
                );

			    // This gets you to the center of the player. The constant transform between the gameObject and the bottom of its collider 
			    float dis = Mathf.Abs ((colliderBounds.yMin - gameObject.transform.position.y));
			    //float dis = Mathf.Abs (playerCol.center.y);

			    float raySegmentDistance = (playerCol.bounds.size.x / downRaycasts);
			    for (int i = 0; i <= downRaycasts; i++)
                {
				    if (i > 0 && i < downRaycasts)
                    {
					    //We needed to add some distance to the yMin beacuse it was never colliding the with the plane of the capsule collider, which made it seem like she was never on the ground! (Thanks michel <3 )
					    Vector3 raycastOrigin = new Vector3 ((colliderBounds.xMin + (raySegmentDistance * i)), colliderBounds.yMin + 0.6f, transform.position.z);
					    RaycastHit stablizingCast;
					    bool raycastCheck = Physics.Raycast (raycastOrigin, Vector3.down, out stablizingCast, (dis), rayMask);
					    Debug.DrawRay (raycastOrigin, Vector3.down * (dis), Color.magenta);
					    if (raycastCheck)
                        {
						    // Adds to the point where the raycast hit, and adds the constant distance we calculated above. 
						    gameObject.transform.position = new Vector3 (gameObject.transform.position.x, (stablizingCast.point.y + dis));
						    onGround = true;
						    break;
					    }
				    }
			    }
		
		    }
	    }


	    // Create several raycasts as before, but checking to the left instead. 
	    void LeftCheck ()
	    {
		    colliderBounds = new Rect (
			    playerCol.bounds.min.x,
			    playerCol.bounds.min.y,
			    playerCol.bounds.size.x,
			    playerCol.bounds.size.y
		    );

		    float raySegmentDistance = (playerCol.bounds.size.y / leftRaycasts);

		    // Allows for the creation of multiple raycasts
		    for (int i = 0; i <= leftRaycasts; i++)
            {
		    // same as before, this if skips the first raycast because it'll be at the very bottom (ie: in the ground) and will make us unable to move left 
			    if (i > 0)
                {
				    Vector3 raycastOrigin = new Vector3 (colliderBounds.xMin, (colliderBounds.yMin + (raySegmentDistance * i)));
				    RaycastHit leftCheckHit;
				    bool raycastCheck = Physics.Raycast (raycastOrigin, Vector3.left, out leftCheckHit, .1f, rayMask);
				    Debug.DrawRay (raycastOrigin, Vector3.left * .1f, Color.green);
				    if (raycastCheck)
                    {
                        //Debug.Log ("I hit a " + leftCheckHit.collider.gameObject.tag);
					    if (leftCheckHit.collider.gameObject.tag == "Platform" || leftCheckHit.collider.gameObject.tag == "Box")
                        {
						    canMoveLeft = false;
						    break;
					    }
				    }
                    else
                    {
					    canMoveLeft = true;
				    }
			    }
		    }


	    }

	    // rightcheck is the same as leftcheck but for right
	    void RightCheck ()
	    {
		    colliderBounds = new Rect (
			    playerCol.bounds.min.x,
			    playerCol.bounds.min.y,
			    playerCol.bounds.size.x,
			    playerCol.bounds.size.y
		    );

		    float raySegmentDistance = (playerCol.bounds.size.y / rightRaycasts);

		    // Allows for the creation of multiple raycasts
		    for (int i = 0; i <= rightRaycasts; i++)
            {
		        // skipping first raycast again because it would be too low to the ground and collide with it
		        if (i > 0)
                {
			        Vector3 raycastOrigin = new Vector3 (colliderBounds.xMax, (colliderBounds.yMin + (raySegmentDistance * i)));
			        RaycastHit rightCheckHit;
			        bool raycastCheck = Physics.Raycast (raycastOrigin, Vector3.right, out rightCheckHit, .1f, rayMask);
			        Debug.DrawRay (raycastOrigin, Vector3.right * .1f, Color.blue);
			        if (raycastCheck) 
			        {
                            //Debug.Log("I hit a " + rightCheckHit.collider.gameObject.tag);
					        if (rightCheckHit.collider.gameObject.tag == "Platform" || rightCheckHit.collider.gameObject.tag == "Box") 
					        {
					            canMoveRight = false;
					            break;
					        }
			        }
                    else
			 	    {
				        canMoveRight = true;
				    }
			    }
		    }

	    }



	    // functionally the same as the downcheck but for up
	    void UpCheck ()
	    {
		    colliderBounds = new Rect (
			    playerCol.bounds.min.x,
			    playerCol.bounds.min.y,
			    playerCol.bounds.size.x,
			    playerCol.bounds.size.y
		    );

		    float raySegmentDistance = (playerCol.bounds.size.x / upRaycasts);

		    // Allows for the creation of multiple raycasts
		    for (int i = 0; i <= upRaycasts; i++) {
			    if (i > 0 && i < upRaycasts) { 
				    Vector3 raycastOrigin = new Vector3 ((colliderBounds.xMin + (raySegmentDistance * i)), colliderBounds.yMax);
				    RaycastHit groundCheckHit;
				    bool raycastCheck = Physics.Raycast (raycastOrigin, Vector3.up, out groundCheckHit, .5f, rayMask);
				    //bool raycastCheck = Physics.Raycast (raycastOrigin, Vector3.up, groundCheckHit, .5f, rayMask);
				    Debug.DrawRay (raycastOrigin, Vector3.up * .05f, Color.magenta);
				    if (raycastCheck) {
					    if (groundCheckHit.collider.gameObject.tag == "Platform" || groundCheckHit.collider.gameObject.tag == "Box") {
						    canMoveUp = false;
    //						playerAnimator.SetBool("jump", false);
						    break;
					    }
				    } else {
					    canMoveUp = true;
				    }
			    }
		    }

	    }


	    void Gravity ()
	    {
		    if (velocity.y < 0) {
    //			playerAnimator.SetBool("jump", false);
			    falling = true;

		    } else {
    //			playerAnimator.SetBool("falling", false);
			    falling = false;
		    }



        // prevents you from jumping if something is above you. This is detected from the previous raycast functions. 
        if (canMoveUp == false) {
			    if (velocity.y > 0) {
				    velocity = new Vector3 (velocity.x, 0f);
			    }
		    }

		    if (onGround) {
			    velocity = new Vector3 (velocity.x, 0f);
			    canJump = true;
			    return;
		    }

		    // If you are in the air, subtract your y velocity every frame by the gravity value. 
		    // This simulates real gravity.
		    if (!onGround) 
		    {
    //			playerAnimator.SetBool("groundhit", false);
			    velocity -= new Vector3 (0f, gravity);
			    //transform.parent.parent = null;
			    if (velocity.y < -maxFallSpeed) 
			    {
				    velocity = new Vector3 (velocity.x, -maxFallSpeed);
			    }

		    }

	
	    }

	    void Jump ()
	    {
	    //if you are on the ground and can jump, AND are not currently pulling anything. 
		    if (canJump && !Input.GetKey(InteractKey)) 
		    {
			    if (Input.GetKeyDown (JumpKey) || Input.GetKeyDown (KeyCode.Space) || controller.Action1.WasPressed) 
			    {

				    playerAnimator.SetBool("jumping", true);
                    AmJumping = true;
				    velocity = new Vector3 (velocity.x, 0f);
				    velocity += new Vector3 (velocity.x, jumpForce);


				 

			    }
		    } 
		    else
		    { 
    //			if (playerAnimator.GetCurrentAnimatorStateInfo(0).length > playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime)
    //			{
    //				playerAnimator.SetBool("jumping", false);
    //			}
		    }
	    }

}





