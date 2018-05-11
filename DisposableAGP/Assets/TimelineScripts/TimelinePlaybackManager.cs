using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Timeline;
using UnityEngine.Playables;
//using UnityStandardAssets.Characters.ThirdPerson;

public class TimelinePlaybackManager : MonoBehaviour {

	public BirdController birdToSave;

	[Header("Timeline References")]
	public PlayableDirector playableDirector;

	[Header("Timeline Settings")]
	public bool playTimelineOnlyOnce;


	[Header("Player Input Settings")]
	public KeyCode interactKey;
	public bool disablePlayerInput = false;
	private CharacterMovement3D inputController;
	InteractableObjectControl IOC;

	[Header("Player Timeline Position")]
	public bool setPlayerTimelinePosition = false;
	public Transform playerTimelinePosition;

	[Header("Trigger Zone Settings")]
	public GameObject triggerZoneObject;

	[Header("UI Interact Settings")]
	public bool displayUI;
	public GameObject interactDisplay;

	[Header("Player Settings")]
	public string playerTag = "Player";
	public GameObject playerObject;
	//private PlayerCutsceneSpeedController playerCutsceneSpeedController;


	private bool playerInZone = false;
	private bool timelinePlaying = false;
	public float timelineDuration;


	void Start(){
		//playerObject = GameObject.FindWithTag (playerTag);
		inputController = playerObject.GetComponent<CharacterMovement3D>();
		IOC = playerObject.GetComponent<InteractableObjectControl>();
	//	playerCutsceneSpeedController = playerObject.GetComponent<PlayerCutsceneSpeedController> ();
		ToggleInteractUI (false);
	}

	public void PlayerEnteredZone(){
		playerInZone = true;
		ToggleInteractUI (playerInZone);
	}

	public void PlayerExitedZone(){
		
		playerInZone = false;

		ToggleInteractUI (playerInZone);

	}
		
	void Update(){

		if (playerInZone && !timelinePlaying) 
		{


		// THIS IS WHERE we will need to have the sequence activate becfause of the bird being freed. 
			var activateTimelineInput = Input.GetKey (interactKey);


			if (birdToSave != null)
			{
			// So, this makes it so that if you have saved the bird, then the timeline will automatically play. 
				 if (birdToSave.hasHelpedBird == true)
				{

					// We should force the player to face back to the right probably? 
					PlayTimeline();
				}
			}
				

				else if (interactKey == KeyCode.None) 
				{
				 
					PlayTimeline ();
				} 

				else 
				{
					if (activateTimelineInput) 
					{
						PlayTimeline ();
						ToggleInteractUI (false);
					}
				}
		}

	}

	public void PlayTimeline(){

		if (setPlayerTimelinePosition) {
			SetPlayerToTimelinePosition ();
		}

		// this actually sets the timeline to turn on!
		if (playableDirector) {
			
			playableDirector.Play ();

		}
			
		triggerZoneObject.SetActive (false);


		timelinePlaying = true;
			
		StartCoroutine ("WaitForTimelineToFinish");

			
	}

	IEnumerator WaitForTimelineToFinish(){
	 
		timelineDuration = (float)playableDirector.duration;

		print (timelineDuration);
		//ToggleInput (false);

		playerObject.GetComponent<CharacterMovement3D>().playerAnimator.applyRootMotion = true; 

		playerObject.GetComponent<PlayerSounds>().enabled = false; 
		playerObject.GetComponent<CharacterMovement3D>().inputAllowed = false;

		// The player keeps fucking moving so i want to stop her
		// Setting her animation back to idle, and making her velocity zero. 
		// Set their velocity to zero when they enter the cutscene zone
		//playerObject.GetComponent<CharacterMovement3D>().velocity.x = 0;
		playerObject.GetComponent<CharacterMovement3D>().playerAnimator.SetBool("backToIdle",true);


		yield return new WaitForSeconds(timelineDuration);

		ResetPlayerAfterCutscene();

	
		if (!playTimelineOnlyOnce) {
			triggerZoneObject.SetActive (true);
		} else if (playTimelineOnlyOnce) {
			playerInZone = false;
		}

		timelinePlaying = false;

	}
		
//	void ToggleInput(bool newState){
//		if (disablePlayerInput){
//			// this is a boolean that determines if there should be input allowed while cutscenes are playing. 
//			//playerObject.GetComponent<CharacterMovement3D>().inputAllowed = newState
//			print(newState);
//			inputController.inputAllowed = newState;
//		}
//	}


	void ToggleInteractUI(bool newState){
		if (displayUI) {
			interactDisplay.SetActive (newState);
		}
	}

	void SetPlayerToTimelinePosition(){
		playerObject.transform.position = playerTimelinePosition.position;
		playerObject.transform.localRotation = playerTimelinePosition.rotation;
	}


	void ResetPlayerAfterCutscene()
	{
		// re-enables the playercontroller after the cutscene happens. 
		playerObject.GetComponent<CharacterMovement3D>().enabled = true;

		playerObject.GetComponent<CharacterMovement3D>().playerAnimator.applyRootMotion = false; 

		// sets sounds back to true as well;
		playerObject.GetComponent<PlayerSounds>().enabled = true; 

		// frees you from being locked to idle?
		playerObject.GetComponent<CharacterMovement3D>().playerAnimator.SetBool("backToIdle",false);

		// If you are trying to jump out of a trigger animation after the cutscene automatically, then we will do it here. 
		if ( IOC.currentTriggerAnimation != null && IOC.currentTriggerAnimation.secondaryAnimationToSetForTriggerAnim != null)
		{
			inputController.playerAnimator.SetBool(IOC.currentTriggerAnimation.animationToSetForTriggerAnim,false);
			inputController.playerAnimator.SetBool(IOC.currentTriggerAnimation.secondaryAnimationToSetForTriggerAnim,false);
		}

		playerObject.GetComponent<InteractableObjectControl>().currentTriggerAnimation = null; 

		playerObject.GetComponent<CharacterMovement3D>().inputAllowed = true;
		//ToggleInput (true);

		// Make the inspection zone aliiiiive
		birdToSave.enableInspection = true;
	}
}