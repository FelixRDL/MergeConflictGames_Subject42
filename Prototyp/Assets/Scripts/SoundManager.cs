using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	//Fixed AudioSource for Background Music
	public AudioSource backgroundMusicSource;

	private const float BACKGROUND_MUSIC_VOLUME = 0.4f;

	public static SoundManager instance = null;

	void Awake ()
	{
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}

		DontDestroyOnLoad (gameObject);
	}

	public void PlayBackgroundMusic (AudioClip clip, float delay, float fadeInTime)
	{
		print ("Start Playing " + clip);
		backgroundMusicSource.volume = BACKGROUND_MUSIC_VOLUME;
		backgroundMusicSource.clip = clip;
		backgroundMusicSource.PlayDelayed (delay);
	}

	public void StopBackgroundMusic (float fadeOutTime)
	{
		backgroundMusicSource.Stop ();
	}

	public bool GetBackgroundMusicPlaying ()
	{
		if (backgroundMusicSource.isPlaying) {
			return true;
		} else {
			return false;
		}
	}

	public void PlayEffect(AudioSource effectSource, AudioClip clip, float volume) {

	}
}
