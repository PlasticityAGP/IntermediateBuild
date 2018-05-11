using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class Inspection : MonoBehaviour {

	public float speed; 
	public Vector3 maxScale;
	public Vector3 minScale;

	public float maxSunLight;
	public float minSunLight; 

	public GameObject maskToIncrease; 

	bool inspected; 
	public bool fadeOut; 

	// Lerp variables
	public float timeStartedLerping;
	public float speedOfDuringLerpIn = 2f; 
	public float speedOfDuringLerpOut = 7f; 
	public float speedOfMeshReturn = .1f;
	public float increase = 0;

	public bool isLerping;

	public Light lightToLerpIn;

	// THIS IS MESSY AND TEMP AND SHOULD BE FIXED WITH SOMETHING ELSE  
	public Light spot1ToLerp;
	public Light spot2ToLerp;
	float spotRange = 200f;
	public float intensityOfSpot;

	// particles to be enables when you are inspecting. 
	public ParticleSystem ambientParts; 

	//public ParticleSystem wooshParts;

	// this is the actual visual representation that will show up to tell you you can inspect. 
	public GameObject inspectIcon; 


	public FMOD.Studio.EventInstance inspectIns;
	public FMOD.Studio.EventInstance ambientBirdIns;



	// UNCOMMENT THESE
	public List<MeshRenderer> meshesToFade;
	public List<Material> materialList;
	public List<float> alphaValuesOfMeshes;
	//public List <float> smoothnessOfMeshes;
	float targetAlpha = 0f;

	MusicPlayer mP;

	public bool beachInspection;

	// These are for the last inpsection
	public PlayableDirector playableDirector;
	float timelineDuration;
	public VideoPlayer endingVideo;
	public GameObject blackenTheScreen;
	//public FMOD.Studio.EventInstance oceanSounds;


	// Use this for initialization
	void Start () {

		spot1ToLerp.intensity = intensityOfSpot;
		spot2ToLerp.intensity = intensityOfSpot;

		inspectIns = FMODUnity.RuntimeManager.CreateInstance("event:/InsightChirp");
		ambientBirdIns = FMODUnity.RuntimeManager.CreateInstance("event:/BirdsChirping");

		mP = GameObject.Find ("MusicManager").GetComponent<MusicPlayer> ();

		//	mP = GameObject.Find("MusicManager").GetComponent<MusicPlayer>();



		// Gets all of the meshes that we want to fade out for the particular inspection area
		foreach (MeshRenderer meshes in meshesToFade)
		{	


			for (int j = 0; j < meshes.materials.Length; j++)
			{
				print(meshes.materials);
				materialList.Add(meshes.materials[j]);
				alphaValuesOfMeshes.Add(meshes.material.color.a);


			}



			print ("gettingTheMeshes"); 

		}


		// Get a mesh
		// Get ALL the materials in that mesh
		// get the alpha value of all the materials in those meshes




	}

	// Update is called once per frame
	void FixedUpdate () {


		if (inspected)
		{

			// If we are in fact lerping after pressing the I button, then...
			if (isLerping)
			{

				//We want percentage = 0.0 when Time.time = _timeStartedLerping
				//and percentage = 1.0 when Time.time = _timeStartedLerping + timeTakenDuringLerp
				//In other words, we want to know what percentage of "timeTakenDuringLerp" the value
				//"Time.time - _timeStartedLerping" is.
				float timeSinceStarted = Time.time - timeStartedLerping;
				float percentageComplete = timeSinceStarted / speedOfDuringLerpIn;

				maskToIncrease.transform.localScale = Vector3.Lerp(minScale,maxScale,percentageComplete);

				FadeOutMeshes();

				// Light range is a float, so we use mathf.lerp instead. 
				lightToLerpIn.range = Mathf.Lerp(minSunLight,maxSunLight,percentageComplete);

				// THIS IS MESSY 
				spot1ToLerp.range = Mathf.Lerp(0,spotRange,percentageComplete);
				spot2ToLerp.range = Mathf.Lerp(0,spotRange,percentageComplete);







				//When we've completed the lerp, we set isLerping to false
				if(percentageComplete >= 1.0f)
				{
					isLerping = false;

					// start a coroutine that waits a few seconds before beginning to fade the old picture back in 
					ambientParts.Stop();
					StartCoroutine("InspectFadeOut"); 
				}


			}
		}


		// This gets called after the first image has faded out, in roder to lerp it back to normal. 
		// Works the same as the function above, but lerps the opposite things. 
		if (fadeOut)
		{

			float timeSinceStarted = Time.time - timeStartedLerping;
			float percentageComplete = timeSinceStarted / speedOfDuringLerpOut;

			//float scale = (Mathf.Lerp(minScale,maxScale, percentageComplete * speed));
			maskToIncrease.transform.localScale = Vector3.Lerp(maxScale,minScale,percentageComplete);
			lightToLerpIn.range = Mathf.Lerp(maxSunLight,minSunLight,percentageComplete);

			spot1ToLerp.range = Mathf.Lerp(spotRange,0,percentageComplete);
			spot2ToLerp.range = Mathf.Lerp(spotRange,0,percentageComplete);

			// we need to fade in the meshes
			FadeInMeshes(); 




			//When we've completed the lerp, we set _isLerping to false
			if(percentageComplete >= 1.0f)
			{	
				fadeOut = false;
				inspected = false;
				//inspectIcon.SetActive(true); 
				inspectIns.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);

				if (!beachInspection)
				{
					ambientBirdIns.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
				}

			}

		}

	}

	// When you are in the collider and press I 
	void OnTriggerStay(Collider c)
	{
		if (c.tag == "Player")
		{	
			// If you haven't already inspected...
			if (!inspected)
			{	// have the icon visible
				inspectIcon.SetActive(true);

				// when you press i, lerp it!
				if (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.LeftAlt))
				{

					// The growing of the tree needs to be classified in some way. Trees don't exist in every inspect, 
					// so it breaks everything when there is not tree. 

					if (GetComponent<GrowTree>() != null)
					{
						GetComponent<GrowTree>().OnInspectBegin();
					}

					GetTheInspectGoin();

					if (playableDirector !=null && beachInspection)
					{
						c.GetComponent<CharacterMovement3D> ().enabled = false;
						StartCoroutine("PlayBeachScene");
					}

				}


			}
		}
	}

	// When you leave the Inspect Zone, then the icon disappears. 
	void OnTriggerExit(Collider c)
	{
		if (c.tag == "Player")
		{	
			inspectIcon.SetActive(false); 
		}
	}


	IEnumerator InspectFadeOut()
	{	
		yield return new WaitForSeconds (2f);
		StartLerping();
		if (GetComponent<GrowTree>() != null)
		{
			GetComponent<GrowTree>().OnInspectEnd();
		}


		fadeOut = true;  
	}



	void StartLerping()
	{
		timeStartedLerping = Time.time; 
		inspectIcon.SetActive(false); 
	}



	void FadeOutMeshes()
	{
		for (int i = 0; i < alphaValuesOfMeshes.Count; i++)
		{
			print ("fading?????");
			alphaValuesOfMeshes[i] = Mathf.Lerp (alphaValuesOfMeshes[i], targetAlpha, Time.deltaTime*speedOfDuringLerpIn); 



			Color tempColor = materialList[i].color;
			tempColor.a = alphaValuesOfMeshes[i];
			materialList[i].color = tempColor;

		}

	}


	void FadeInMeshes()
	{
		for (int i = 0; i < alphaValuesOfMeshes.Count; i++)
		{
			print ("fading?????");
			alphaValuesOfMeshes[i] = Mathf.Lerp (alphaValuesOfMeshes[i], 1f, Time.deltaTime*speedOfMeshReturn); 



			Color tempColor = materialList[i].color;
			tempColor.a = alphaValuesOfMeshes[i];
			materialList[i].color = tempColor;

		}

	}

	public void GetTheInspectGoin()
	{
		inspected = true; 
		isLerping = true; 
		//inspectIcon.SetActive(true); 
		StartLerping();
		inspectIns.start();
		if (!beachInspection)
		{
			ambientBirdIns.start();
		}
		ambientParts.Play(); 
	}

	IEnumerator PlayBeachScene ()
	{
		yield return new WaitForSeconds(1f);

		playableDirector.Play(); 
		print ("coroutiniiinngign");

		StartCoroutine ("WaitForTimelineToFinish");
	}



	IEnumerator WaitForTimelineToFinish(){

		timelineDuration = (float)playableDirector.duration;

		print (timelineDuration);
		//ToggleInput (false);

		yield return new WaitForSeconds(13f);
	
		mP.beachMusic.stop (FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
		print ("fadingmusic");
		endingVideo.Play ();
		mP.softbeachMusic.start ();
		blackenTheScreen.SetActive (true);

		yield return new WaitForSeconds (70f);
		mP.softbeachMusic.stop (FMOD.Studio.STOP_MODE.ALLOWFADEOUT);

		SceneManager.LoadScene (2);


	}
}
