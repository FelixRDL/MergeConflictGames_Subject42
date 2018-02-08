using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{

	public AudioSource effectSource;
	public AudioSource backgroundMusicSource;
	public AudioSource testManagerSource;
	public AudioSource subjectSource;
	public AudioSource combinedDialogueSource;

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

	public void PlayEffect (AudioClip clip)
	{
		print ("Play Soundeffect!");
		effectSource.clip = clip;
		effectSource.Play ();
	}

	public void PlayEffect (AudioClip clip, float delay)
	{
		print ("Play Soundeffect!");
		effectSource.clip = clip;
		effectSource.PlayDelayed (delay);
	}

	public void PlayBackgroundMusic (AudioClip clip, float delay)
	{
		print ("Play Background music!");
		backgroundMusicSource.volume = 0.4f;
		backgroundMusicSource.clip = clip;
		backgroundMusicSource.PlayDelayed (delay);
	}

	public void StopBackgroundMusic ()
	{
		backgroundMusicSource.Stop ();
	}

	public void PlayCombinedDialogue (AudioClip clip, float delay)
	{
		print ("Play Combined Dialogue!");
		combinedDialogueSource.clip = clip;
		combinedDialogueSource.PlayDelayed (delay);
	}


	public void PlayTestManagerDialogue (AudioClip clip, float delay)
	{
		print ("Play TestManager Dialogue!");
		testManagerSource.clip = clip;
		testManagerSource.PlayDelayed (delay);
	}

	public void PlaySubjectDialogue (AudioClip clip, float delay)
	{
		print ("Play Subject Dialogue!");
		subjectSource.clip = clip;
		subjectSource.PlayDelayed (delay);
	}

	public bool GetDialoguePlaying ()
	{
		if (combinedDialogueSource.isPlaying || testManagerSource.isPlaying || subjectSource.isPlaying) {
			return true;
		} else {
			return false;
		}
	}


}
