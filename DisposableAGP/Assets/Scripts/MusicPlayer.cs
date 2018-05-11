using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

	bool mainMenu;

	public bool firstSong;

	public MusicTrigger currentMusicTrigger;
	public FMOD.Studio.EventInstance menuMusicIns;
	// Have the music triggers be numbered.... and let them have specific behaviors that way. 

	public FMOD.Studio.EventInstance houseMusic;
	public FMOD.Studio.EventInstance beachMusic;
	public FMOD.Studio.EventInstance farmMusic;
	public FMOD.Studio.EventInstance freewayMusic;
	public FMOD.Studio.EventInstance zone1Music;
	public FMOD.Studio.EventInstance aptMusic;
	public FMOD.Studio.EventInstance cityMusic;
	public FMOD.Studio.EventInstance softbeachMusic;


	public FMOD.Studio.EventInstance cityJake;
	public FMOD.Studio.EventInstance highwayJake;

	int currentSongPlaying;


	// Use this for initialization
	void Start () {



	menuMusicIns = FMODUnity.RuntimeManager.CreateInstance("event:/MainMenuMusic");
	houseMusic = FMODUnity.RuntimeManager.CreateInstance("event:/HouseMusic");
	zone1Music = FMODUnity.RuntimeManager.CreateInstance("event:/Zone1Noise");
	farmMusic = FMODUnity.RuntimeManager.CreateInstance("event:/FarmAmbience");
	freewayMusic = FMODUnity.RuntimeManager.CreateInstance("event:/FreewayAmbience");
	aptMusic = FMODUnity.RuntimeManager.CreateInstance("event:/Apartment");
	cityMusic = FMODUnity.RuntimeManager.CreateInstance("event:/City");
	beachMusic = FMODUnity.RuntimeManager.CreateInstance("event:/OceanAmbienceAndMusic");
	softbeachMusic = FMODUnity.RuntimeManager.CreateInstance("event:/OceanAmbienceNoMusic");

	cityJake = FMODUnity.RuntimeManager.CreateInstance("event:/CityMusic");
	highwayJake = FMODUnity.RuntimeManager.CreateInstance("event:/HighwayMusic");


	if (mainMenu)
	{
		PlayMainMenuMusic(); 
	}

	// If the current number is just zero... which it starts at by default... 
		if (firstSong)
		{
			houseMusic.start();
			print ("playingMusic");
		}
		 
	}
	
	// Update is called once per frame
	void Update () {

		
		//PlayCurrentZoneMusic();
		
		
	}

	void PlayMainMenuMusic()
	{
		menuMusicIns.start(); 
	}

	public void StopMainMenuMusic()
	{
		menuMusicIns.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT); 
	}


	public void PlayCurrentZoneMusic()
	{
		Debug.Log(currentMusicTrigger.zoneNumber);
		if (currentMusicTrigger.zoneNumber == 0)
		{
			//houseMusic.start();
			print ("playingMusic");
		}


		// Farm
		else if (currentMusicTrigger.zoneNumber == 2)
		{
			zone1Music.start();
			highwayJake.start();
			print ("playingMusic");
		}

		// Farm
		else if (currentMusicTrigger.zoneNumber == 3)
		{
			farmMusic.start();
			print ("playingMusic");
		}

		// Farm
		else if (currentMusicTrigger.zoneNumber == 4)
		{
			freewayMusic.start();
			cityJake.start();

		}

		else if (currentMusicTrigger.zoneNumber == 5)
		{
			aptMusic.start();

		}

		else if (currentMusicTrigger.zoneNumber == 6)
		{
			cityMusic.start();

		}


		// BEACH
		else if (currentMusicTrigger.zoneNumber == 7)
		{
			beachMusic.start();
		
		}
	}


	public void FadeCurrentZoneMusic()
	{
		if (currentMusicTrigger.zoneNumber == 0)
		{
			houseMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
			firstSong = false;
		}


		// Farm
		else if (currentMusicTrigger.zoneNumber == 2)
		{
			zone1Music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);

		}

		// Farm
		else if (currentMusicTrigger.zoneNumber == 3)
		{
			farmMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
			highwayJake.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);

		}

	
		else if (currentMusicTrigger.zoneNumber == 4)
		{
			freewayMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);

		}


		else if (currentMusicTrigger.zoneNumber == 5)
		{
			aptMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);

		}

		else if (currentMusicTrigger.zoneNumber == 6)
		{
			cityMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
			cityJake.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);

		}

		// BEACH
		else if (currentMusicTrigger.zoneNumber == 7
		)
		{
			beachMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);

		}


	}
}
