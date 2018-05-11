using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelScript : MonoBehaviour
{
    public GameObject[] SplinePoints;
    public float[] SecondsPerSection;
    public GameObject BMesh;
    public Vector3 BMeshRotation;
    private int CurrentIndex = 0;
    private Vector3 StartPosition;
    private float LerpT = 0.0f;
    private bool Done;
    private int TimesPressed = 0;

    /* Use this for initialization */
    void Start()
    {
        Done = true;
        StartPosition = this.transform.position;
    }

    /* Update is called once per frame */
    void Update()
    {
        /* The done boolean is how we know if we did it */
        if (!Done)
        {
            MoveBarrel(Time.deltaTime);
        }
        /* DEBUG, this is just to test to see if we can initiate barrel rolling on a button press */
        if (Input.GetKey(KeyCode.I))
        {
            StartBRoll();
        }
    }


    /* Called in update, does a lerp between GameObjects in SplinePoints */
    void MoveBarrel(float DeltaTime)
    {
        BMesh.transform.Rotate(BMeshRotation);   
        Vector3 pos = Vector3.Lerp(StartPosition, SplinePoints[CurrentIndex].transform.position, LerpT);
        this.transform.SetPositionAndRotation(pos, this.transform.rotation);
        LerpT += (DeltaTime/SecondsPerSection[CurrentIndex]);
        if (LerpT >= 1.0f)
        {
            LerpT = 0.0f;
            NextPoint();
        }

    }

    /* Is called once we have finished one of the sections in the spline path. Increments the index
    in the pline path, and if out of the array range, ends the movement of the barral. */
    void NextPoint()
    {
        if(++CurrentIndex >= SplinePoints.Length)
        {
            Done = true;
        }
        else
        {
            LerpT = 0.0f;
            StartPosition = this.transform.position;
        }
    }

    /* Starts rolling the ball, and is limited to being called once. */
    void StartBRoll()
    {
        if(TimesPressed++ == 0)
        {
            Done = false;
        }
    }
}
