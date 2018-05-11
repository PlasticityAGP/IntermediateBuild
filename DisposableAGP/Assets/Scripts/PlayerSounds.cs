using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour {

// accessing the character controller so we can access the velocity variables.
CharacterMovement3D cM;

[FMODUnity.EventRef]
// name of actual sound
public string inputSound;

bool playerIsMoving;
public float walkingSpeed;

bool boxSoundStart = false;

public FMOD.Studio.EventInstance boxPush;

	void Start () {

	cM = gameObject.GetComponent<CharacterMovement3D>(); 

	// Sound will be called at the frequency of "walkingSpeed"
	InvokeRepeating ("CallFootsteps",0f,walkingSpeed);

		boxPush = FMODUnity.RuntimeManager.CreateInstance("event:/CardboardBoxPush");
		
	}
	

	void Update () {

		if ((cM.velocity.x > 0.01f) || (cM.velocity.x < -0.01) && cM.velocity.y == 0)
		{
			playerIsMoving = true; 
		}

		else if (cM.velocity.x == 0)
		{
			playerIsMoving = false;
		
		} 
		
	}


	// function that actually calls the footstep sound to get called. 
	void CallFootsteps()
	{
		if(playerIsMoving)
		{
			FMODUnity.RuntimeManager.PlayOneShot (inputSound);

			 if (cM.isPulling)
			 {
			 	if (boxSoundStart == false)
			 	{
					boxPush.start();
					boxSoundStart = true;
				}
			 } 
		}

		if (cM.isPulling)
		{
			walkingSpeed = 0.55f;
			print ("I'm pulling so i'll slow down");
		}

		if (!cM.isPulling)
		{
			walkingSpeed = 0.4f;
			boxSoundStart = false;
			boxPush.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);

		}
	}

	// if script is ever disabled, automatically set moving to false. 
	// This is good for cutscenes, or if you want to stop the sound completely regardless if they are pressing the buttons or not. 
	void OnDisable()
	{
		playerIsMoving = false;
	}
}
