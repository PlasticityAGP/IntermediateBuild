using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorShaker : MonoBehaviour {

	// The literal entire tractor 
	public GameObject tractor;

	// Allows us to have different amounts of Tractor Shakers in use at once depending on how we want to use it. 
	public List<TractorShaker> otherShakers;

	// Let's just program it into here - make it impossible for it to be removed from the tractor. 
	public GameObject container;

	public Coroutine resetRoutine;
	public Coroutine tipRoutine;  

	Quaternion startRot;

	Quaternion targetRotation;

	// float to change smoothness of lerp.  
	public float smooth = 1f;

	public float angleOfRot;

	public float distanceContainerMoves;

	public float directionForBox;

	public float directionForTractor;

	public float lerpTime;

	bool tipped;

	bool tippingDown; 

	bool resetRoutineRunning;

	bool tipRoutineRunning;

	public FMOD.Studio.EventInstance tipDown;
	public FMOD.Studio.EventInstance tipUp;

	public FMOD.Studio.EventInstance woodDown;
	public FMOD.Studio.EventInstance woodUp;

	public bool shouldCreak;
	public bool wooden;


	// Use this for initialization
	void Start () {

		targetRotation = tractor.transform.rotation; 
		startRot = tractor.transform.rotation;

		// Setting the target rotation to be our first position, multiplied by the angle that we want. 
		// I guess this is how unity calculates rotations in the front end?
		targetRotation *=  Quaternion.AngleAxis(angleOfRot, Vector3.forward * directionForTractor);

		tipDown = FMODUnity.RuntimeManager.CreateInstance("event:/MetalCreakDown");
		tipUp = FMODUnity.RuntimeManager.CreateInstance("event:/MetalCreakUp");
		woodDown = FMODUnity.RuntimeManager.CreateInstance("event:/WoodCreakDown");
		woodUp = FMODUnity.RuntimeManager.CreateInstance("event:/WoodCreakForPlank");



	}

	// Update is called once per frame
	void Update () {

		//		if (tipped == true)
		//		{
		//			// Smoothly lerping the rotation to the desired angle we set up above. 
		//			tractor.transform.rotation= Quaternion.Lerp (startRot, targetRotation, Time.time);
		//		}





	}


	void OnTriggerStay (Collider c)
	{


		if (c.gameObject.tag == "Player")
		{

			// If you impact the collider after jumping or falling off something (your y velocity is negative)
			if (c.gameObject.GetComponent<CharacterMovement3D>().velocity.y < 0 && !tipped)
			{

				tipped = true; 

				if (container != null)
				{
//					// only if you pull down the thing from the shelf first.
//					if (container.GetComponent<RollingContainer>().offTheShelf == true)
//					{
						container.GetComponent<Rigidbody>().MovePosition(container.transform.position + (new Vector3 (distanceContainerMoves * directionForBox,0f,0f))); 
					//}
				}


				// This ensures that only if there is no coroutine running then a new coroutine will get called. 
				if (tipRoutine == null)
				{
					Debug.Log("start");
					tipRoutine = StartCoroutine("TipTractor");

					// We are going to look at every other tractor shaker, and then if there are any other coroutines running, we are going to stop them.
					// Determine if there is more than one tractorShaker script in the game, and then find them.  
					if (otherShakers.Count > 0)
					{

						// For every single tractor shaker we are interfacing with, check to see if they have coroutines running.
						// If so, then stop them.
						// Every time she enters a new trigger, it interrupts old coroutines and starts new ones
						foreach (TractorShaker shaker in otherShakers)
						{
							Debug.Log("WE STOPPED 'EM");
							// if the other shakers HAVE and instance of a coroutine running...
							if (shaker.tipRoutineRunning)
							{
								shaker.StopTipRoutine();
								//								shaker.tipRoutine = null; // sets the coroutine reference to null
							}

							if(shaker.resetRoutineRunning)
							{
								shaker.StopResetRoutine();
								//								shaker.resetRoutine = null; // sets the coroutine reference to null
							}
						}

					}

					tipRoutineRunning = true;

				}

				// If we are in the collision, we will prevent the Coroutine from happening. 
				// If she re-enters the collider during the coroutine happening, then make sure that the coroutine does not get called again. 
				// This is a foolproof that just stops the coroutine from running when the conditions aren't right. 
				if (resetRoutine != null)
				{
					Debug.Log("stop");
					StopCoroutine(resetRoutine); 
					resetRoutineRunning = false;
				}
			}
		}
	}


	// This could have it move back to it's normal place???
	void OnTriggerExit (Collider c)
	{
		if (c.gameObject.tag == "Player")
		{
			if (tipped == true)
			{	// when you exit it, you want to stop that lerp and then be able to start the new one without issues. 
				// we are doing this because coroutines can get called multiple times, and the bool ensures it will be called only once. 
				if (!resetRoutineRunning) {
					resetRoutine = StartCoroutine("WaitToResetPosition"); 
				}
			}



		}
	}

	// We needed to make both lerps in coroutines because we needed the constant increase in time. 
	// This way, we stop and start things in a consistent way <3 ))
	IEnumerator TipTractor () {
		tipRoutineRunning = true;
		Debug.Log("calltip");

		if (shouldCreak)
		{
			print ("creaking up");
			tipUp.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
			tipDown.start();
		}

		if (wooden)
		{
			woodUp.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
			woodDown.start();
		}



		if (resetRoutine != null)
		{
			StopCoroutine(resetRoutine);
		}
		float elapsedTime = 0;
		float overTime = 1.0f;

		// setting a new start rotation for lerp for every time you enter the trigger.
		Quaternion start;

		start = tractor.transform.rotation;

		while (elapsedTime < overTime)
		{
			if (tipRoutineRunning == false)
			{
				break;
			}

			elapsedTime += Time.deltaTime;

			tractor.transform.rotation = Quaternion.Lerp (start, targetRotation, (elapsedTime/overTime));

			yield return null;
		}

		tipRoutineRunning = false;

		// we are setting it null because in order to stop the coroutines, we need to know if they are running or not. 
	}

	IEnumerator WaitToResetPosition ()
	{

		// Setting the bool that ensures the coroutine only gets called once instead of multiple instances. 

		if (shouldCreak)
		{
			print ("creaking up");
			tipDown.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
			tipUp.start();
		}

		if (wooden)
		{
			woodDown.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
			woodUp.start();
		}
		resetRoutineRunning = true; 

		tipped = false;
		Debug.Log("call");
		yield return new WaitForSeconds (.3f);
		if (tipRoutine != null) {
			StopCoroutine(tipRoutine);
		}
		tipRoutine = null;
		// Smoothly lerping the rotation to the desired angle we set up above. 

		// We are simulating framerate WITHIN a coroutine to get this to work by using the while loop!
		float elapsedTime = 0;
		float overTime = 1.0f;  

		Quaternion start;

		start = tractor.transform.rotation;

		while (elapsedTime < overTime)
		{
			if (resetRoutineRunning == false)
			{
				break;
			}

			elapsedTime += Time.deltaTime; 

			tractor.transform.rotation= Quaternion.Lerp (start, startRot, (elapsedTime/overTime));

			yield return null; 


		} 

		resetRoutineRunning = false;

	}

	// Made these functions so that the individual instance of the script stops their own coroutines
	// We did this because computers don't like it when a script stops another scripts coroutine 
	public void StopTipRoutine()
	{
		if (tipRoutine != null) {
			StopCoroutine(tipRoutine);
			tipRoutineRunning = false;
		}
	}

	public void StopResetRoutine()
	{
		if (resetRoutine != null) {
			StopCoroutine(resetRoutine);
			resetRoutineRunning = false;
		}
	}


}
