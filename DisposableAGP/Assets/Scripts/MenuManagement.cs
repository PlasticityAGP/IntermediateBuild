using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManagement : MonoBehaviour {


	public GameObject startPanel; 
	public GameObject creditsPanel; 
	public GameObject resourcesPanel; 
	//public GameObject lightFlicker;
	public bool clicked; 
	// Use this for initialization
	void Start () {

	//controlPanel = GameObject.Find("ControlPanel"); 
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
//
//	public void SetControlPanelActive()
//	{
//		if (controlPanel.activeInHierarchy == false)
//		{
//			controlPanel.SetActive(true); 
//			startPanel.SetActive(false); 
//			lightFlicker.SetActive(true); 
//
//		}
//
//	}
//
//	public void DeactivateControlPanel()
//	{
//		if (controlPanel.activeInHierarchy == true)
//		{
//			controlPanel.SetActive(false);
//			startPanel.SetActive(true); 
//			lightFlicker.SetActive(false); 
//			print ("shut off"); 	
//
//		}
//	}


	public void SetCreditsPanelActive()
	{
		if (creditsPanel.activeInHierarchy == false)
		{
			creditsPanel.SetActive(true); 
			startPanel.SetActive(false); 

		}

	}


	public void DeactivateCreditsPanel()
	{
		if (creditsPanel.activeInHierarchy == true)
		{
			creditsPanel.SetActive(false);
			startPanel.SetActive(true); 
		//	lightFlicker.SetActive(false); 
			print ("shut off"); 	

		}
	}


	public void SetResourcesPanelActive()
	{
		if (resourcesPanel.activeInHierarchy == false)
		{
			resourcesPanel.SetActive(true); 
			startPanel.SetActive(false); 

		}

	}


	public void DeactivateResourcesPanel()
	{
		if (resourcesPanel.activeInHierarchy == true)
		{
			resourcesPanel.SetActive(false);
			startPanel.SetActive(true); 
			//	lightFlicker.SetActive(false); 
			print ("shut off"); 	

		}
	}
}
