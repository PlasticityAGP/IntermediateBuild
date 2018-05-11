using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPanTrigger : MonoBehaviour {

// We are disabling the main Cinemachine camera in order for the secondary, dolly tracked one to play. 
// We will enable it again after the cutscene plays!
public GameObject mainFollowCam;

public GameObject panningCam;

public bool hasPanned;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider c)
	{
		// Set it false so that the other camera will pan and show the bird. 
		if (c.tag == "Player")
		{
			if (hasPanned == false)
			{
				StartCoroutine("CameraPanAndDisable");
			
				
			}
		}
	}


	// Coroutine that waits a certain number of seconds before re-enabling the primary camera. Then, after the camera has been set, set this trigger to inactive so it can't happen again.
	IEnumerator CameraPanAndDisable()
	{
		mainFollowCam.SetActive(false);
		panningCam.SetActive(true);

		yield return new WaitForSeconds (9f);

		hasPanned = true; 
		mainFollowCam.SetActive(true); 
		panningCam.SetActive(false);

		yield return new WaitForSeconds (1f);

		// deactivate ourself so that the trigger can't happen again. 

		gameObject.SetActive(false);




		
	}
}
