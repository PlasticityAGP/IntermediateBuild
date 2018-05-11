using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour {

public GameObject pauseMenu;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	if (Input.GetKeyDown(KeyCode.Escape))
	{
		PauseMenu();
	}
		
	}


	public void PauseMenu()
	{
		if (!pauseMenu.activeInHierarchy)
		{
			pauseMenu.SetActive(true); 

			Time.timeScale = 0;
		}

		else if (pauseMenu.activeInHierarchy)
		{
			pauseMenu.SetActive(false); 
			Time.timeScale = 1;
		}
	}

	public void Resume()
	{
		pauseMenu.SetActive(false);
		Time.timeScale = 1;
	}
}
