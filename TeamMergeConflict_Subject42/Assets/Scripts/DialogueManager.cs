using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Idea from: https://www.youtube.com/watch?v=1NW0BYn5KfE

//The DialogueManager is responsible for playing Dialogue Audio and displaying Subtitles
public class DialogueManager : MonoBehaviour
{

	public GameObject[] speakers;
	public GameObject[] friends;

	//All AudioClips to be played in the current Level are collected in this Array.
	public AudioClip[] audioSources;

	private Dictionary<string, AudioClip> audioClips;

	private const float RATE = 44100.0f;

	//All AudioSources of the different Roles:
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

	private GUIStyle subtitleGUIStyle = new GUIStyle ();

	//Singleton property
	public static DialogueManager instance = null;

	void Awake ()
	{
		InitSingleton ();
		InitAudioSources ();
		InitAudioClipDictionary ();
		InitSubtitleGUIStile ();
	}

	private void InitSingleton ()
	{
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
	}

	private void InitAudioSources ()
	{
		InitPlayerAudioSource ();
		InitTestManagerAudioSources ();
		InitTestManagerAlterEgoAudioSourceAudioSource ();
		InitFriendsAudioSources ();
	}

	private void InitPlayerAudioSource () {
		playerAudioSource = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource> ();
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
			if (source.isActiveAndEnabled) {
				source.Play ();
			}
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
	//The code for positioning the subtitles has been mostly taken from the tutorial linked above.
	void OnGUI ()
	{
		DrawCurrentSubtitleOnScreen ();
		CheckSubtitleTiming ();
	}

	private void InitSubtitleGUIStile ()
	{
		//Position Subtitles on the Screen.
		subtitleGUIStyle.fixedWidth = Screen.width / 1.5f;
		subtitleGUIStyle.wordWrap = true;
		subtitleGUIStyle.alignment = TextAnchor.MiddleCenter;
		subtitleGUIStyle.normal.textColor = Color.white;
		subtitleGUIStyle.fontSize = Mathf.FloorToInt (Screen.height * 0.0225f);
	}

	private void DrawCurrentSubtitleOnScreen ()
	{
		Vector2 size = subtitleGUIStyle.CalcSize (new GUIContent ());

		//Draw the Text in black with 1 Pixel white offset.
		GUI.contentColor = Color.black;
		GUI.Label (new Rect (Screen.width / 2 - size.x / 2 + 1, Screen.height / 1.2f - size.y + 1, size.x, size.y), currentSubtitle, subtitleGUIStyle);
		GUI.contentColor = Color.white;
		GUI.Label (new Rect (Screen.width / 2 - size.x / 2, Screen.height / 1.2f - size.y, size.x, size.y), currentSubtitle, subtitleGUIStyle);
	}

	//Compares the timeSamples of the current playing audioSource using its Sample Rate to the Timestamp defined in the subtitle file.
	//If the progress is larger than the current time stamp, the next subtitle is loaded.
	private void CheckSubtitleTiming ()
	{
		if (nextSubtitle < subtitleText.Count) {
			if (audioSource.timeSamples / RATE > subtitleTimings [nextSubtitle]) {
				currentSubtitle = subtitleText [nextSubtitle];
				nextSubtitle++;
			}
		}

	}

	//Returns true or false, depending if a dialogue is currently playing
	public bool IsDialoguePlaying () {
		if (audioSource != null) {
			return audioSource.isPlaying;
		} else {
			return false;
		}
	}

}
