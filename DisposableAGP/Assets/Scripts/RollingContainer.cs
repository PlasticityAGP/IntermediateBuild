using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingContainer : MonoBehaviour {

public bool offTheShelf;

public TriggerAnimation triggerAni;

	// Use this for initialization
	void Start () {

	gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
		
	}
	
	// Update is called once per frame
	void Update () {

	if (triggerAni.hasAnimPlayed)
	{
		// once the animation has played, our object can move.
		print ("the box can move!");

		// Moves the object up a little because the animator interferes with the physics. 
		if (offTheShelf == false)
		{
			gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

			// This is how to set multiple constaints in one line - with the | 
			gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;;
			



			gameObject.GetComponent<Rigidbody>().MovePosition(gameObject.transform.position + (new Vector3 (0f,.05f,0f)));

			gameObject.GetComponent<Rigidbody>().MovePosition(gameObject.transform.position + (new Vector3 (.5f,0f,0f)));

			offTheShelf = true;
		} 
	


	}
		
	}


}
