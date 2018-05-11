using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftAnimationController : MonoBehaviour {
	public Animator liftAnimator;
	public Animator pedalAnimator;

	bool hasBeenPressed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay (Collider c)
	{
		
		if (!hasBeenPressed)
		{	hasBeenPressed = true;
			liftAnimator.SetBool("movingUp",true);
			pedalAnimator.SetBool("pedalPushed",true);
		}
	}


	void OnTriggerExit (Collider c)
	{	
		if (hasBeenPressed)
		{
			liftAnimator.SetBool("movingUp",false);
			pedalAnimator.SetBool("pedalPushed",false);
			hasBeenPressed = false;
		}
	}
}
