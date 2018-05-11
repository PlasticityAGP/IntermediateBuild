using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAppear : MonoBehaviour {

public GameObject instructionalText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider c)
	{
		if (c.tag == "Player")
		{
			instructionalText.SetActive(true);
		}
	}

	void OnTriggerExit(Collider c)
	{
		if (c.tag == "Player")
		{
			instructionalText.SetActive(false);
		}
	}
}
