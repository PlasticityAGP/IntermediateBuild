using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullableObject : MonoBehaviour {


    BoxCollider thisBoxCollider;
    Rect colliderBounds;

    float numberOfRaycasts = 4f;
    float distanceBetweenRaycasts;

    public LayerMask rayMask;

    public bool canMoveLeft;
    public bool canMoveRight;
    private bool Disabled = false;
    // enum that stores what side of the box player is on for later use in animation states
    public enum sidePlayerIsOn {LEFT, RIGHT};
    public sidePlayerIsOn currentSide;

    public ParticleSystem pushPartsLeft;
    public ParticleSystem pushPartsRight;  

	// Use this for initialization
	void Start () {
		thisBoxCollider = gameObject.GetComponent<BoxCollider>(); 
		
	}
	
	// Update is called once per frame
	void Update () {
		DetectLeftObjects();
		DetectRightObjects(); 
	}

    public void DisablePulling()
    {
        Disabled = true;
    }

	// when you enter the trigger zone, then the object the player can pull is this. 
	void OnTriggerStay(Collider other){
		InteractableObjectControl player = other.gameObject.GetComponent<InteractableObjectControl> ();
		CharacterMovement3D cM = other.gameObject.GetComponent<CharacterMovement3D>();
        if (Disabled)
        {
            OnTriggerExit(other);
        }
		else if (player && player.currentPullObject == null) {
			player.currentPullObject = this;
		}
	}

	// as soon as you leave... then you will not hold it anymore. 
	void OnTriggerExit(Collider other){
		InteractableObjectControl player = other.gameObject.GetComponent<InteractableObjectControl> ();
		CharacterMovement3D cM = other.gameObject.GetComponent<CharacterMovement3D>();
		if (player && player.currentPullObject == this) {
			player.currentPullObject = null;
			// When you are no longer pulling an object, set it to null. 
			cM.isPulling = false;

			// if you exit the trigger zone, automatically set the animation state to false so that she doesn't get stuck in states. 
			// TODO: Check here for animation stuff in the future.
			cM.playerAnimator.SetBool("pulling",false);
			cM.playerAnimator.SetBool("pushing",false);


		}
	}

	void DetectLeftObjects()
	{

	// Checks the left side
		colliderBounds = new Rect (
			thisBoxCollider.bounds.min.x,
			thisBoxCollider.bounds.min.y,
			thisBoxCollider.bounds.size.x,
			thisBoxCollider.bounds.size.y
			);

		float raySegmentDistance = (thisBoxCollider.bounds.size.y / numberOfRaycasts);

		// Allows for the creation of multiple raycasts
		for (int i = 0; i <= numberOfRaycasts; i++) {
		// same as before, this if skips the first raycast because it'll be at the very bottom (ie: in the ground) and will make us unable to move left 
			if (i > 1) {
				Vector3 raycastOrigin = new Vector3 (colliderBounds.xMin, (colliderBounds.yMin + (raySegmentDistance * i)), transform.position.z);
				RaycastHit leftCheckHit;
				bool raycastCheck = Physics.Raycast (raycastOrigin, Vector3.left, out leftCheckHit, .1f, rayMask);
				Debug.DrawRay (raycastOrigin, Vector3.left * .1f, Color.green);
				if (raycastCheck) {

					// uses Raycasts to determine if the player is on the left side. 
					if(leftCheckHit.collider.gameObject.tag == "Player")
					{
						currentSide = sidePlayerIsOn.LEFT;
						canMoveLeft = true; 
					}

					if (leftCheckHit.collider.gameObject.tag == "Platform" || leftCheckHit.collider.gameObject.tag == "Box") {

						canMoveLeft = false;
						break;
					}



				} 

				else {
					canMoveLeft = true;
				}
			}
		}
	}

    void DetectRightObjects()
	{

	// Checks the left side
		colliderBounds = new Rect (
			thisBoxCollider.bounds.min.x,
			thisBoxCollider.bounds.min.y,
			thisBoxCollider.bounds.size.x,
			thisBoxCollider.bounds.size.y
			);

		float raySegmentDistance = (thisBoxCollider.bounds.size.y / numberOfRaycasts);

		// Allows for the creation of multiple raycasts
		for (int i = 0; i <= numberOfRaycasts; i++) {
		// same as before, this if skips the first raycast because it'll be at the very bottom (ie: in the ground) and will make us unable to move left 
			if (i > 1) {
				Vector3 raycastOrigin = new Vector3 (colliderBounds.xMax, (colliderBounds.yMin + (raySegmentDistance * i)),transform.position.z);
				RaycastHit rightCheckHit;
				bool raycastCheck = Physics.Raycast (raycastOrigin, Vector3.right, out rightCheckHit, .1f, rayMask);
				Debug.DrawRay (raycastOrigin, Vector3.right * .1f, Color.green);
				if (raycastCheck) {

					// uses Raycasts to determine if the player is on the right side. 
					if(rightCheckHit.collider.gameObject.tag == "Player")
					{
						currentSide = sidePlayerIsOn.RIGHT;
						canMoveRight = true; 
						//print ("on right"); 
					}
					if (rightCheckHit.collider.gameObject.tag == "Platform" || rightCheckHit.collider.gameObject.tag == "Box") {

						canMoveRight = false;
						break;
					}


				} else {
					canMoveRight = true;
				}
			}
		}


	



	}
}
