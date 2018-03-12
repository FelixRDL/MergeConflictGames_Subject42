using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Idea from: https://www.youtube.com/watch?v=1NW0BYn5KfE

//The DialogueManager is responsible for playing Dialogue Audio and displaying Subtitles
public class DialogueManager : MonoBehaviour
{

	public GameObject[] speakers;
	public AudioClip[] audioSources;

	private Dictionary<string, AudioClip> audioClips;

	private const float RATE = 44100.0f;

	private AudioSource playerAudioSource;
	private AudioSource testManagerAlterEgoAudioSource;
	private AudioSource[] speakerAudioSources;

	private AudioSource audioSource;

	private List<float> subtitleTimings = new List<float> ();
	private List<string> subtitleText = new List<string> ();

	private int nextSubtitle = 0;
	private string currentSubtitle;

	private GUIStyle subtitleStyle = new GUIStyle ();

	//Singleton property
	public static DialogueManager instance = null;

	void Awake ()
	{
		InitSingleton ();
		InitAudioSources ();
		InitAudioClipDictionary ();
	}

	private void InitSingleton ()
	{
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}

		DontDestroyOnLoad (gameObject);
	}

	private void InitAudioSources ()
	{
		playerAudioSource = GameObject.FindGameObjectWithTag ("Player").GetComponent<AudioSource> ();

		if (speakers.Length > 0) {
			speakerAudioSources = new AudioSource[speakers.Length];
			for (int i = 0; i < speakers.Length; i++) {
				speakerAudioSources [i] = speakers [i].GetComponent<AudioSource> ();
			} 
		} else {
			print ("No speakers linked with the DialogueManager!");
		}
	}

	private void InitAudioClipDictionary ()
	{
		audioClips = new Dictionary<string, AudioClip> ();

		foreach (AudioClip clip in audioSources) {
			audioClips.Add (clip.name, clip);
		}
	}

	public void StartSubjectMonologue (string clipName, float volume, float delay)
	{

		//1. Prepare AudioSources
		playerAudioSource.volume = volume;
		playerAudioSource.clip = audioClips [clipName];

		audioSource = playerAudioSource;

		//2. Load subtitles from file
		initSubtitles (clipName);

		//3. Play Audio
		playerAudioSource.PlayDelayed (delay);

	}

	public void StartTestManagerMonologue (string clipName, float volume, float delay)
	{
		foreach (AudioSource source in speakerAudioSources) {
			source.volume = volume;
			source.clip = audioClips [clipName];
		}

		audioSource = speakerAudioSources[0];
			
		//2. Load subtitles from file
		initSubtitles (clipName);

		//3. Play Audio
		foreach (AudioSource source in speakerAudioSources) {
			source.PlayDelayed (delay);
		}
	}

	public void StartDialogueBetweenSubjectAndTestManager (string clipName, float subjectVolume, float testManagerVolume, float delay)
	{
		//1. Prepare AudioSources
		playerAudioSource.volume = subjectVolume;
		playerAudioSource.clip = audioClips [clipName + "_s"];

		foreach (AudioSource source in speakerAudioSources) {
			source.volume = testManagerVolume;
			source.clip = audioClips [clipName + "_v"];
		}

		audioSource = playerAudioSource;

		//2. Load subtitles from file
		initSubtitles (clipName);

		//3. Play Audio
		audioSource.PlayDelayed (delay);
		foreach (AudioSource source in speakerAudioSources) {
			source.PlayDelayed (delay);
		}
	}

	public void StartDialogueBetweenSubjectAndTestManagerAlterEgo (string clipName, float subjectVolume, float testManagerAlterEgoVolume, float delay)
	{
		//1. Prepare AudioSources
		playerAudioSource.volume = subjectVolume;
		playerAudioSource.clip = audioClips [clipName + "_s"];

		foreach (AudioSource source in speakerAudioSources) {
			source.volume = testManagerAlterEgoVolume;
			source.clip = audioClips [clipName + "_a"];
		}

		audioSource = playerAudioSource;

		//2. Load subtitles from file
		initSubtitles (clipName);

		//3. Play Audio
		audioSource.PlayDelayed (delay);
		foreach (AudioSource source in speakerAudioSources) {
			source.PlayDelayed (delay);
		}
	}



	private void initSubtitles (string clipName)
	{
		subtitleTimings = new List<float> ();
		subtitleText = new List<string> ();
		nextSubtitle = 0;

		TextAsset temp = Resources.Load ("Dialogues/" + clipName) as TextAsset;

		if (temp.text == null) {
			print ("Error in reading subtitle File");
			return;
		}

		string[] fileLines = temp.text.Split ('\n');

		for (int i = 0; i < fileLines.Length; i++) {
			string currentLine = fileLines [i];
			if (currentLine.Length == 0 || !currentLine.Contains ("|")) {
				print ("Untertiteldatei " + clipName + " falsch formatiert in Zeile: " + i + ". Enthält Zeile ein '|' ? -> " + currentLine.Contains ("|"));
				break;
			}

			string[] splittedLine = currentLine.Split ('|');
			subtitleTimings.Add (float.Parse (splittedLine [0]));
			subtitleText.Add (splittedLine [1]);
		}


		//Set first line of subtitles and play dialogue audio
		currentSubtitle = subtitleText [0];
	}

	//Catches all GUI Events, displays current subtitle line on screen.
	void OnGUI ()
	{

		//Put subtitles over everything and position on screen.
		GUI.depth = -1001;
		subtitleStyle.fixedWidth = Screen.width / 1.5f;
		subtitleStyle.wordWrap = true;
		subtitleStyle.alignment = TextAnchor.MiddleCenter;
		subtitleStyle.normal.textColor = Color.white;
		subtitleStyle.fontSize = Mathf.FloorToInt (Screen.height * 0.0225f);

		Vector2 size = subtitleStyle.CalcSize (new GUIContent ());

		//Draw with 1px white offset.
		GUI.contentColor = Color.black;
		GUI.Label (new Rect (Screen.width / 2 - size.x / 2 + 1, Screen.height / 1.2f - size.y + 1, size.x, size.y), currentSubtitle, subtitleStyle);
		GUI.contentColor = Color.white;
		GUI.Label (new Rect (Screen.width / 2 - size.x / 2, Screen.height / 1.2f - size.y, size.x, size.y), currentSubtitle, subtitleStyle);

		if (nextSubtitle < subtitleText.Count) {
			if (audioSource.timeSamples / RATE > subtitleTimings [nextSubtitle]) {
				currentSubtitle = subtitleText [nextSubtitle];
				nextSubtitle++;
			}
		}

	}

}
