using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrigger : MonoBehaviour {

	public enum songToPlay {HOUSE,TRAILER,FARM,CITY,BEACH,};
	public songToPlay songPlaying ;

	public int zoneNumber;

	MusicPlayer mP;
	// Use this for initialization
	void Start () {

	mP = GameObject.Find("MusicManager").GetComponent<MusicPlayer>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider c)
	{

		if (c.tag == "Player")
		{
			// Whatever enum thing we are... play that song. 
			mP.currentMusicTrigger = this;
			mP.PlayCurrentZoneMusic();
		}

	}

	void OnDrawGizmos() {
        Gizmos.color = Color.green;
		Gizmos.DrawWireCube(this.transform.position, this.transform.localScale);
        }


}
