using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Idea from: https://www.youtube.com/watch?v=1NW0BYn5KfE

//The DialogueManager is responsible for playing Dialogue Audio and displaying Subtitles
public class DialogueManager : MonoBehaviour
{

	public GameObject[] speakers;
	public GameObject[] friends;
	public AudioClip[] audioSources;

	private Dictionary<string, AudioClip> audioClips;

	private const float RATE = 44100.0f;

	private AudioSource playerAudioSource;
	private AudioSource[] speakerAudioSources;
	private AudioSource testManagerAlterEgoAudioSource;
	private AudioSource[] friendAudioSources;

	//Main Audio Source for Control Purposes
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

		//DontDestroyOnLoad (gameObject);
	}

	private void InitAudioSources ()
	{
		InitPlayerAudioSource ();
		InitTestManagerAudioSources ();
		InitTestManagerAlterEgoAudioSourceAudioSource ();
		InitFriendsAudioSources ();
	}

	private void InitPlayerAudioSource () {
		playerAudioSource = GameObject.Find("PlayerAudioSource").GetComponent<AudioSource> ();
	}

	private void InitTestManagerAudioSources () {
		if (speakers.Length > 0) {
			speakerAudioSources = new AudioSource[speakers.Length];
			for (int i = 0; i < speakers.Length; i++) {
				speakerAudioSources [i] = speakers [i].GetComponent<AudioSource> ();
			} 
		}
	}

	private void InitTestManagerAlterEgoAudioSourceAudioSource () {
		testManagerAlterEgoAudioSource = GameObject.Find("TestManagerAlterEgoAudioSource").GetComponent<AudioSource> ();
	}

	private void InitFriendsAudioSources () {
		if (friends.Length > 0) {
			friendAudioSources = new AudioSource[friends.Length];
			for (int i = 0; i < friends.Length; i++) {
				friendAudioSources [i] = friends [i].GetComponent<AudioSource> ();
			} 
		}
	}

	private void InitAudioClipDictionary ()
	{
		audioClips = new Dictionary<string, AudioClip> ();

		foreach (AudioClip clip in audioSources) {
			audioClips.Add (clip.name, clip);
		}
	}

	//--------------------------
	//Functions for Monologues
	//--------------------------

	public void StartSubjectMonologue (string clipName)
	{
		print("AudioSource: Subject. Clip: " + clipName); 

		//1. Prepare AudioSources
		playerAudioSource.clip = audioClips [clipName];

		audioSource = playerAudioSource;

		//2. Load subtitles from file
		initSubtitles (clipName);

		//3. Play Audio
		playerAudioSource.Play ();

	}


	public void StartTestManagerMonologue (string clipName)
	{
		print("AudioSource: Speakers. Clip: " + clipName); 

		foreach (AudioSource source in speakerAudioSources) {
			source.clip = audioClips [clipName];
		}

		audioSource = speakerAudioSources [0];
			
		//2. Load subtitles from file
		initSubtitles (clipName);

		//3. Play Audio
		foreach (AudioSource source in speakerAudioSources) {
			source.Play ();
		}
	}

	public void StartTestManagerAlterEgoMonologue (string clipName) 
	{
		print("AudioSource: Alter Ego. Clip: " + clipName); 

		//1. Prepare AudioSources
		testManagerAlterEgoAudioSource.clip = audioClips [clipName];

		audioSource = testManagerAlterEgoAudioSource;

		//2. Load subtitles from file
		initSubtitles (clipName);

		//3. Play Audio
		testManagerAlterEgoAudioSource.Play ();
	}

	public void StartFriendMonologue (string clipName)
	{
		print("AudioSource: Friend. Clip: " + clipName); 

		foreach (AudioSource source in friendAudioSources) {
			if (source != null) {
				source.clip = audioClips [clipName];
			}
		}

		if (friendAudioSources [0] != null) {
			audioSource = friendAudioSources [0];
		} else if (friendAudioSources [1] != null) {
			audioSource = friendAudioSources [1];
		}


		//2. Load subtitles from file
		initSubtitles (clipName);

		//3. Play Audio
		foreach (AudioSource source in friendAudioSources) {
			if (source != null) {
				source.Play ();
			}
		}

	}

	//--------------------------
	//Functions for Dialogues
	//--------------------------

	public void StartDialogueBetweenSubjectAndTestManager (string clipName)
	{
		print("AudioSources: Subject and Speaker. Clip: " + clipName); 

		//1. Prepare AudioSources
		playerAudioSource.clip = audioClips [clipName + "_s"];

		foreach (AudioSource source in speakerAudioSources) {
			source.clip = audioClips [clipName + "_v"];
		}

		audioSource = playerAudioSource;

		//2. Load subtitles from file
		initSubtitles (clipName);

		//3. Play Audio
		audioSource.Play ();
		foreach (AudioSource source in speakerAudioSources) {
			if (source.isActiveAndEnabled) {
				source.Play ();
			}
		}
	}

	public void StartDialogueBetweenSubjectAndTestManagerAlterEgo (string clipName)
	{
		print("AudioSources: Subject and Alter Ego. Clip: " + clipName); 

		//1. Prepare AudioSources
		playerAudioSource.clip = audioClips [clipName + "_s"];

		testManagerAlterEgoAudioSource.clip = audioClips [clipName + "_a"];

		audioSource = playerAudioSource;

		//2. Load subtitles from file
		initSubtitles (clipName);

		//3. Play Audio
		audioSource.Play ();
		testManagerAlterEgoAudioSource.Play ();
	}

	public void StartDialogueBetweenSubjectAndFriend (string clipName)
	{
		print("AudioSourcse: Subject and Friend. Clip: " + clipName); 

		//1. Prepare AudioSources
		playerAudioSource.clip = audioClips [clipName + "_s"];

		foreach (AudioSource source in friendAudioSources) {
			if (source != null) {
				source.clip = audioClips [clipName + "_f"];
			}
		}

		audioSource = playerAudioSource;

		//2. Load subtitles from file
		initSubtitles (clipName);

		//3. Play Audio
		audioSource.Play ();
		foreach (AudioSource source in friendAudioSources) {
			if (source != null) {
				source.Play ();
			}
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
				print ("Untertiteldatei " + clipName + " falsch formatiert in Zeile: " + i + ". Enthält Zeile kein '|' oder handelt es sich um eine leere Zeile?");
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

		//Position Subtitles on the Screen.
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

	public bool IsDialoguePlaying () {
		if (audioSource != null) {
			return audioSource.isPlaying;
		} else {
			return false;
		}
	}

}
