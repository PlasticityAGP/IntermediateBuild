using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceSound : MonoBehaviour {

public FMOD.Studio.EventInstance eventIns; 
public string eventPath;
	// Use this for initialization
	void Start () {

		eventIns = FMODUnity.RuntimeManager.CreateInstance("event:/" + eventPath);
	FMODUnity.RuntimeManager.AttachInstanceToGameObject(eventIns,gameObject.transform,gameObject.GetComponent<Rigidbody>()); 

	eventIns.start(); 

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(gameObject.transform.position,1f);
	}
}
