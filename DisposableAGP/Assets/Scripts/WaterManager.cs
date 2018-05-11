using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterManager : MonoBehaviour {
	public GameObject water;
	// Use this for initialization
	void Start () {
		water.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		CharacterMovement3D player = other.gameObject.GetComponent <CharacterMovement3D>();
		if (player) {
			Debug.Log("Water Enabled");
			water.SetActive(true);
		}
	}

	void OnTriggerExit(Collider other)
	{
		CharacterMovement3D player = other.gameObject.GetComponent <CharacterMovement3D>();
		if (player) {
			Debug.Log("Water Disabled");
			water.SetActive(false);
	}
	}
}
