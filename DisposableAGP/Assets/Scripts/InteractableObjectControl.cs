using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjectControl : MonoBehaviour {

CharacterMovement3D cM;

public BirdController beachBird;


	//she can pull bby
public PullableObject currentPullObject;
public TriggerAnimation currentTriggerAnimation;
public KeyCode grabObject = KeyCode.LeftControl;

	// Use this for initialization
	void Start () {

	cM = GetComponent<CharacterMovement3D>(); 
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



	// This function handles all interactions with the environment
	public void Pull()
	{
		//check to see if we're near a pullable object and we're on the ground and the grab key is pressed

		// ADD: Add a bool that gets set to true when you are pulling, that prevents you from flipping at the top. 

		if (currentPullObject != null
		    && cM.onGround
		    && Input.GetKey (grabObject)) {

		   	
			// pull the object
			cM.isPulling = true;
			cM.playerAnimator.SetBool("pulling",true);

			// checks what side of the crate you are on and what you are pressing to determine if you are pushing the box or pulling the box.
			if ((currentPullObject.currentSide == PullableObject.sidePlayerIsOn.LEFT && Input.GetKey(KeyCode.RightArrow)) &&  cM.facingRight || (currentPullObject.currentSide == PullableObject.sidePlayerIsOn.RIGHT && Input.GetKey(KeyCode.LeftArrow)) && !cM.facingRight)
			{
				cM.playerAnimator.SetBool("pushing",true);
				cM.playerAnimator.SetBool("pulling",false); 
			}

			// checks what side of the crate you are on and what you are pressing to determine if you are pushing the box or pulling the box.
			if ((currentPullObject.currentSide == PullableObject.sidePlayerIsOn.LEFT && Input.GetKey(KeyCode.LeftArrow)) && cM.facingRight || (currentPullObject.currentSide == PullableObject.sidePlayerIsOn.RIGHT && Input.GetKey(KeyCode.RightArrow)) && !cM.facingRight)
			{
				cM.playerAnimator.SetBool("pushing",false);
				cM.playerAnimator.SetBool("pulling",true); 
			}


			// set speed in animator for certain parameters to be equal to her velocity
			cM.playerAnimator.SetFloat("Speed", cM.velocity.x);

			PullableObject pulledThing = currentPullObject.GetComponent<PullableObject>();

			if (!pulledThing.canMoveRight) {
				cM.canMoveRight = false;
				pulledThing.pushPartsLeft.Stop();
				pulledThing.pushPartsRight.Stop();
			}
			if (!pulledThing.canMoveLeft) {
				cM.canMoveLeft = false;			
				pulledThing.pushPartsLeft.Stop();
				pulledThing.pushPartsRight.Stop();
			 }

			// slow down so it looks lika ya pullin boxes also because it makes good
			cM.velocity = new Vector3(cM.velocity.x/2, cM.velocity.y/2, 0f);

			// This is so we don't need to use raycasts for collisions and can use unity collisions instead
			currentPullObject.GetComponent<Rigidbody>().MovePosition(currentPullObject.transform.position + (cM.velocity * 0.015f));

//			// If our player is actually moving
//			if (currentPullObject !=null && cM.velocity.x > 0.1f)
//			{
//				// Playes particles of the pulledThing. 
//					pulledThing.pushPartsLeft.Play();
//					pulledThing.pushPartsRight.Play();
//			}

//			else
//			{
//				pulledThing.pushPartsLeft.Stop();
//				pulledThing.pushPartsRight.Stop();
//			}
			

		}

		// IF NOT PULLING / PUSHING.... Play Custom Animation
		//otherwise play custom animation for pullable object (ie ladder)  
		else if (currentTriggerAnimation != null && Input.GetKey(grabObject)) {

		// creates visual feedback immediately, and lets us input which animation we want to use. 
			cM.playerAnimator.SetBool(currentTriggerAnimation.animationToSetForTriggerAnim,true);




			// If you are pressing control.... but ALSO pressing the direction on top of control to complete the action, then play the animation. 
			if (Input.GetKey(currentTriggerAnimation.directionToPress) ||Input.GetKey(currentTriggerAnimation.directonToPressWASD))
			{
				// creates visual feedback immediately, and lets us input which animation we want to use. 
				// Lets you use a secondary character animation for if they complete the action.



				if (currentTriggerAnimation.secondaryAnimationToSetForTriggerAnim != null)
				{ 
					// BEACH CUTSCENE MADNESS
					// TRYING TO KEEP HER LOOKING RIGHT ALWAYS 
					if (currentTriggerAnimation.beachScene && beachBird !=null)
					{
						// Disabling the player controller so that she cannot turn around when she is pulling 
						cM.enabled = false;
						// THIS is what was breaking the cutscene!
						beachBird.hasHelpedBird = true;
						beachBird.birdAnimator.SetBool("helpedBird",true);
						print (beachBird.hasHelpedBird);
						cM.playerModel.transform.rotation = Quaternion.Euler(0,90,0);
						cM.facingRight = true; 
						Debug.Log("I should be flipping the player right.");

						// If the current trigger animation has played, set the character controller back to active.... for some reason.
						// Sometimes this wasn't happening, which is concerning.
						if (currentTriggerAnimation.hasAnimPlayed)
						{
							cM.enabled = true;
						}
					}

					// Qualifying it that if the thing you are pulling is not in fact from the bird thing, don't worry about it. 
					else
					{

						cM.playerAnimator.SetBool(currentTriggerAnimation.secondaryAnimationToSetForTriggerAnim,true);
					}


				}


				// plays the animation of the actual object. 
				currentTriggerAnimation.PlayAnimation ();

				// more spaghetti
				// automaticaly sets her back to idle when the cutscene is done, hopefully. 

			}
		}

		if (Input.GetKeyUp (grabObject)) {
			cM.isPulling = false;
			cM.playerAnimator.SetBool("pushing",false);
			cM.playerAnimator.SetBool("pulling",false);
			currentPullObject = null; 



			if (currentTriggerAnimation != null)
			{
				cM.playerAnimator.SetBool(currentTriggerAnimation.animationToSetForTriggerAnim,false);
				cM.playerAnimator.SetBool(currentTriggerAnimation.secondaryAnimationToSetForTriggerAnim,false);
			}

//				currentPullObject.GetComponent<PullableObject>().pushPartsLeft.Stop();
//				currentPullObject.GetComponent<PullableObject>().pushPartsRight.Stop();

		}

	}
}
