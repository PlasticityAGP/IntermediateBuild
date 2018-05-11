using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpZScript : MonoBehaviour {
    public float PlatY = 1.65f;
    public float PlatZ = 2.2f;
    private float LaneY;
    private float LaneZ;
    private Vector3 BeginPosition;
    private Vector3 EndPosition;
    private Vector3 ExitPositionEnd;
    private Vector3 ExitPositionBegin;
    private float LerpT = 0.0f;
    private float ELerpT = 0.0f;
    private bool LimitJump = false;
    private bool BackToLane = false;
    private Collider PlayerRef;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        /* if we exit trigger volume, head back to original z distance via lerp */
        if (BackToLane)
        {
            LeavingTrigger(Time.deltaTime);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            LaneY = other.transform.position.y;
            LaneZ = other.transform.position.z;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerRef = other;
        BackToLane = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (other.GetComponent<CharacterMovement3D>().AmJumping && !LimitJump)
            {
                LerpT += Time.deltaTime;
                BeginPosition = other.transform.position;
                EndPosition = BeginPosition;
                EndPosition.z = PlatZ;
                EndPosition.y = PlatY;
                other.transform.position = Vector3.Lerp(BeginPosition, EndPosition, LerpT);

                float checkif = (BeginPosition - EndPosition).magnitude;

                if (LerpT >= 1.0f)
                {
                    LerpT = 0.0f;
                    LimitJump = true;
                }

                if (checkif <= 0.1f)
                {
                    LerpT = 0.0f;
                    LimitJump = true;
                }

            }
        }
    }

    private void LeavingTrigger(float DeltaTime)
    {
        float InitialZ = PlayerRef.transform.position.z;
        float DeltaZ = LaneZ - InitialZ;
        
        if (Mathf.Abs(DeltaZ) <= 0.0001)
        {
            BackToLane = false;
        }
        DeltaZ *= (DeltaTime*5);
        Vector3 storage;
        storage.x = 0.0f;
        storage.y = 0.0f;
        storage.z = DeltaZ;
        PlayerRef.transform.Translate(storage);
    }
}
