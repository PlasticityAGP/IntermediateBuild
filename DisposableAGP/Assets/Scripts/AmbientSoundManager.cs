using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientSoundManager : MonoBehaviour {

// Later, I should make this robust enough so that I can just use one script, and use a foreach to check every inspect in the game. 
public Inspection inspectionScript;

// This script manages what ambient sounds should be playing at any given time during the game. 
// In the future, we can store different ambiences for different zones, and fade between them. 

// IT CAN ALSO mute the ambience when inspections are happening.

	public FMOD.Studio.EventInstance zone1ambience;

	// Use this for initialization
	void Start () {
		zone1ambience = FMODUnity.RuntimeManager.CreateInstance("event:/AmbientNoise");

		// initializing the inspection variable. 
		inspectionScript = FindObjectOfType<Inspection>(); 

		zone1ambience.start(); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
