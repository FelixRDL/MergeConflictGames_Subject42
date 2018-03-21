using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

	//Fixed AudioSource for Background Music
	private AudioSource backgroundMusicSource;

	//Public Arrays for adding all Soundeffects and BackgroundMusic Files to the SoundManager directly from the Inspector
	public AudioClip[] backgroundMusicSources;
	public AudioClip[] soundeffectSources;


	private Dictionary<string, AudioClip> backgroundMusicClips;
	private Dictionary<string, AudioClip> soundeffectClips;

	public static SoundManager instance = null;

	void Awake ()
	{
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}

		//DontDestroyOnLoad (gameObject);

		backgroundMusicSource = GetComponent<AudioSource> ();
		createBackgroundMusicDictionary ();
		createSoundeffectDictionary ();
	}

	private void createBackgroundMusicDictionary ()
	{
		backgroundMusicClips = new Dictionary<string, AudioClip> ();

		foreach (AudioClip clip in backgroundMusicSources) {
			backgroundMusicClips.Add (clip.name, clip);
		}
	}

	private void createSoundeffectDictionary ()
	{
		soundeffectClips = new Dictionary<string, AudioClip> ();

		foreach (AudioClip clip in soundeffectSources) {
			soundeffectClips.Add (clip.name, clip);
		}
	}


	public void PlayBackgroundMusicLoop (string clipName, float maxVolume, float fadeInTime)
	{
		backgroundMusicSource.clip = backgroundMusicClips [clipName];
		backgroundMusicSource.volume = 0;
		backgroundMusicSource.Play ();

		if (fadeInTime == 0) {
			backgroundMusicSource.volume = maxVolume;
		} else {
			StartCoroutine (FadeIn (backgroundMusicSource, maxVolume, fadeInTime));
		}
	}

	IEnumerator FadeIn (AudioSource audioSource, float maxVolume, float fadeInTime)
	{
		while (audioSource.volume < maxVolume) {
			audioSource.volume += Time.deltaTime / fadeInTime;
			yield return null;
		}
	}

	IEnumerator FadeOut (AudioSource audioSource, float fadeInTime)
	{
		while (audioSource.volume > 0) {
			audioSource.volume -= Time.deltaTime / fadeInTime;
			yield return null;
		}
		backgroundMusicSource.Stop ();
	}

	public void StopBackgroundMusic (float fadeOutTime)
	{
		if (fadeOutTime == 0) {
			backgroundMusicSource.Stop ();
		} else {
			StartCoroutine (FadeOut (backgroundMusicSource, fadeOutTime));
		}



	}
		

	public void PlayEffect (AudioSource effectSource, string clipName, float volume)
	{
		print ("Start Playing " + clipName);

		AudioSource source = effectSource;
		source.volume = volume;
		source.clip = soundeffectClips [clipName];
		source.Play ();
	}
}
