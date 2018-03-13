using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{

	//Flags for Level 1
	private int clickedObjectsInHospitalRoom;
	private int clickedObjectsInChildrensRoom;
	private bool floorEntered;

	//Flags for Level 2
	private bool playerHasPasscode;

	//---------------------
	//EventManager Init
	//---------------------

	void Start ()
	{
		if (SceneManager.GetActiveScene().name == "Level1") {
			InitFlagsLevel1 ();
			InitInteractablesLevel1 ();

			Start_0_01 ();

			TEST_OPEN_DOORS_LEVEL1 ();
		}

		if (SceneManager.GetActiveScene().name == "Level2") {

			InitFlagsLevel2 ();
			Start_2_01 ();
		}


	}

	void InitFlagsLevel1 ()
	{
		clickedObjectsInHospitalRoom = 0;
		clickedObjectsInChildrensRoom = 0;
		floorEntered = false;
	}

	void InitInteractablesLevel1 ()
	{
		GameObject.Find ("Interactable_Contract_01").GetComponent<InteractableObject> ().Disable ();
		GameObject.Find ("Interactable_Contract_02").GetComponent<InteractableObject> ().Disable ();
		GameObject.Find ("Interactable_Contract_03").GetComponent<InteractableObject> ().Disable ();
		GameObject.Find ("Interactable_Pen").GetComponent<InteractableObject> ().Disable ();
	}

	void InitFlagsLevel2 ()
	{
		playerHasPasscode = false;
	}




	//ONLY FOR TESTING
	void TEST_OPEN_DOORS_LEVEL1 ()
	{
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
		//Level 1 Interactables:
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
			Start_1_Interactable_Wooden_Train_Happy (interactable);
			break;
		case "Interactable_Frame_Family":
			Start_1_Interactable_Frame_Family (interactable);
			break;
		case "Interactable_Frame_Dog":
			Start_1_Interactable_Frame_Dog (interactable);
			break;
		case "Interactable_Teddy":
			Start_1_Interactable_Teddy_Happy (interactable);
			break;
		case "Interactable_Light_Switch":
			Start_1_Interactable_Light_Switch (audioSource, interactable);
			break;
		case "Interactable_Beer_Bottle":
			Start_1_Interactable_Beer_Bottles (interactable);
			break;
		case "Interactable_Cubes_Sad":
			Start_1_Interactable_Cubes_Sad (interactable);
			break;
		case "Interactable_Frame_Friend":
			Start_1_Interactable_Frame_Friend (interactable);
			break;
		case "Interactable_Teddy_Sad":
			Start_1_Interactable_Teddy_Sad (interactable);
			break;
		case "Interactable_Wooden_Train_Sad":
			Start_1_Interactable_Wooden_Train_Sad (interactable);
			break;
		case "Interactable_Door_Childrens_Room_To_Garden":
			Start_1_Interactable_Door_Childrens_Room_To_Garden (audioSource, interactable);
			break;

		//Level 2 Interactables:
		case "Interactable_Keypad":
			Start_2_Interactable_Keypad (interactable);
			break;
		case "Interactable_DJ_Console":
			Start_2_Interactable_DJ_Console (interactable);
			break;
		case "Interactable_Pill_01":
			Start_2_04 (interactable);
			break;
		case "Interactable_Dancer":
			Start_2_Dancing_People (interactable);
			break;
		case "Interactable_Dancer_On_Floor":
			Start_2_Interactable_Dancers_On_Floor (interactable);
			break;
		case "Interactable_Friend_Fence":
			Start_2_08 (interactable);
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
		DialogueManager.instance.StartSubjectMonologue ("0_01", 1, 0);
	}


	void Start_0_08 ()
	{
		DialogueManager.instance.StartDialogueBetweenSubjectAndTestManager ("0_08", 1, 1, 0);
		GameObject.Find ("Interactable_Contract_01").GetComponent<InteractableObject> ().Enable ();
		GameObject.Find ("Interactable_Contract_02").GetComponent<InteractableObject> ().Enable ();
		GameObject.Find ("Interactable_Contract_03").GetComponent<InteractableObject> ().Enable ();
		GameObject.Find ("Interactable_Pen").GetComponent<InteractableObject> ().Enable ();
	}

	//----------------------------------
	//Act 0 Interactables with Dialogue
	//----------------------------------

	void Start_0_Interactable_Window (InteractableObject interactable)
	{
		print ("Klicked on Window in Hospital");
		DialogueManager.instance.StartSubjectMonologue ("0_02", 1, 0);
		countClickedObjectsLevel0 ();
		interactable.Disable ();
	}

	void Start_0_Interactable_Medical_Devices (InteractableObject interactable)
	{
		print ("Klicked on Medical Devices in Hospital");
		DialogueManager.instance.StartSubjectMonologue ("0_03", 1, 0);
		countClickedObjectsLevel0 ();
		interactable.Disable ();
	}

	void Start_0_Interactable_Picture_Frame (InteractableObject interactable)
	{
		print ("Klicked on Picture Frame in Hospital");
		DialogueManager.instance.StartSubjectMonologue ("0_04", 1, 0);
		countClickedObjectsLevel0 ();
		interactable.Disable ();
	}

	void Start_0_Interactable_Bath_Mirror (InteractableObject interactable)
	{
		print ("Klicked on Mirror in Bath");
		DialogueManager.instance.StartSubjectMonologue ("0_05", 1, 0);
		countClickedObjectsLevel0 ();
		interactable.Disable ();
	}

	void Start_0_Interactable_Contracts (InteractableObject interactable)
	{
		print ("Klicked on Contracts in Hospital");
		DialogueManager.instance.StartSubjectMonologue ("0_06", 1, 0);
		countClickedObjectsLevel0 ();
		interactable.Disable ();
		//GameObject.Find ("Interactable_Contracts").GetComponent<InteractableContracts> ().Disable ();

		//player.GetComponent<Player> ().CameraZoom ();
	}

	void Start_0_Interactable_Contract_One (InteractableObject interactable)
	{
		print ("Klicked on Contract One");
		DialogueManager.instance.StartSubjectMonologue ("0_13", 1, 0);
		interactable.Disable ();
	}

	void Start_0_Interactable_Contract_Two (InteractableObject interactable)
	{
		print ("Klicked on Contract One");
		DialogueManager.instance.StartSubjectMonologue ("0_14", 1, 0);
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
		DialogueManager.instance.StartSubjectMonologue ("0_17", 1, 0);

		SoundManager.instance.PlayEffect (audioSource, "signature", 1, 0);
		SoundManager.instance.PlayEffect (GameObject.Find ("Interactable_Door_Hospital_Floor").GetComponent<AudioSource> (), "dooropen", 1, 0);
		GameObject.Find ("Interactable_Door_Hospital_Floor").GetComponent<InteractableDoorHospitalToFloor> ().OpenDoor ();
	}

	public void Start_0_Interactable_Door_Floor (AudioSource audioSource)
	{
		print ("Klicked on Door to Floor");

		if (!floorEntered) {
			DialogueManager.instance.StartSubjectMonologue ("0_07", 1, 0);
			countClickedObjectsLevel0 ();
		} else {
			DialogueManager.instance.StartSubjectMonologue ("1_03", 1, 0);
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
		DialogueManager.instance.StartSubjectMonologue ("1_01", 1, 0);

		//Disable Cameras in Hospital for improved performance.
	}


	void Start_1_05_Interactable_Pill_Floor (AudioSource audioSource, InteractableObject interactable)
	{
		//Retromodine F - Recall Enhancer. Fair enough… what could possibly go wrong?! 	
		DialogueManager.instance.StartSubjectMonologue ("1_05", 1, 0);
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

		Invoke ("Start_1_16", 20);
	}

	void Start_1_16 ()
	{
		DialogueManager.instance.StartTestManagerMonologue ("1_16", 1, 0);
	}

	void Start_1_25 ()
	{
		DialogueManager.instance.StartTestManagerMonologue ("1_25", 1, 0);
		GameObject.Find ("Interactable_Door_Floor_Childrens_Room").GetComponent<InteractableDoorFloorToChildrensRoom> ().OpenDoor ();
	}

	void Start_1_27 ()
	{
		DialogueManager.instance.StartDialogueBetweenSubjectAndTestManager ("1.27", 1, 1, 0);
	}

	void Start_1_30 ()
	{
		DialogueManager.instance.StartDialogueBetweenSubjectAndTestManager ("1.30", 1, 1, 0);
	}


	//------------------------------------
	//Act 1 Interactables with Dialogue
	//------------------------------------


	public void Start_1_Interactable_Doors_In_Floor (AudioSource audioSource, InteractableDoorsInFloor interactable)
	{
		SoundManager.instance.PlayEffect (audioSource, "doorlocked", 1, 0);
		interactable.Disable ();
		DialogueManager.instance.StartSubjectMonologue ("1_04", 1, 0);
	}

	void Start_1_Interactable_Wooden_Train_Happy (InteractableObject interactable)
	{
		interactable.Disable ();
		DialogueManager.instance.StartSubjectMonologue ("1_09", 1, 0);
	}

	void Start_1_Interactable_Frame_Family (InteractableObject interactable)
	{
		interactable.Disable ();
		DialogueManager.instance.StartSubjectMonologue ("1_10", 1, 0);
	}

	void Start_1_Interactable_Frame_Dog (InteractableObject interactable)
	{
		interactable.Disable ();
		DialogueManager.instance.StartSubjectMonologue ("1_11", 1, 0);
	}

	void Start_1_Interactable_Teddy_Happy (InteractableObject interactable)
	{
		interactable.Disable ();
		DialogueManager.instance.StartSubjectMonologue ("1_12", 1, 0);
	}

	void Start_1_Interactable_Light_Switch (AudioSource audioSource, InteractableObject interactable)
	{
		interactable.Disable ();
		SoundManager.instance.PlayBackgroundMusicLoop ("OrWasIt_Level1_1_provisionally", 0, 0);

		ToggleChildrensRoomDarkPhase ();

		DialogueManager.instance.StartDialogueBetweenSubjectAndTestManagerAlterEgo ("1_17", 1, 1, 0);

		Invoke ("Start_1_25", 20);
	}

	void Start_1_Interactable_Beer_Bottles (InteractableObject interactable)
	{
		interactable.Disable ();
		DialogueManager.instance.StartSubjectMonologue ("1_20", 1, 0);
	}

	void Start_1_Interactable_Cubes_Sad (InteractableObject interactable)
	{
		interactable.Disable ();
		DialogueManager.instance.StartSubjectMonologue ("1_21", 1, 0);
	}

	void Start_1_Interactable_Frame_Friend (InteractableObject interactable)
	{
		interactable.Disable ();
		DialogueManager.instance.StartSubjectMonologue ("1_22", 1, 0);
	}

	void Start_1_Interactable_Teddy_Sad (InteractableObject interactable)
	{
		interactable.Disable ();
		DialogueManager.instance.StartSubjectMonologue ("1_23", 1, 0);
	}


	void Start_1_Interactable_Wooden_Train_Sad (InteractableObject interactable)
	{
		interactable.Disable ();
		DialogueManager.instance.StartSubjectMonologue ("1_24", 1, 0);
	}

	//------------------------------------
	//Act 1 Interactables without Dialogue
	//------------------------------------

	void Start_1_Interactable_Door_Childrens_Room_To_Garden (AudioSource audioSource, InteractableObject interactable)
	{
		SoundManager.instance.PlayEffect (audioSource, "dooropen", 1, 0);
		SceneManager.LoadScene ("Level2");
	}


	//---------------------
	//Act 2 Main Dialogues
	//---------------------

	void Start_2_01 () {
		DialogueManager.instance.StartTestManagerMonologue ("2_01", 1, 0);
	}

	void Start_2_04 (InteractableObject interactable) {
		//Pille 1

		DialogueManager.instance.StartDialogueBetweenSubjectAndTestManager ("2_04", 1, 1, 0);
		interactable.Disable();

		SoundManager.instance.PlayBackgroundMusicLoop ("Synapsis_-_04_-_psy_experiment", 0, 0);

		SwitchHoardings ();
		SwitchRaveElements ();
	}

	void Start_2_08 (InteractableObject interactable) {
		DialogueManager.instance.StartDialogueBetweenSubjectAndFriend ("2_08", 1, 1, 0);
	}

	void Start_2_11 () {
		//Hier eigentlich Alter Ego am Reden -> Anpassen!
		DialogueManager.instance.StartSubjectMonologue ("2_11", 1, 0);
	}

	void Start_2_12 () {
		DialogueManager.instance.StartSubjectMonologue ("2_12", 1, 0);
	}

	void Start_2_13 () {
		//Hier eigentlich Alter Ego am Reden -> Anpassen!
		DialogueManager.instance.StartSubjectMonologue ("2_13", 1, 0);
	}

	void Start_2_14 () {
		DialogueManager.instance.StartSubjectMonologue ("2_14", 1, 0);
	}

	void Start_2_15 () {
		DialogueManager.instance.StartFriendMonologue ("2_15", 1, 0);
	}

	void Start_2_16 () {
		DialogueManager.instance.StartSubjectMonologue ("2_16", 1, 0);
	}

	void Start_2_18 () {
		//Wenn Spieler zu lange nicht die Pille nimmt.
		DialogueManager.instance.StartTestManagerMonologue ("2_18", 1, 0);
	}

	void Start_2_19 () {
		//Pille 2
	}


	//...


	void Start_2_31 () {
		DialogueManager.instance.StartDialogueBetweenSubjectAndTestManager ("2_31", 1, 1, 0);
	}

	//----------------------------------
	//Act 2 Interactables with Dialogue
	//----------------------------------

	void Start_2_Interactable_Keypad (InteractableObject interactable) {
		if (!playerHasPasscode) {
			DialogueManager.instance.StartSubjectMonologue ("2_03", 1, 0);
		} else {
			Start_2_31 ();
		}
		interactable.Disable ();
	}

	void Start_2_Interactable_Dancers_On_Floor (InteractableObject interactable) {
		DialogueManager.instance.StartSubjectMonologue ("2_06", 1, 0);
		interactable.Disable ();
	}

	void Start_2_Dancing_People (InteractableObject interactable) {
		DialogueManager.instance.StartSubjectMonologue ("2_07", 1, 0);
		interactable.Disable ();
	}

	void Start_2_Interactable_DJ_Console (InteractableObject interactable) {
		DialogueManager.instance.StartSubjectMonologue ("2_17", 1, 0);
		interactable.Disable ();
	}

	void Start_2_Interactable_Note_Passcode (InteractableObject interactable) {
		DialogueManager.instance.StartSubjectMonologue ("2_30", 1, 0);
		interactable.Disable ();
	}



	//------------------------------------
	//Act 2 Interactables without Dialogue
	//------------------------------------





	void SwitchHoardings () {
		GameObject hoardings = GameObject.Find ("Hoardings_Dynamic");
		for (int i = 0; i < hoardings.transform.childCount; i++) {
			Transform hoarding = hoardings.gameObject.transform.GetChild (i);
			hoarding.gameObject.SetActive (!hoarding.gameObject.activeSelf);
		}
	}

	void SwitchRaveElements () {
		GameObject rave = GameObject.Find ("Rave");
		for (int i = 0; i < rave.transform.childCount; i++) {
			Transform raveElement = rave.gameObject.transform.GetChild (i);
			raveElement.gameObject.SetActive (!raveElement.gameObject.activeSelf);
		}
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

		GameObject sadTrainTracks = GameObject.Find ("Interactable_Wooden_Train_Sad");
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
