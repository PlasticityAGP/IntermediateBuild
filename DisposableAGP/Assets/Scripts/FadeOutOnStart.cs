using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class FadeOutOnStart : MonoBehaviour {

public float fadeSpeed;
//public CinemachineVirtualCamera cam;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

//		cam.m_Lens.FieldOfView = cam.m_Lens.FieldOfView + 0.05f;
		gameObject.GetComponent<Image>().color = new Color(0,0,0, (gameObject.GetComponent<Image>().color.a - fadeSpeed));

		
	}
}
