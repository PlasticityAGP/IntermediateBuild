using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorAnimationController : MonoBehaviour {

public Animator tractorAnimator;
public Animator pedalAnimator;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay (Collider c)
	{
		if (c.tag == "Player" || c.tag == "Pushable")
		{
			tractorAnimator.SetBool("movingUp",true);
			pedalAnimator.SetBool("pedalPushed",true);
		}
	}


	void OnTriggerExit (Collider c)
	{
		if (c.tag == "Player" || c.tag == "Pushable")
		{
			tractorAnimator.SetBool("movingUp",false);
			pedalAnimator.SetBool("pedalPushed",false);

		}
	}
}
