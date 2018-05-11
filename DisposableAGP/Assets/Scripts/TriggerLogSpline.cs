using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLogSpline : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Platform")
        {
            Debug.Log("LOG HAS STARTED SPLINE");
            other.GetComponent<LogScript>().StartLog();
        }
    }
}
