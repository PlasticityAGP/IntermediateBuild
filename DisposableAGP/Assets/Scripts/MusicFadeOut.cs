using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicFadeOut : MonoBehaviour {

	MusicPlayer mP;
	// Use this for initialization
	void Start () {

		mP = GameObject.Find("MusicManager").GetComponent<MusicPlayer>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerExit(Collider c)
	{
		if (c.tag == "Player")
		{
			mP.FadeCurrentZoneMusic();
			print ("fading current song");
		}
	}


	void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(this.transform.position, this.transform.localScale);
        }
}
