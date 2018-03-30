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

	//A dictionary of all audio files to be played during the game
	private Dictionary<string, AudioClip> audioClips;

	//The sampling frequency rate of the audio files. Needed for the timing of subtitle files
	private const float RATE = 44100.0f;

	//All AudioSources of the different Roles:
	private AudioSource playerAudioSource;
	private AudioSource[] speakerAudioSources;
	private AudioSource testManagerAlterEgoAudioSource;
	private AudioSource[] friendAudioSources;

	//Main Audio Source for Control Purposes (subtitle timing, active dialogues)
	private AudioSource audioSource;

	//The subtitle strings and timings for the active Dialogue are saved in the following two Lists
	private List<float> subtitleTimings = new List<float> ();
	private List<string> subtitleText = new List<string> ();

	//The current pos in the subtitleTimings and subtitleText Lists gets saved in its own variable
	private int nextSubtitle = 0;

	//This variable holds the currently displayed subtitle string.
	private string currentSubtitle;

	//This GUIStyle holds the definition for the appearance of the subtitles on sceen
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

	//Create an Instance of the Singleton
	private void InitSingleton ()
	{
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
	}

	//Intit the AudioSources.
	private void InitAudioSources ()
	{
		InitPlayerAudioSource ();
		InitTestManagerAudioSources ();
		InitTestManagerAlterEgoAudioSourceAudioSource ();
		InitFriendsAudioSources ();
	}

	//The AudioSource of the Player is the AudioSource attached to the Player GameObject itself
	private void InitPlayerAudioSource ()
	{
		playerAudioSource = GameObject.FindGameObjectWithTag ("Player").GetComponent<AudioSource> ();
	}

	//The AudioSources of the TestManager are the Speakers placed on the Ceilings in Level 1 or on the Walls of
	//the hospital building in Level 2
	private void InitTestManagerAudioSources ()
	{
		if (speakers.Length > 0) {
			speakerAudioSources = new AudioSource[speakers.Length];
			for (int i = 0; i < speakers.Length; i++) {
				speakerAudioSources [i] = speakers [i].GetComponent<AudioSource> ();
			} 
		}
	}

	//The AudioSource of the TestManagerAlterEgo is an AudioSource attached to the player itself
	//This gives the impression of the audio coming out of the players head
	private void InitTestManagerAlterEgoAudioSourceAudioSource ()
	{
		testManagerAlterEgoAudioSource = GameObject.Find ("TestManagerAlterEgoAudioSource").GetComponent<AudioSource> ();
	}

	//Every instance of the Friend in Level 2 has an AudioSource attached to it.
	private void InitFriendsAudioSources ()
	{
		if (friends.Length > 0) {
			friendAudioSources = new AudioSource[friends.Length];
			for (int i = 0; i < friends.Length; i++) {
				friendAudioSources [i] = friends [i].GetComponent<AudioSource> ();
			} 
		}
	}

	//Creates a Dictionary out of all Audio Files. If you later want to get the audio file 1_01.wav,
	//you just need to search the dictionary for "1_01"
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

	//When only the Subject is talking
	public void StartSubjectMonologue (string clipName)
	{
		//1. Prepare AudioSources
		playerAudioSource.clip = audioClips [clipName];
		audioSource = playerAudioSource;

		//2. Load subtitles from file
		initSubtitles (clipName);

		//3. Play Audio
		playerAudioSource.Play ();

	}

	//When only the TestManager is talking
	public void StartTestManagerMonologue (string clipName)
	{
		//1. Prepare AudioSources
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

	//When only the TestManagerAlterEgo is talking
	public void StartTestManagerAlterEgoMonologue (string clipName)
	{
		//1. Prepare AudioSources
		testManagerAlterEgoAudioSource.clip = audioClips [clipName];
		audioSource = testManagerAlterEgoAudioSource;

		//2. Load subtitles from file
		initSubtitles (clipName);

		//3. Play Audio
		testManagerAlterEgoAudioSource.Play ();
	}

	//When only the Friend is talking
	public void StartFriendMonologue (string clipName)
	{
		//1. Prepare AudioSources
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
			if (source.isActiveAndEnabled) {
				source.Play ();
			}
		}

	}

	//--------------------------
	//Functions for Dialogues
	//--------------------------

	//A Dialogue between the Subject and the TestManager
	public void StartDialogueBetweenSubjectAndTestManager (string clipName)
	{
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

	//A Dialogue between the Subject and the TestManagerAlterEgo
	public void StartDialogueBetweenSubjectAndTestManagerAlterEgo (string clipName)
	{
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

	//A Dialogue between the Subject and the Friend
	public void StartDialogueBetweenSubjectAndFriend (string clipName)
	{
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
			if (source.isActiveAndEnabled) {
				source.Play ();
			}
		}
	}

	//--------------------------------------------------
	//Functions for getting the subtitles on the Screen
	//--------------------------------------------------

	private void initSubtitles (string clipName)
	{
		ResetSubtitles ();

		//Read in the subtitle file for the current Dialouge as a TestAsset
		TextAsset temp = Resources.Load ("Dialogues/" + clipName) as TextAsset;

		//If the subtitle file is not existant
		if (temp.text == null) {
			return;
		}

		//Split the subtitle file by each new line
		string[] fileLines = temp.text.Split ('\n');

		for (int i = 0; i < fileLines.Length; i++) {
			string currentLine = fileLines [i];
			if (currentLine.Length == 0 || !currentLine.Contains ("|")) {
				break;
			}

			//Spilt each line by the Separator "|" and fill the lists with the values 
			string[] splittedLine = currentLine.Split ('|');
			subtitleTimings.Add (float.Parse (splittedLine [0]));
			subtitleText.Add (splittedLine [1]);
		}


		//Set first line of subtitles and play dialogue audio
		currentSubtitle = subtitleText [0];
	}

	//Resets the Values of the previous Dialogue
	private void ResetSubtitles ()
	{
		subtitleTimings = new List<float> ();
		subtitleText = new List<string> ();
		nextSubtitle = 0;
	}

	//Displays current subtitle line on screen.
	void OnGUI ()
	{
		DrawCurrentSubtitleOnScreen ();
		CheckSubtitleTiming ();
	}

	//The code for positioning the subtitles in this function has been mostly taken from the tutorial linked above.
	private void InitSubtitleGUIStile ()
	{
		subtitleGUIStyle.fixedWidth = Screen.width / 1.5f;
		subtitleGUIStyle.wordWrap = true;
		subtitleGUIStyle.alignment = TextAnchor.MiddleCenter;
		subtitleGUIStyle.normal.textColor = Color.white;
		subtitleGUIStyle.fontSize = Mathf.FloorToInt (Screen.height * 0.0225f);
	}

	//The currently active subtitle String gets displayed on screen.
	private void DrawCurrentSubtitleOnScreen ()
	{
		Vector2 size = subtitleGUIStyle.CalcSize (new GUIContent ());

		//Draw the Text in black with 1 Pixel white offset.
		GUI.contentColor = Color.black;
		GUI.Label (new Rect (Screen.width / 2 - size.x / 2 + 1, Screen.height / 1.2f - size.y + 1, size.x, size.y), currentSubtitle, subtitleGUIStyle);
		GUI.contentColor = Color.white;
		GUI.Label (new Rect (Screen.width / 2 - size.x / 2, Screen.height / 1.2f - size.y, size.x, size.y), currentSubtitle, subtitleGUIStyle);
	}

	//Compares the time Samples of the current playing audioSource using its Sample Rate to the Timestamp defined in the subtitle file.
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

	//--------------------------------------------------
	//Additional Functions
	//--------------------------------------------------

	//Returns true or false, depending if a dialogue is currently playing
	public bool IsDialoguePlaying ()
	{
		if (audioSource != null) {
			return audioSource.isPlaying;
		} else {
			return false;
		}
	}

}
