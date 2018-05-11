using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script disables and enables certain alpha masks that are slowing down the performance of our game. 

public class AlphaDisabler : MonoBehaviour {
    public GameObject[] AlphaMaskParents;
    public int CurrentZone = 0; 
	// Use this for initialization
	void Start () {
        DisableZones();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Tells this manager which player the zone is in. Called from various zone triggers
    void UpdateCurrentZone(int NewIndex)
    {
        CurrentZone = NewIndex;
        DisableZones();
    }

    //Disables all alpha masks that are not inside the current zone.
    void DisableZones()
    {
        for (int i = 0; i < AlphaMaskParents.Length; ++i)
        {
            if(i == CurrentZone)
            {
                AlphaMaskParents[i].SetActive(true);
            }
            else
            {
                AlphaMaskParents[i].SetActive(false);
            }
        }
    }
}
