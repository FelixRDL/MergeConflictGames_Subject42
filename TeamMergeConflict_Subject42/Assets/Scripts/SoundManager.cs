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

	public void ReduceBackgroundMusicWhileDrugTrip ()
	{
		StartCoroutine (ReduceBackgroundMusicWhileDrugTripCoroutine ());
	}

	IEnumerator ReduceBackgroundMusicWhileDrugTripCoroutine ()
	{
		StartCoroutine (FadeOut (backgroundMusicSource, 0.1f, 3f, false));
		yield return new WaitForSecondsRealtime (10f);
		StartCoroutine (FadeIn (backgroundMusicSource, 1f, 3f));
	}


	IEnumerator FadeIn (AudioSource audioSource, float maxVolume, float fadeInTime)
	{
		while (audioSource.volume < maxVolume) {
			audioSource.volume += Time.deltaTime / fadeInTime;
			yield return null;
		}
	}

	IEnumerator FadeOut (AudioSource audioSource, float minVolume, float fadeOutTime, bool stopAtEnd)
	{
		while (audioSource.volume > minVolume) {
			audioSource.volume -= Time.deltaTime / fadeOutTime;
			yield return null;
		}
		if (stopAtEnd) {
			backgroundMusicSource.Stop ();
		}
	}

	public void StopBackgroundMusic (float fadeOutTime)
	{
		if (fadeOutTime == 0) {
			backgroundMusicSource.Stop ();
		} else {
			StartCoroutine (FadeOut (backgroundMusicSource, 0, fadeOutTime, true));
		}
	}


	public void PlayEffect (AudioSource effectSource, string clipName)
	{
		effectSource.clip = soundeffectClips [clipName];
		effectSource.Play ();
	}
}
