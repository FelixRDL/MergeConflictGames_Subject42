using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class is responsible for playing all Soundeffects and the Background Music
public class SoundManager : MonoBehaviour
{

	//Fixed AudioSource for Background Music
	private AudioSource backgroundMusicSource;

	//Public Arrays for adding all Soundeffects and BackgroundMusic Files to the SoundManager directly from the Inspector
	public AudioClip[] backgroundMusicSources;
	public AudioClip[] soundeffectSources;

	//Dictionaries containing all Soundeffects and BackgroundMusic Files and their names
	private Dictionary<string, AudioClip> backgroundMusicClips;
	private Dictionary<string, AudioClip> soundeffectClips;

	//Singleton property
	public static SoundManager instance = null;

	void Awake ()
	{
		InitSingleton ();
		InitAudioSources ();
		CreateBackgroundMusicDictionary ();
		CreateSoundeffectDictionary ();
	}

	//Create an Instance of the Singleton
	private void InitSingleton ()
	{
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
	}

	//Init the AudioSources needed by the SoundManager
	private void InitAudioSources ()
	{
		backgroundMusicSource = GetComponent<AudioSource> ();
	}

	//Create a dictionary containing all Background Music files and their name as a key
	private void CreateBackgroundMusicDictionary ()
	{
		backgroundMusicClips = new Dictionary<string, AudioClip> ();

		foreach (AudioClip clip in backgroundMusicSources) {
			backgroundMusicClips.Add (clip.name, clip);
		}
	}

	//Create a dictionary containing all Soundeffect files and their name as a key
	private void CreateSoundeffectDictionary ()
	{
		soundeffectClips = new Dictionary<string, AudioClip> ();

		foreach (AudioClip clip in soundeffectSources) {
			soundeffectClips.Add (clip.name, clip);
		}
	}

	//Play a Background Music clip in a loop. Can be faded in by providing a fadeInTime
	public void PlayBackgroundMusicLoop (string clipName, float maxVolume, float fadeInTime)
	{
		//1. Preprare the AudioSource
		backgroundMusicSource.clip = backgroundMusicClips [clipName];
		backgroundMusicSource.volume = 0;
		backgroundMusicSource.Play ();

		//FadeIn or directly play the AudioClip
		if (fadeInTime == 0) {
			backgroundMusicSource.volume = maxVolume;
		} else {
			StartCoroutine (FadeIn (backgroundMusicSource, maxVolume, fadeInTime));
		}
	}

	//A Corourtine that allows an AudioClip to be faded in
	IEnumerator FadeIn (AudioSource audioSource, float maxVolume, float fadeInTime)
	{
		while (audioSource.volume < maxVolume) {
			audioSource.volume += Time.deltaTime / fadeInTime;
			yield return null;
		}
	}

	//A Corourtine that allows an AudioClip to be faded out
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

	//Stops/FadesOut the currently playing Background music
	public void StopBackgroundMusic (float fadeOutTime)
	{
		if (fadeOutTime == 0) {
			backgroundMusicSource.Stop ();
		} else {
			StartCoroutine (FadeOut (backgroundMusicSource, 0, fadeOutTime, true));
		}
	}

	//Plays an Effect sound using the provided AudioSource (the GameObject that should make a sound)
	public void PlayEffect (AudioSource effectSource, string clipName)
	{
		effectSource.clip = soundeffectClips [clipName];
		effectSource.Play ();
	}
}
