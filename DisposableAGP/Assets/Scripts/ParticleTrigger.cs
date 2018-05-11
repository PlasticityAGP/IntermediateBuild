using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTrigger : MonoBehaviour {

public ParticleSystem partsToPlay;

bool hasPlayedOnce;


	public FMOD.Studio.EventInstance soundToPlay;
	public string soundToPlayName;
	// Use this for initialization
	void Start () {
	// Gets the particles to play from the object that is a child of it
	partsToPlay = GetComponentInChildren<ParticleSystem>(); 

		if (soundToPlayName != null)
		{
			soundToPlay = FMODUnity.RuntimeManager.CreateInstance("event:/" + soundToPlayName);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider c)
	{
		if (c.tag == "Platform" || c.tag == "Pushable")

		{

		if (!hasPlayedOnce)
		{
			partsToPlay.Play();
			if (soundToPlayName !=null)
				{
					soundToPlay.start();
				}
			hasPlayedOnce = true;
		} 

			
		}
	}
}
