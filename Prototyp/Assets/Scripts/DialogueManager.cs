using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Idea from: https://www.youtube.com/watch?v=1NW0BYn5KfE

//The DialogueManager is responsible for playing Dialogue Audio and displaying Subtitles
public class DialogueManager : MonoBehaviour
{

	public AudioClip[] audioSources;
	public Dictionary<string, AudioClip> audioClips;

	private const float RATE = 44100.0f;

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
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}

		DontDestroyOnLoad (gameObject);

		createDictionary ();

	}

	private void createDictionary ()
	{
		audioClips = new Dictionary<string, AudioClip> ();

		foreach (AudioClip clip in audioSources) {
			audioClips.Add (clip.name, clip);
		}
	}

	public void StartDialogue (AudioSource source, string clipName, float volume, float delay)
	{
	
		//1. Reset data
		audioSource = source;
		audioSource.volume = volume;

		audioSource.clip = audioClips [clipName];

		subtitleTimings = new List<float> ();
		subtitleText = new List<string> ();

		nextSubtitle = 0;

		//2. Load subtitles from file
		TextAsset temp = Resources.Load ("Dialogues/" + clipName) as TextAsset;
		string[] fileLines = temp.text.Split ('\n');

		for (int i = 0; i < fileLines.Length; i++) {
			string currentLine = fileLines [i];


			string[] splittedLine = currentLine.Split ('|');
			subtitleTimings.Add (float.Parse (splittedLine [0]));
			subtitleText.Add (splittedLine [1]);
		}

		//Set first line of subtitles and play dialogue audio
		currentSubtitle = subtitleText [0];
		audioSource.PlayDelayed (delay);


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
