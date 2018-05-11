using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorShatter : MonoBehaviour {
	public Animator floorAnimator;

	public FMOD.Studio.EventInstance soundToPlay;

	bool playedSound;
	//public ParticleSystem dustParts;

	// Use this for initialization
	void Start () {

		soundToPlay = FMODUnity.RuntimeManager.CreateInstance("event:/FloorShatter");
		
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		CharacterMovement3D player = other.gameObject.GetComponent <CharacterMovement3D>();
		if (player) {
			if (!playedSound)
			{
				soundToPlay.start();
				playedSound = true;
			}
			
			floorAnimator.SetBool("shattered",true);

			Debug.Log("shatter the floor");
		}
	}
}
