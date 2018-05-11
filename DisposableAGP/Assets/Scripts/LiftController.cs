using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftController : MonoBehaviour {

	// Use this for initialization


	bool movingUp = false;
	bool movingDown = false;
	bool stopSoundPlayed = false;

	// The actual lift object
	public GameObject lift;

	Vector3 startPos;
	public float moveSpeed;

	public FMOD.Studio.EventInstance liftSoundUp;
	public FMOD.Studio.EventInstance liftSoundDown;
	public FMOD.Studio.EventInstance liftStop;

	void Start () {

	startPos = lift.transform.position; 
	liftSoundUp = FMODUnity.RuntimeManager.CreateInstance("event:/LiftUp");
	liftSoundDown = FMODUnity.RuntimeManager.CreateInstance("event:/LiftDown");
	liftStop = FMODUnity.RuntimeManager.CreateInstance("event:/LiftStop");
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

	if (movingUp)
	{
		MovingUp();

	}

	if (movingDown)
	{
		MovingDown();

	}
		
	}

	void MovingUp()
	{
		if (lift.transform.position.y > 4.0f)
		{
			movingUp = false;
			print ("IM WORKING");


				liftSoundUp.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
				liftSoundDown.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);

				if (!stopSoundPlayed) {
					liftStop.start();
					stopSoundPlayed = true;
				}
				print ("stopSound");
			  
			return;
		}

		// Moves the lift up by movespeed every frame in update
	 		lift.transform.Translate(0,moveSpeed,0);
		

	}


	void MovingDown()
	{
		if (lift.transform.position.y < startPos.y )
		{
			movingDown = false;


			liftSoundUp.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
			liftSoundDown.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);

			if (!stopSoundPlayed) 
			{
					liftStop.start();
					stopSoundPlayed = true;
			}
			  
			return;
		}
	 		lift.transform.Translate(0,-moveSpeed,0);

	}


	// checks if you collided with the pedal
	void OnTriggerStay(Collider c)
	{


		movingUp = true;
		movingDown = false;

	}

	void OnTriggerExit(Collider c)
	{

		if (c.tag == "Player" || c.tag == "Pushable")
		{
			movingUp = false;
			movingDown = true;
			liftSoundUp.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
			liftSoundDown.start();
			stopSoundPlayed = false;
		}
	}

	void OnTriggerEnter(Collider c)
	{

		if (c.tag == "Player" || c.tag == "Pushable")
		{
			liftSoundUp.start();
			liftSoundDown.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
			stopSoundPlayed = false;
		}
	}


}
