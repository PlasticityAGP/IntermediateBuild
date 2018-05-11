using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshFader : MonoBehaviour {
	public MeshRenderer blackOut;
	public float blackOutAlpha;

	public bool fading = false;
	public MeshFader partner;
	public float targetAlpha = 0f;
	public float fadeSpeed = 2f;
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		blackOutAlpha = blackOut.material.color.a;
		if (fading){

			blackOutAlpha = Mathf.Lerp (blackOutAlpha, targetAlpha, Time.deltaTime*fadeSpeed); 
			Color tempColor = blackOut.material.color;
			tempColor.a = blackOutAlpha;
			blackOut.material.color = tempColor;

			if (Mathf.Approximately (blackOutAlpha, targetAlpha)) {
				fading = false;
			}

		}

	}

	void OnTriggerEnter(Collider other){
		CharacterMovement3D player = other.gameObject.GetComponent <CharacterMovement3D>();
		if (player) {
			Debug.Log("i scream for fade");
			fading = true;

			if (partner) {
				partner.fading = false;
			}
		}
	}
}
