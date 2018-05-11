using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	if (Input.GetKeyDown(KeyCode.Alpha1))
	{
		player.transform.position = new Vector3 (118.14f, 0.27f, 0.1f); 
	}

		if (Input.GetKeyDown(KeyCode.Alpha2))
	{
		player.transform.position = new Vector3 (226.3f, 0.27f, 0.1f); 
	}
		
	}
}
