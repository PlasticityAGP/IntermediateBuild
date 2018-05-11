using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraZoomTrigger : MonoBehaviour {

// This is the camera we will be controlling. For us, it's the player FollowCam. 
	public CinemachineVirtualCamera cam;


	public bool moveCamera;
	public bool resetCamera;
	public bool yShouldMove;
	float startingCameraDistance;

	public float cameraDistance;
	public float yMovement;
	public float xMovement;

	// Use this for initialization
	void Start () {

	cam = GameObject.Find("CinemachineFollowCam").GetComponent<CinemachineVirtualCamera>();
	startingCameraDistance = cam.GetCinemachineComponent<CinemachineFramingTransposer>().m_CameraDistance;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnDrawGizmos()
	{	
		Gizmos.color = Color.cyan;
		Gizmos.DrawWireCube(transform.position, this.transform.localScale);
	
	}

	void OnTriggerEnter(Collider c)
	{
		if (moveCamera)
		{
			if (c.tag == "Player")
			{
					//cam.m_Lens.FieldOfView = fieldOfView;

					cam.GetCinemachineComponent<CinemachineFramingTransposer>().m_CameraDistance = cameraDistance;

					if (yShouldMove)
					{
						cam.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenY = yMovement;
					}
			}
		}


		if (resetCamera)
		{
			if (c.tag == "Player")
			{
					//cam.m_Lens.FieldOfView = fieldOfView;

					cam.GetCinemachineComponent<CinemachineFramingTransposer>().m_CameraDistance = startingCameraDistance;
			}
		}

	}

//	void OnTriggerExit (Collider c)
//	{
//		
//	}
}
