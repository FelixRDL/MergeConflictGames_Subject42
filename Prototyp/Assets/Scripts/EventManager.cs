using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{


	public GameObject[] speakers;

	private AudioSource playerAudioSource;
	private AudioSource[] speakerAudioSources;

	private GameObject player;

	private int clickedObjectsInHospitalRoom;


	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		playerAudioSource = player.GetComponent<AudioSource> ();

		speakerAudioSources = new AudioSource[speakers.Length];
		for (int i = 0; i < speakers.Length; i++) {
			speakerAudioSources [i] = speakers [i].GetComponent<AudioSource> ();
		}

		InitFlags ();
		InitInteractables ();

		Start_0_01 ();
	}

	void InitFlags () {
		clickedObjectsInHospitalRoom = 0;
	}

	void InitInteractables () 
	{
		GameObject.Find ("Interactable_Contract_01").GetComponent<InteractableContractOne> ().Disable ();
		GameObject.Find ("Interactable_Contract_02").GetComponent<InteractableContractTwo> ().Disable ();
		GameObject.Find ("Interactable_Contract_03").GetComponent<InteractableContractThree> ().Disable ();
		GameObject.Find ("Interactable_Pen").GetComponent<InteractablePen> ().Disable ();
	}



	//---------------------
	//Act 0 Main Dialogues
	//---------------------

	void Start_0_01 ()
	{
		DialogueManager.instance.StartMonologue (playerAudioSource, "0_01", 1, 0);
		//SoundManager.instance.PlayBackgroundMusicLoop ("DarnParadise_Level1_0", 0, 0);
	}


	void Start_0_08 ()
	{
		DialogueManager.instance.StartDialogue (playerAudioSource, speakerAudioSources [0], "0_08", 1, 0);
		GameObject.Find ("Interactable_Contract_01").GetComponent<InteractableContractOne> ().Enable ();
		GameObject.Find ("Interactable_Contract_02").GetComponent<InteractableContractTwo> ().Enable ();
		GameObject.Find ("Interactable_Contract_03").GetComponent<InteractableContractThree> ().Enable ();
		GameObject.Find ("Interactable_Pen").GetComponent<InteractablePen> ().Enable ();
	}

	//---------------------
	//Act 0 Interactables with Dialogue
	//---------------------

	public void Start_0_Interactable_Window ()
	{
		print ("Klicked on Window in Hospital");
		DialogueManager.instance.StartMonologue (playerAudioSource, "0_02", 1, 0);
		countClickedObjectsLevel0 ();
		GameObject.Find ("Interactable_Window").GetComponent<InteractableWindowHospitalRoom> ().Disable ();
	}

	public void Start_0_Interactable_Medical_Devices ()
	{
		print ("Klicked on Medical Devices in Hospital");
		DialogueManager.instance.StartMonologue (playerAudioSource, "0_03", 1, 0);
		countClickedObjectsLevel0 ();
		GameObject.Find ("Interactable_Medical_Devices").GetComponent<InteractableMedicalDevices> ().Disable ();
	}

	public void Start_0_Interactable_Picture_Frame ()
	{
		print ("Klicked on Picture Frame in Hospital");
		DialogueManager.instance.StartMonologue (playerAudioSource, "0_04", 1, 0);
		countClickedObjectsLevel0 ();
		GameObject.Find ("Interactable_Picture_Frame_Hospital").GetComponent<InteractablePictureFrameHospital> ().Disable ();
	}

	public void Start_0_Interactable_Bath_Mirror ()
	{
		print ("Klicked on Mirror in Bath");
		DialogueManager.instance.StartMonologue (playerAudioSource, "0_05", 1, 0);
		countClickedObjectsLevel0 ();
		GameObject.Find ("Interactable_Mirror_Bath").GetComponent<InteractableBathMirror> ().Disable ();
	}

	public void Start_0_Interactable_Contracts ()
	{
		print ("Klicked on Contracts in Hospital");
		DialogueManager.instance.StartMonologue (playerAudioSource, "0_06", 1, 0);
		countClickedObjectsLevel0 ();
		GameObject.Find ("Interactable_Contracts").GetComponent<InteractableContracts> ().Disable ();


		//player.GetComponent<Player> ().CameraZoom ();
	}

	public void Start_0_Interactable_Contract_One ()
	{
		print ("Klicked on Contract One");
		DialogueManager.instance.StartMonologue (playerAudioSource, "0_13", 1, 0);
		GameObject.Find ("Interactable_Contract_01").GetComponent<InteractableContractOne> ().Disable ();
	}

	public void Start_0_Interactable_Contract_Two ()
	{
		print ("Klicked on Contract One");
		DialogueManager.instance.StartMonologue (playerAudioSource, "0_14", 1, 0);
		GameObject.Find ("Interactable_Contract_02").GetComponent<InteractableContractTwo> ().Disable ();
	}

	public void Start_0_Interactable_Contract_Three ()
	{
		print ("Klicked on Contract One");
		DialogueManager.instance.StartDialogue (playerAudioSource, speakerAudioSources [0], "0_15", 1, 0);
		GameObject.Find ("Interactable_Contract_03").GetComponent<InteractableContractThree> ().Disable ();
	}

	public void Start_0_Interactable_Pen (AudioSource audioSource)
	{
		print ("Klicked on Pen");
		GameObject.Find ("Interactable_Pen").GetComponent<InteractablePen> ().Disable ();
		DialogueManager.instance.StartMonologue (playerAudioSource, "0_17", 1, 0);

		SoundManager.instance.PlayEffect (audioSource, "signature", 1, 0);
		SoundManager.instance.PlayEffect (GameObject.Find ("Interactable_Door_Hospital_Floor").GetComponent<AudioSource> (), "dooropen", 1, 0);
		GameObject.Find ("Interactable_Door_Hospital_Floor").GetComponent<InteractableDoorHospitalToFloor> ().OpenDoor ();
		GameObject.Find ("Interactable_Door_Hospital_Floor").GetComponent<InteractableDoorHospitalToFloor> ().Disable ();
	}

	public void Start_0_Interactable_Door_Floor (AudioSource audioSource)
	{
		print ("Klicked on Door to Floor");
		DialogueManager.instance.StartMonologue (playerAudioSource, "0_07", 1, 0);
		SoundManager.instance.PlayEffect (audioSource, "doorlocked", 1, 0);
		GameObject.Find ("Interactable_Door_Hospital_Floor").GetComponent<InteractableDoorHospitalToFloor> ().Disable ();
		countClickedObjectsLevel0 ();
	}

	//------------------------------------
	//Act 0 Interactables without Dialogue
	//------------------------------------

	public void Start_0_Interactable_Door_Bath (AudioSource audioSource)
	{
		print ("Klicked on Door to Bath");
		SoundManager.instance.PlayEffect (audioSource, "dooropen", 1, 0);
		GameObject.Find ("Interactable_Door_Hospital_Bath").GetComponent<InteractableDoorHospitalToBath> ().OpenBathroomDoor ();
		GameObject.Find ("Interactable_Door_Hospital_Bath").GetComponent<InteractableDoorHospitalToBath> ().Disable ();
	}

	public void Start_0_Interactable_Rubber_Duck (AudioSource audioSource)
	{
		print ("Klicked on Rubber Duck");
		System.Random random = new System.Random ();
		string clipName = "quack0" + random.Next (1, 5);
		SoundManager.instance.PlayEffect (audioSource, clipName, 1, 0);
	}





	//A certain number of Interactables in Level 0 need to be clicked in Order for the game to continue
	private void countClickedObjectsLevel0 ()
	{
		clickedObjectsInHospitalRoom++;
		print (clickedObjectsInHospitalRoom);
		if (clickedObjectsInHospitalRoom > 5) {
			Invoke ("Start_0_08", 10);
		}
	}





	void ToggleChildrensRoomDarkPhase ()
	{
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
