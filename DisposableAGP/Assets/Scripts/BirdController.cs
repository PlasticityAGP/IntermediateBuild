using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour {


// This is the script that can manage all of the behavior for the bird throughout the entire game. 


// NEXT TASK - CLEAN UP CODE. Make it easier to use Pullable Object, Trigger Animation, etc.!!!

public TriggerAnimation strawTriggerAni;

public bool hasHelpedBird;
public GameObject straw;

bool pulledStraw;


public int zoneInteractionNumber;

// This way we can manage several different inspections as we move forward with our game. Turn some on, and turn some off. 
public GameObject[] inspectionTriggers; 

// We were able to use the TriggerAnimation script to do the other work for us... we may have to switch that in the future. But for now, that's ok.
public Animator birdAnimator;
public ParticleSystem birdFeedbackParts;

public bool enableInspection;

public DistanceSound dS;

public FMOD.Studio.EventInstance helpSound;

bool playedSound;



	// Use this for initialization
	void Start () {
	birdAnimator = gameObject.GetComponent<Animator>(); 

	helpSound = FMODUnity.RuntimeManager.CreateInstance("event:/HelpedBird");

	// TODO: Foreach that gets all inspection triggers. b
		
	}
	
	// Update is called once per frame
	void Update () {

	if (zoneInteractionNumber == 1)
	{
		FirstZoneInteraction(); 
	}

	if (zoneInteractionNumber == 2)
	{
		SecondZoneInteraction();
	}

	}

	void FirstZoneInteraction()
	{
		// if you have indeed helped the birb friend, then all of the cool things will happen. 
		if (hasHelpedBird)
		{
			// we can interface with the bird in the exact same way 
				birdAnimator.SetBool("helpedBird",true);
				if (!playedSound)
				{
					helpSound.start();
					playedSound = true;
				}
				dS.eventIns.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
				inspectionTriggers[0].SetActive(true); 
		}
	}

	void SecondZoneInteraction()
	{
		// if the animation has in fact played
		if (pulledStraw)
		{
			
			if (strawTriggerAni.hasAnimPlayed)
			{
				//print ("theAnimationIsDone!");
				birdAnimator.SetBool("helpedBird",true);
				hasHelpedBird = true;

				// we can interface with the bird in the exact same way 
			
				// make sure you can't enter the pull straw state again. 
				straw.GetComponent<Collider>().enabled = false; 
			}
		}
		// if you have indeed helped the birb friend, then all of the cool things will happen. 
		if (hasHelpedBird && enableInspection )
		{
			// we can interface with the bird in the exact same way 
				birdAnimator.SetBool("helpedBird",true);
				dS.eventIns.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
				inspectionTriggers[1].SetActive(true); 
		}
	}


	void OnTriggerStay(Collider c)
	{
		if (c.tag == "Player")
		{
		// If we were in the birdy zone and we pressed control to help it, do something cool. 
			if (Input.GetKeyDown(KeyCode.LeftControl))
			{

				if (zoneInteractionNumber == 2)
				{
					pulledStraw = true;
					//hasHelpedBird = true; 
				}

				else
				{
					hasHelpedBird = true;
					birdFeedbackParts.Play(); 
				}
				
			}


		}
	}
}
