using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogScript : MonoBehaviour {
    public GameObject[] SplinePoints;
    public float[] SecondsPerSection;
    private int CurrentIndex = 0;
    private Vector3 StartPosition;
    private Quaternion StartRotation;
    private float LerpT = 0.0f;
    private bool Done;
    private int TimesPressed = 0;

    /* Use this for initialization */
    void Start()
    {
        Done = true;
    }

    /* Update is called once per frame */
    void Update()
    {
        /* The done boolean is how we know if we did it */
        if (!Done)
        {
            MoveLog(Time.deltaTime);
        }
        /* DEBUG, this is just to test to see if we can initiate barrel rolling on a button press */
    }


    /* Called in update, does a lerp between GameObjects in SplinePoints */
    void MoveLog(float DeltaTime)
    {
        Vector3 pos = Vector3.Lerp(StartPosition, SplinePoints[CurrentIndex].transform.position, LerpT);
        Quaternion rot = Quaternion.Lerp(StartRotation, SplinePoints[CurrentIndex].transform.rotation, LerpT);
        this.transform.SetPositionAndRotation(pos, rot);
        LerpT += (DeltaTime / SecondsPerSection[CurrentIndex]);
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
        if (++CurrentIndex >= SplinePoints.Length)
        {
            Done = true;
        }
        else
        {
            LerpT = 0.0f;
            StartPosition = this.transform.position;
            StartRotation = this.transform.rotation;
        }
    }

    /* Starts rolling the ball, and is limited to being called once. */
    public void StartLog()
    {
        if (TimesPressed++ == 0)
        {
            StartPosition = this.transform.position;
            StartRotation = this.transform.rotation;
            Done = false;
            this.GetComponent<PullableObject>().DisablePulling();
            Destroy(this.GetComponent<Rigidbody>());
        }
    }
}
