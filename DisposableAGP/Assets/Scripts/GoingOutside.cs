using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoingOutside : MonoBehaviour {
	public SpriteRenderer blackOut;
	public float blackOutAlpha;

	public bool fading = false;
	public GoingOutside partner;
	public float targetAlpha = 0f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		blackOutAlpha = blackOut.color.a;
		if (fading){

			blackOutAlpha = Mathf.Lerp (blackOutAlpha, targetAlpha, Time.deltaTime); 
			Color tempColor = blackOut.color;
			tempColor.a = blackOutAlpha;
			blackOut.color = tempColor;

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
