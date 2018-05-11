using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneTrigger : MonoBehaviour 
{
    public int ZoneID;
    public GameObject AlphaManager;
	[SerializeField]
	private Color debugBoxColor;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnDrawGizmos()
	{
		Vector3 size = GetComponent<BoxCollider> ().size;

		// fill
		Gizmos.matrix = Matrix4x4.TRS (transform.position, transform.rotation, new Vector3 (1, 1, 1));
		Gizmos.color = debugBoxColor;
		Gizmos.DrawCube (new Vector3 (0, 0, 0), size);

		// border
		Gizmos.color = Color.white;
		Gizmos.DrawWireCube (new Vector3 (0, 0, 0), size);
	}

	void OnTriggerEnter(Collider other)
	{
		CharacterMovement3D player = other.gameObject.GetComponent <CharacterMovement3D>();
		if (player) 
		{
			// register what our last zone hit is and the time
			Camera.main.GetComponent<MetricManager> ().RegisterHitZone (this, Time.time);
		}
	}

    //TODO update alpha mask manager with the current zone so that we can delete
    //alpha masks not located in our zone
    void UpdateAlphaMasks()
    {

    }
}
