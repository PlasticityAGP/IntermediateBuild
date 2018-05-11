using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polaroid : MonoBehaviour {
	public bool hasPolaroid = false;
	public GameObject polaroids;
	public GameObject doorCollider;
	public GameObject polaroidImage;
	public GameObject screenDarkener;
	public GameObject instructionText;

	bool canvasUp;
	bool polaroidsActive = false;
	bool inPolaroidZone;

	CharacterMovement3D cM;



	// Use this for initialization
	void Start () {
		//polaroidImage.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
//		if (hasPolaroid) {
//			
//		}

		if (Input.GetKeyDown (KeyCode.LeftControl)) 
		{
			if (inPolaroidZone)
			{
				

					if (!polaroidsActive)
					{
						polaroidImage.SetActive(true);
						screenDarkener.SetActive(true);
						polaroidsActive = true;
					}
					else if (polaroidsActive)
					{
						polaroidsActive = false;
						polaroidImage.SetActive(false);
						screenDarkener.SetActive(false);
							
					}
			}
		}


		if (polaroidsActive)
		{
			cM.enabled = false; 
		}

		else if (!polaroidsActive)
		{
			cM.enabled = true; 
		}

	}

	void OnTriggerStay(Collider other)
	{
		if (!hasPolaroid)
			{
				instructionText.SetActive(true);
			}

		if (Input.GetKeyDown (KeyCode.LeftControl)) 
		{
			polaroids.SetActive (false);
			hasPolaroid = true;
			instructionText.SetActive(false);
			Destroy (doorCollider);
				
		}



			
	}


	void OnTriggerEnter(Collider other)
	{
		// setting the character movement to be the girl's.
		cM = other.GetComponent<CharacterMovement3D>();
		inPolaroidZone = true;
	}

	void OnTriggerExit(Collider other)
	{
		inPolaroidZone = false;

		instructionText.SetActive(false);
	}

	

}