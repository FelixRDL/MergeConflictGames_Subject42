using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {


	public GameObject[] speakers;

	private AudioSource playerAudioSource;
	private AudioSource[] speakerAudioSources;


	void Start () {
		playerAudioSource = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();

		speakerAudioSources = new AudioSource[speakers.Length];
		for (int i = 0; i < speakers.Length; i++) {
			speakerAudioSources[i] = speakers[i].GetComponent<AudioSource>();
		}

		print ("Speaker: " + speakerAudioSources.Length);

		Start_0_01 ();
	}


	//Act 0 Dialogues

	void Start_0_01 ()
	{
		//DialogueManager.instance.StartDialogue(playerAudioSource, "S_0_beide", 1, 0);
	}

	void Start_0_08()
	{
		
	}

	//Act 0 Interactables with Dialogue

	public void Start_0_Interactable_Window() {
		print ("Klicked on Window in Hospital");
		DialogueManager.instance.StartDialogue(playerAudioSource, "0_02_s", 1, 0);
	}

	public void Start_0_Interactable_Medical_Devices() {
		print ("Klicked on Medical Devices in Hospital");
		DialogueManager.instance.StartDialogue(playerAudioSource, "0_03_s", 1, 0);
	}

	public void Start_0_Interactable_Picture_Frame () {
		print ("Klicked on Picture Frame in Hospital");
		DialogueManager.instance.StartDialogue(playerAudioSource, "0_04_s", 1, 0);
	}

	public void Start_0_Interactable_Bath_Mirror() {
		print ("Klicked on Mirror in Bath");
		DialogueManager.instance.StartDialogue(playerAudioSource, "0_05_s", 1, 0);
	}

	public void Start_0_Interactable_Contracts() {
		print ("Klicked on Contracts in Hospital");
		DialogueManager.instance.StartDialogue(playerAudioSource, "0_06_s", 1, 0);
	}
		
	public void Start_0_Interactable_Door_Floor() {
		print ("Klicked on Door to Floor");
		DialogueManager.instance.StartDialogue(playerAudioSource, "0_07_s", 1, 0);
	}


	//Act 0 Interactables without Dialogue

	public void Start_0_Interactable_Door_Bath() {
		print ("Klicked on Door to Bath");
	}

	public void Start_0_Interactable_Rubber_Duck() {
		print ("Klicked on Rubber Duck");
	}








	void Lvl1_Scn_09_ToggleDarkness() {
		GameObject ceilingParent = GameObject.Find ("CeilingLightGroup");
		for (int i = 0; i < ceilingParent.transform.childCount; i++) {
			Transform lamp = ceilingParent.gameObject.transform.GetChild (i);
			lamp.gameObject.SetActive (!lamp.gameObject.activeSelf);
		}

		GameObject happyPaintings = GameObject.Find ("HappyPaintings");
		for (int i = 0; i < happyPaintings.transform.childCount; i++) {
			Transform painting = happyPaintings.gameObject.transform.GetChild (i);
			painting.gameObject.SetActive (!painting.gameObject.activeSelf);
		}

		GameObject sadPaintings = GameObject.Find ("SadPaintings");
		for (int i = 0; i < sadPaintings.transform.childCount; i++) {
			Transform painting = sadPaintings.gameObject.transform.GetChild (i);
			painting.gameObject.SetActive (!painting.gameObject.activeSelf);
		}

		GameObject happyCubes = GameObject.Find ("HappyCubes");
		for (int i = 0; i < happyCubes.transform.childCount; i++) {
			Transform cube = happyCubes.gameObject.transform.GetChild (i);
			cube.gameObject.SetActive (!cube.gameObject.activeSelf);
		}

		GameObject sadCubes = GameObject.Find ("SadCubes");
		for (int i = 0; i < sadCubes.transform.childCount; i++) {
			Transform cube = sadCubes.gameObject.transform.GetChild (i);
			cube.gameObject.SetActive (!cube.gameObject.activeSelf);
		}

		GameObject happyTrainTracks = GameObject.Find ("HappyTrainTracks");
		for (int i = 0; i < happyTrainTracks.transform.childCount; i++) {
			Transform trainTrackPiece = happyTrainTracks.gameObject.transform.GetChild (i);
			trainTrackPiece.gameObject.SetActive (!trainTrackPiece.gameObject.activeSelf);
		}

		GameObject sadTrainTracks = GameObject.Find ("SadTrainTracks");
		for (int i = 0; i < sadTrainTracks.transform.childCount; i++) {
			Transform trainTrackPiece = sadTrainTracks.gameObject.transform.GetChild (i);
			trainTrackPiece.gameObject.SetActive (!trainTrackPiece.gameObject.activeSelf);
		}

		GameObject happyBottles = GameObject.Find ("HappyBottles");
		for (int i = 0; i < happyBottles.transform.childCount; i++) {
			Transform bottle = happyBottles.gameObject.transform.GetChild (i);
			bottle.gameObject.SetActive (!bottle.gameObject.activeSelf);
		}

		GameObject sadBottles = GameObject.Find ("SadBottles");
		for (int i = 0; i < sadBottles.transform.childCount; i++) {
			Transform bottle = sadBottles.gameObject.transform.GetChild (i);
			bottle.gameObject.SetActive (!bottle.gameObject.activeSelf);
		}
	}
}
