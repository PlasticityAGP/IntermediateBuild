using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour {
	public Animation myAnimation;
	Animator myAnimator;
	public Animator playerAnimator;

	public bool hasAnimPlayed; 

	// this lets you publicly input which animation you want played in the Pull function 
	// You can have ANY animation play this way, and change it on a per object basis!
	public string animationToSetForTriggerAnim; 
	public string secondaryAnimationToSetForTriggerAnim; 

	public KeyCode directionToPress; 
	public KeyCode directonToPressWASD; 
	// Use this for initialization

	// THIS IS SPAGHETTI
	public bool beachScene;

	public FMOD.Studio.EventInstance soundToPlay;
	public string soundToPlayName;

	public FMOD.Studio.EventInstance trippingSound;

	public bool playSound = false;

	public bool shouldFallBack;

	GameObject playerBody;

	public float directionOfForce;
	public float forceIntensity;



	void Start () {
		myAnimator = GetComponent<Animator> ();

//		if (soundToPlayName != null)
//		{
//			playSound = true;
//
//		}

		if (playSound)
			{
				soundToPlay = FMODUnity.RuntimeManager.CreateInstance("event:/" + soundToPlayName);
			}

			trippingSound = FMODUnity.RuntimeManager.CreateInstance("event:/GirlTrip");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// replaced the character move scripts here with the new InteractableObjectControl script.
	void OnTriggerStay(Collider other){
		InteractableObjectControl player = other.gameObject.GetComponent<InteractableObjectControl> ();
		// Getting the gameobject of the player character
		playerBody = other.gameObject;
		if (player && player.currentTriggerAnimation == null) {
			player.currentTriggerAnimation = this;
			playerAnimator = player.GetComponent<Animator>();
		}

//		if (hasAnimPlayed)
//			{
//				player.currentTriggerAnimation = null;
//			}
	}

	void OnTriggerExit(Collider other){
		InteractableObjectControl player = other.gameObject.GetComponent<InteractableObjectControl> ();
		if (player && player.currentTriggerAnimation == this) {
			player.currentTriggerAnimation = null;
			playerAnimator.SetBool(animationToSetForTriggerAnim, false);
			playerAnimator.SetBool(secondaryAnimationToSetForTriggerAnim, false);

//			if (hasAnimPlayed)
//			{
//				player.currentTriggerAnimation = null;
//			}
		 

		}

		// If you leave the trigger and the animation has already played....
			if (hasAnimPlayed)
			{
				// disables the collider upon exiting + completing the animation because we don't need it anymore. 
				gameObject.GetComponent<Collider>().enabled = false;
			
				print ("disabled" + gameObject.GetComponent<Collider>()); 
			}
	}

	public void PlayAnimation(){
//		//Debug.Log ("SNIFFFFFF");
//		if (myAnimator.GetComponent<BirdController>())
//		{
//			myAnimator.SetBool("helpedBird", true);
//			// you helped me
//		}

 
			myAnimator.SetBool("Play", true);
			bool hasPlayedSound = false;


		if (shouldFallBack)
			{
				StartCoroutine ("FallBack"); 
			}

			if (soundToPlayName !=null)
			{
				if (!hasPlayedSound)
				{
					soundToPlay.start();
					hasPlayedSound = true; 
				}
			}



			hasAnimPlayed = true;

//			if (shouldFallBack)
//			{
//				GetUp();
//			}

		 
	
	}


	IEnumerator FallBack()
	{
		bool fellDown = false;
		bool doneWithAnim;

		yield return new WaitForSeconds(.1f); 
		playerBody.GetComponent<Rigidbody>().AddForce(directionOfForce * forceIntensity,0f,0f);
		print ("blowingBackCharacter");

		playerBody.GetComponent<Animator>().SetBool("fallDown",true);
		trippingSound.start();
		print ("make me fall");
		fellDown = true; 
	
		yield return new WaitForSeconds(1f);

		if (fellDown == true)
			{
				playerBody.GetComponent<Animator>().SetBool("fallDown",false);
				print ("go back to normal");
				doneWithAnim = true;

			}

		if (doneWithAnim = true)
		{
			fellDown = false;
			playerBody.GetComponent<Animator>().SetBool("fallDown",false);
			doneWithAnim = false;  

		}
	}

	// Upon leaving the trigger after the animation has played, then we will wait a few seconds and then disable the collider. 
	// When we disabled it instantly, some bad stuff happened. 
//	IEnumerator WaitAndDisable()
//	{
//		
//	}
}
