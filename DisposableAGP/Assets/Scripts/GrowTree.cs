using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowTree : MonoBehaviour {

    public GameObject Tree;
    public float HeightChange;
    public float LerpRate;
    private bool inspected;
    private bool BeginLerp = false;
    private bool EndLerp = false;
    private float BLerpT = 0.0f;
    private float ELerpT = -2.5f;
    private Vector3 EndPosition;
    private Vector3 BeginPosition;

    // Use this for initialization
    void Start ()
    {
        BeginPosition.x = Tree.transform.localPosition.x;
        BeginPosition.y = Tree.transform.localPosition.y;
        BeginPosition.z = Tree.transform.localPosition.z;
        EndPosition = BeginPosition;
        EndPosition.y += HeightChange;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Start lerping the tree upwards to its final destination
        if (BeginLerp)
        {
            BLerpT += LerpRate * Time.deltaTime;
            Tree.transform.localPosition = Vector3.Lerp(BeginPosition, EndPosition, BLerpT);
            if (BLerpT >= 1.0f)
            {
                BeginLerp = false;
                BLerpT = 0.0f;
            }
        }
        //Lerp the tree downward to its initial position
        if (EndLerp)
        {
            ELerpT += LerpRate * Time.deltaTime;
            if(ELerpT >= 0.0f)
            {
                Tree.transform.localPosition = Vector3.Lerp(EndPosition, BeginPosition, ELerpT);
            }
            if (ELerpT >= 1.0f)
            {
                EndLerp = false;
                ELerpT = -2.5f;
            }
        }
    }
    //called by the Inspection script
    public void OnInspectBegin()
    {
        BeginLerp = true;
    }

    //called by the Inspection script
    public void OnInspectEnd()
    {
        EndLerp = true;
    }
}
