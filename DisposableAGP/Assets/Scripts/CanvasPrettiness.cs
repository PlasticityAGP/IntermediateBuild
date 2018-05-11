using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasPrettiness : MonoBehaviour {

public int SceneInt;
public Image blackOut; 
bool changingScene;
bool fadeIn; 
bool fadingDone;  
bool isFading;
bool lerpToBlack;
bool shouldTeleport = true;
bool coroutineStarted; 

public GameObject oldScene;
public GameObject newScene;
public GameObject Player; 
public GameObject teleportSpot; 
	// Use this for initialization
	void Start () {

	changingScene = false; 
	fadingDone = false; 
	lerpToBlack = true;
	coroutineStarted = false;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (changingScene == true)
		{
			FadeOutAndChange();  
		}

		
	}


	void FadeOutAndChange ()
	{
		if (lerpToBlack)
		{
			blackOut.color = Color.Lerp (blackOut.color, Color.black, Time.deltaTime* 10f);
			}

			if (!coroutineStarted)
			{
				StartCoroutine ("WaitingForFade");
				coroutineStarted = true; 
			}
			 

			if(fadeIn == true)
			{
				blackOut.color = Color.Lerp (blackOut.color, Color.clear, Time.deltaTime* 10f);
			}

		
	}

//	IEnumerator WaitingForFade ()
//	{
//		// Teleporting right after we fade to black
//	//	shouldTeleport = true; 
//		yield return new WaitForSeconds (.5f);
//		//Teleporter ();
//		if (oldScene != null && newScene != null) {
//			oldScene.SetActive (false);
//			newScene.SetActive (true);
//		}
//		// Waiting a few seconds, and then fading back in. 
//		yield return new WaitForSeconds (1.2f);
//
//		lerpToBlack = false;
//		 
//		fadeIn = true; 
//
//		yield return new WaitForSeconds (.5f); 
//
//		isFading = false;
//		lerpToBlack = true;
//		fadeIn = false; 
//		changingScene = false; 
//		StopCoroutine ("WaitingForFade");  
//	}
//
//	void Teleporter()
//	{
//		// This helps prevent teleport from getting called a thousand times in the coroutine lol
//	if (shouldTeleport)
//		Player.transform.position = teleportSpot.transform.position;
////		Player.transform.GetChild(0).transform.position = teleportSpot.transform.position;
//		shouldTeleport = false; 
//	}
//
//	 
//}

}
