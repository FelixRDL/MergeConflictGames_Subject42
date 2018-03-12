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
	private bool floorEntered;

	//---------------------
	//EventManager Init
	//---------------------

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

		TEST_OPEN_DOORS ();
	}

	void InitFlags ()
	{
		clickedObjectsInHospitalRoom = 0;
		floorEntered = false;
	}
		
	void InitInteractables ()
	{
		GameObject.Find ("Interactable_Contract_01").GetComponent<InteractableObject> ().Disable ();
		GameObject.Find ("Interactable_Contract_02").GetComponent<InteractableObject> ().Disable ();
		GameObject.Find ("Interactable_Contract_03").GetComponent<InteractableObject> ().Disable ();
		GameObject.Find ("Interactable_Pen").GetComponent<InteractableObject> ().Disable ();
	}


	//ONLY FOR TESTING
	void TEST_OPEN_DOORS() {
		GameObject.Find ("Interactable_Door_Hospital_Floor").GetComponent<InteractableDoorHospitalToFloor> ().OpenDoor ();
	}

	//---------------------
	// Main Game Functions
	//---------------------

	public void OnTriggerZoneEntered (string nameOfTriggerZone)
	{
		switch (nameOfTriggerZone) {
		case "Trigger_Zone_Floor":
			print ("Reached Floor");
			Start_1_01 ();
			break;
		case "Trigger_Zone_Childrens_Room":
			print ("Reached Childrens Room");
			Start_1_06 ();
			break;
		default:
			break;
		}
	}

	public void OnInteractableClicked (string nameOfInteractable, AudioSource audioSource, InteractableObject interactable)
	{
		switch (nameOfInteractable) {
		case "Interactable_Window":
			Start_0_Interactable_Window (interactable);
			break;
		case "Interactable_Medical_Devices":
			Start_0_Interactable_Medical_Devices (interactable);
			break;
		case "Interactable_Picture_Frame_Hospital":
			Start_0_Interactable_Picture_Frame (interactable);
			break;
		case "Interactable_Mirror_Bath":
			Start_0_Interactable_Bath_Mirror (interactable);
			break;
		case "Interactable_Contracts":
			Start_0_Interactable_Contracts (interactable);
			break;
		case "Interactable_Contract_01":
			Start_0_Interactable_Contract_One (interactable);
			break;
		case "Interactable_Contract_02":
			Start_0_Interactable_Contract_Two (interactable);
			break;
		case "Interactable_Contract_03":
			Start_0_Interactable_Contract_Three (interactable);
			break;
		case "Interactable_Pen":
			Start_0_Interactable_Pen (audioSource, interactable);
			break;
		case "Interactable_Rubber_Duck":
			Start_0_Interactable_Rubber_Duck (audioSource);
			break;
		case "Interactable_Pill_Floor":
			Start_1_05_Interactable_Pill_Floor (audioSource, interactable);
			break;
		case "Interactable_Wooden_Train_Happy":
			Start_1_Interactable_Wooden_Train (interactable);
			break;
		case "Interactable_Frame_Family":
			Start_1_Interactable_Frame_Family (interactable);
			break;
		case "Interactable_Frame_Dog":
			Start_1_Interactable_Frame_Dog (interactable);
			break;
		case "Interactable_Frame_Teddy":
			Start_1_Interactable_Frame_Teddy (interactable);
			break;
		case "Interactable_Light_Switch":
			Start_1_Interactable_Light_Switch (audioSource, interactable);
			break;
		default:
			break;
		}
	}



	//---------------------
	//Act 0 Main Dialogues
	//---------------------

	void Start_0_01 ()
	{
		DialogueManager.instance.StartMonologue (playerAudioSource, "0_01", 1, 0);
	}


	void Start_0_08 ()
	{
		DialogueManager.instance.StartDialogueBetweenSubjectAndTestManager ("0_08", 1,1, 0);
		GameObject.Find ("Interactable_Contract_01").GetComponent<InteractableObject> ().Enable ();
		GameObject.Find ("Interactable_Contract_02").GetComponent<InteractableObject> ().Enable ();
		GameObject.Find ("Interactable_Contract_03").GetComponent<InteractableObject> ().Enable ();
		GameObject.Find ("Interactable_Pen").GetComponent<InteractableObject> ().Enable ();
	}

	//---------------------
	//Act 0 Interactables with Dialogue
	//---------------------

	void Start_0_Interactable_Window (InteractableObject interactable)
	{
		print ("Klicked on Window in Hospital");
		DialogueManager.instance.StartMonologue (playerAudioSource, "0_02", 1, 0);
		countClickedObjectsLevel0 ();
		interactable.Disable ();
	}

	void Start_0_Interactable_Medical_Devices (InteractableObject interactable)
	{
		print ("Klicked on Medical Devices in Hospital");
		DialogueManager.instance.StartMonologue (playerAudioSource, "0_03", 1, 0);
		countClickedObjectsLevel0 ();
		interactable.Disable ();
	}

	void Start_0_Interactable_Picture_Frame (InteractableObject interactable)
	{
		print ("Klicked on Picture Frame in Hospital");
		DialogueManager.instance.StartMonologue (playerAudioSource, "0_04", 1, 0);
		countClickedObjectsLevel0 ();
		interactable.Disable ();
	}

	void Start_0_Interactable_Bath_Mirror (InteractableObject interactable)
	{
		print ("Klicked on Mirror in Bath");
		DialogueManager.instance.StartMonologue (playerAudioSource, "0_05", 1, 0);
		countClickedObjectsLevel0 ();
		interactable.Disable ();
	}

	void Start_0_Interactable_Contracts (InteractableObject interactable)
	{
		print ("Klicked on Contracts in Hospital");
		DialogueManager.instance.StartMonologue (playerAudioSource, "0_06", 1, 0);
		countClickedObjectsLevel0 ();
		interactable.Disable ();
		//GameObject.Find ("Interactable_Contracts").GetComponent<InteractableContracts> ().Disable ();

		//player.GetComponent<Player> ().CameraZoom ();
	}

	void Start_0_Interactable_Contract_One (InteractableObject interactable)
	{
		print ("Klicked on Contract One");
		DialogueManager.instance.StartMonologue (playerAudioSource, "0_13", 1, 0);
		interactable.Disable ();
	}

	void Start_0_Interactable_Contract_Two (InteractableObject interactable)
	{
		print ("Klicked on Contract One");
		DialogueManager.instance.StartMonologue (playerAudioSource, "0_14", 1, 0);
		interactable.Disable ();
	}

	void Start_0_Interactable_Contract_Three (InteractableObject interactable)
	{
		print ("Klicked on Contract One");
		DialogueManager.instance.StartDialogueBetweenSubjectAndTestManager ("0_15", 1, 1, 0);
		interactable.Disable ();
	}

	void Start_0_Interactable_Pen (AudioSource audioSource, InteractableObject interactable)
	{
		print ("Klicked on Pen");
		interactable.Disable ();
		DialogueManager.instance.StartMonologue (playerAudioSource, "0_17", 1, 0);

		SoundManager.instance.PlayEffect (audioSource, "signature", 1, 0);
		SoundManager.instance.PlayEffect (GameObject.Find ("Interactable_Door_Hospital_Floor").GetComponent<AudioSource> (), "dooropen", 1, 0);
		GameObject.Find ("Interactable_Door_Hospital_Floor").GetComponent<InteractableDoorHospitalToFloor> ().OpenDoor ();
	}

	public void Start_0_Interactable_Door_Floor (AudioSource audioSource)
	{
		print ("Klicked on Door to Floor");

		if (!floorEntered) {
			DialogueManager.instance.StartMonologue (playerAudioSource, "0_07", 1, 0);
			countClickedObjectsLevel0 ();
		} else {
			DialogueManager.instance.StartMonologue (playerAudioSource, "1_03", 1, 0);
		}

		SoundManager.instance.PlayEffect (audioSource, "doorlocked", 1, 0);
		GameObject.Find ("Interactable_Door_Hospital_Floor").GetComponent<InteractableDoorHospitalToFloor> ().Disable ();

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

	void Start_0_Interactable_Rubber_Duck (AudioSource audioSource)
	{
		print ("Klicked on Rubber Duck");
		System.Random random = new System.Random ();
		string clipName = "quack0" + random.Next (1, 5);
		SoundManager.instance.PlayEffect (audioSource, clipName, 1, 0);
	}

	//---------------------
	//Act 0 Control Variables
	//---------------------


	//A certain number of Interactables in Level 0 need to be clicked in Order for the game to continue
	void countClickedObjectsLevel0 ()
	{
		clickedObjectsInHospitalRoom++;
		print (clickedObjectsInHospitalRoom);
		if (clickedObjectsInHospitalRoom > 5) {
			Invoke ("Start_0_08", 10);
		}
	}


	//---------------------
	//Act 1 Main Dialogues
	//---------------------


	void Start_1_01 ()
	{
		GameObject.Find ("Interactable_Door_Hospital_Floor").GetComponent<InteractableDoorHospitalToFloor> ().Enable ();
		GameObject.Find ("Interactable_Door_Hospital_Floor").GetComponent<InteractableDoorHospitalToFloor> ().CloseDoor ();
		floorEntered = true;
		DialogueManager.instance.StartMonologue (playerAudioSource, "1_01", 1, 0);
	}


	void Start_1_05_Interactable_Pill_Floor (AudioSource audioSource, InteractableObject interactable)
	{
		//Retromodine F - Recall Enhancer. Fair enough… what could possibly go wrong?! 	
		DialogueManager.instance.StartMonologue (playerAudioSource, "1_05", 1, 0);
		//SoundManager.instance.PlayEffect (audioSource, "eat_pill", 1, 0);
		interactable.Disable ();

		SoundManager.instance.PlayBackgroundMusicLoop ("DarnParadise_Level1_0", 0, 0);

		SoundManager.instance.PlayEffect (GameObject.Find ("Interactable_Door_Floor_Childrens_Room").GetComponent<AudioSource> (), "dooropen", 1, 0);
		GameObject.Find ("Interactable_Door_Floor_Childrens_Room").GetComponent<InteractableDoorFloorToChildrensRoom> ().OpenDoor ();
	}

	void Start_1_06 ()
	{
		GameObject.Find ("Interactable_Door_Floor_Childrens_Room").GetComponent<InteractableDoorFloorToChildrensRoom> ().CloseDoor ();
		DialogueManager.instance.StartDialogueBetweenSubjectAndTestManagerAlterEgo ("1_06", 1, 1, 0);
	}


	//------------------------------------
	//Act 1 Interactables with Dialogue
	//------------------------------------


	void Start_1_Interactable_Doors_On_Floor () {

	}

	void Start_1_Interactable_Wooden_Train (InteractableObject interactable) 
	{
		interactable.Disable ();
		DialogueManager.instance.StartMonologue (playerAudioSource, "1_09", 1, 0);
	}

	void Start_1_Interactable_Frame_Family (InteractableObject interactable) 
	{
		interactable.Disable ();
		DialogueManager.instance.StartMonologue (playerAudioSource, "1_10", 1, 0);
	}

	void Start_1_Interactable_Frame_Dog (InteractableObject interactable) 
	{
		interactable.Disable ();
		DialogueManager.instance.StartMonologue (playerAudioSource, "1_11", 1, 0);
	}

	void Start_1_Interactable_Frame_Teddy (InteractableObject interactable) 
	{
		interactable.Disable ();
		DialogueManager.instance.StartMonologue (playerAudioSource, "1_12", 1, 0);
	}

	void Start_1_Interactable_Light_Switch (AudioSource audioSource, InteractableObject interactable)
	{
		interactable.Disable ();
		SoundManager.instance.PlayBackgroundMusicLoop ("OrWasIt_Level1_1_provisionally", 0, 0);

		ToggleChildrensRoomDarkPhase ();
	}












	void ToggleChildrensRoomDarkPhase ()
	{
		GameObject ceilingParent = GameObject.Find ("Ceiling_Lights_Childrens_Room");
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

		GameObject happyTrainTracks = GameObject.Find ("Interactable_Wooden_Train_Happy");
		for (int i = 0; i < happyTrainTracks.transform.childCount; i++) {
			Transform trainTrackPiece = happyTrainTracks.gameObject.transform.GetChild (i);
			trainTrackPiece.gameObject.SetActive (!trainTrackPiece.gameObject.activeSelf);
		}

		GameObject sadTrainTracks = GameObject.Find ("Wooden_Train_Sad");
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
