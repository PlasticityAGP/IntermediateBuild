using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoading : MonoBehaviour {
	public int SceneNumber;
	public Image blackOut; 

	bool clickedStart;
	public bool startLoaded;


	// THIS CODE IS DISGRACEFULLY MESSY BUT IT WORKS
	void Awake()
	{
		blackOut = GameObject.Find("BlackOut").GetComponent<Image>(); 
	}
	// Use this for initialization
	void Start () {

	// so we only have one scenemanager
	DontDestroyOnLoad(gameObject);
	// setting currently loaded scene 
		SceneManager.sceneLoaded += OnSceneLoaded;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		LoadingScene ();

		if (clickedStart)
		{
			blackOut.color = Color.Lerp (blackOut.color, Color.black, Time.deltaTime* 5f);
		}

		if (startLoaded)
		{
			blackOut.color = Color.Lerp (blackOut.color, Color.clear, Time.deltaTime* 10f);
		}
	}

	public void LoadingScene (){
		if (Input.GetKeyDown (KeyCode.C)) {
			SceneManager.LoadScene (SceneNumber);
		}
	}


	public void ChangeThatScene()
	{
		SceneManager.LoadScene(SceneNumber); 
	}


	// This function is to let things fade out before we start the actual game. 
	public IEnumerator WaitToChangeScenes()
	{
		clickedStart = true; 
		yield return new WaitForSeconds (2f);

		ChangeThatScene(); 
	}


	public void PrettySceneTransition()
	{
		StartCoroutine("WaitToChangeScenes");
	}

	// When you first load a scene, this is how you get tstuff to happen immediately. 
	void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		blackOut = GameObject.Find("BlackOut").GetComponent<Image>(); 
		startLoaded = true;
	}
}
