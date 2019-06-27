using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour 
{
	public AudioSource efxSource;                   //Drag a reference to the audio source which will play the sound effects.
	public AudioSource musicSource;                 //Drag a reference to the audio source which will play the music.
	public static SoundManager instance = null;     //Allows other scripts to call functions from SoundManager.             
	public float lowPitchRange = .95f;              //The lowest a sound effect will be randomly pitched.
	public float highPitchRange = 1.05f;            //The highest a sound effect will be randomly pitched.

	public AudioClip shoot,destroy,warp,star,arrive,orbitshoot;
	public AudioClip lobby,ingame;
    public bool checkstory = false;
	void Awake ()
	{
		//Check if there is already an instance of SoundManager
		if (instance == null)
			//if not, set it to this.
			instance = this;
		//If instance already exists:
		else if (instance != this)
			//Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
			Destroy (gameObject);

		//Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
		DontDestroyOnLoad (gameObject);
	}

	public void LobbyMusic()
	{
		musicSource.clip = lobby;
		musicSource.Play ();
	}
	public void IngameMusic()
	{
		musicSource.clip = ingame;
		musicSource.Play ();
        checkstory = true;
	}


	//Used to play single sound clips.
	public void PlayStar()
	{//Choose a random pitch to play back our clip at between our high and low pitch ranges.
		float randomPitch = Random.Range(lowPitchRange, highPitchRange);

		//Set the pitch of the audio source to the randomly chosen pitch.
		efxSource.pitch = randomPitch;
		//Set the clip of our efxSource audio source to the clip passed in as a parameter.
		efxSource.clip = star ;

		//Play the clip.
		efxSource.Play ();
	}
    public void PlayOrbitShoot()
    {//Choose a random pitch to play back our clip at between our high and low pitch ranges.
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);

        //Set the pitch of the audio source to the randomly chosen pitch.
        efxSource.pitch = randomPitch;
        //Set the clip of our efxSource audio source to the clip passed in as a parameter.
        efxSource.clip = orbitshoot;

        //Play the clip.
        efxSource.Play();
    }
    public void PlayDestroy()
	{//Choose a random pitch to play back our clip at between our high and low pitch ranges.
		float randomPitch = Random.Range(lowPitchRange, highPitchRange);

		//Set the pitch of the audio source to the randomly chosen pitch.
		efxSource.pitch = randomPitch;
		//Set the clip of our efxSource audio source to the clip passed in as a parameter.
		efxSource.clip = destroy;

		//Play the clip.
		efxSource.Play ();
	}
	public void PlayArrive()
	{//Choose a random pitch to play back our clip at between our high and low pitch ranges.
		float randomPitch = Random.Range(lowPitchRange, highPitchRange);

		//Set the pitch of the audio source to the randomly chosen pitch.
		efxSource.pitch = randomPitch;
		//Set the clip of our efxSource audio source to the clip passed in as a parameter.
		efxSource.clip = arrive;

		//Play the clip.
		efxSource.Play ();
	}
	public void PlayWarp()
	{//Choose a random pitch to play back our clip at between our high and low pitch ranges.
		float randomPitch = Random.Range(lowPitchRange, highPitchRange);

		//Set the pitch of the audio source to the randomly chosen pitch.
		efxSource.pitch = randomPitch;
		//Set the clip of our efxSource audio source to the clip passed in as a parameter.
		efxSource.clip = warp;

		//Play the clip.
		efxSource.Play ();
	}
	public void PlayShoot()
	{//Choose a random pitch to play back our clip at between our high and low pitch ranges.
		float randomPitch = Random.Range(lowPitchRange, highPitchRange);

		//Set the pitch of the audio source to the randomly chosen pitch.
		efxSource.pitch = randomPitch;
		//Set the clip of our efxSource audio source to the clip passed in as a parameter.
		efxSource.clip = shoot;

		//Play the clip.
		efxSource.Play ();
	}



}