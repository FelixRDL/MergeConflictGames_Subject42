using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{

	//Flags for Level 1
	private int clickedObjectsInHospitalRoom;
	private int clickedObjectsInChildrensRoomHappy;
	private int clickedObjectsInChildrensRoomSad;
	private bool floorEntered;
	private bool allowedToSignContract;

	//Flags for Level 2
	private bool playerHasTakenPill03;

	//---------------------
	//EventManager Init
	//---------------------

	void Start ()
	{
		if (SceneManager.GetActiveScene ().name == "Level1") 
		{
			InitFlagsLevel1 ();
			Start_0_01 ();
		}

		if (SceneManager.GetActiveScene ().name == "Level2") 
		{
			InitFlagsLevel2 ();
			Start_2_01 ();
		}


	}

	void InitFlagsLevel1 ()
	{
		clickedObjectsInHospitalRoom = 0;
		clickedObjectsInChildrensRoomHappy = 0;
		clickedObjectsInChildrensRoomSad = 0;
		floorEntered = false;
		allowedToSignContract = false;
	}

	void InitFlagsLevel2 ()
	{
		playerHasTakenPill03 = false;
	}



	//---------------------
	// Main Game Functions
	//---------------------

	//Switch Statement for all Ingame TriggerZones.
	public void OnTriggerZoneEntered (string nameOfTriggerZone)
	{
		switch (nameOfTriggerZone) {

		//Trigger Zones for Level 1
		case "Trigger_Zone_Floor":
			Start_1_01 ();
			break;
		case "Trigger_Zone_Childrens_Room_Happy":
			Start_1_06 ();
			break;
		case "Trigger_Zone_Childrens_Room_Sober":
			Start_1_30 ();
			break;
		
		//Trigger Zones for Level 2
		case "Trigger_Zone_Hole_In_Fence":
			Start_2_12 ();
			break;
		case "Trigger_Zone_Follow_Friend_01":
			Start_2_13 ();
			break;
		case "Trigger_Zone_Reached_Friend_01":
			Start_2_Reached_Friend_01 ();
			break;
		case "Trigger_Zone_Reached_Friend_02":
			Start_2_14 ();
			break;
		case "Trigger_Zone_Emergency_Lights":
			Start_2_20 ();
			break;
		case "Trigger_Zone_Subject_Remembers":
			Start_2_21 ();
			break;
		case "Trigger_Zone_See_Dead_Friend":
			Start_2_22 ();
			break;
		}
	}

	//Switch Statement for all Ingame Interactables.
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
		case "Interactable_Contract_01":
			Start_0_Interactable_Contract_One (audioSource, interactable);
			break;
		case "Interactable_Contract_02":
			Start_0_Interactable_Contract_Two (audioSource, interactable);
			break;
		case "Interactable_Contract_03":
			Start_0_Interactable_Contract_Three (audioSource, interactable);
			break;
		case "Interactable_Rubber_Duck":
			Start_0_Interactable_Rubber_Duck (audioSource);
			break;
		case "Interactable_Door_Floor_01":
			Start_1_Interactable_Door_Floor_01 (audioSource, interactable);
			break;
		case "Interactable_Door_Floor_02":
			Start_1_Interactable_Door_Floor_02 (audioSource, interactable);
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
		case "Interactable_Frame_Friend_Sad":
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
		case "Interactable_Neutralizer":
			Start_1_Interactable_Neutralizer (interactable);
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
		case "Interactable_Pill_02":
			Start_2_11 (interactable);
			break;
		case "Interactable_Friend_Dome":
			Start_2_15 (interactable);
			break;
		case "Interactable_Pill_03":
			Start_2_19 (interactable);
			break;
		case "Interactable_Friend_Dead":
			Start_2_23 (interactable);
			break;
		case "Interactable_Note_Code_For_Keypad":
			Start_2_Interactable_Note_Code_For_Keypad (interactable);
			break;
		}
	}

	#region Level1 Act 0

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
		EnableInteractableContractOneForSecondInteraction ();
		allowedToSignContract = true;
	}

	//----------------------------------
	//Act 0 Interactables with Dialogue
	//----------------------------------

	void Start_0_Interactable_Window (InteractableObject interactable)
	{
		interactable.Disable ();
		DialogueManager.instance.StartSubjectMonologue ("0_02", 1, 0);
	}

	void Start_0_Interactable_Medical_Devices (InteractableObject interactable)
	{
		interactable.Disable ();
		DialogueManager.instance.StartSubjectMonologue ("0_03", 1, 0);
	}

	void Start_0_Interactable_Picture_Frame (InteractableObject interactable)
	{
		interactable.Disable ();
		DialogueManager.instance.StartSubjectMonologue ("0_04", 1, 0);
		countClickedObjectsLevel0 ();
	}

	void Start_0_Interactable_Bath_Mirror (InteractableObject interactable)
	{
		interactable.Disable ();
		DialogueManager.instance.StartSubjectMonologue ("0_05", 1, 0);
	}

	void Start_0_Interactable_Contract_One (AudioSource audioSource, InteractableObject interactable)
	{
		interactable.Disable ();

		if (!allowedToSignContract) {
			DialogueManager.instance.StartSubjectMonologue ("0_06", 1, 0);
			countClickedObjectsLevel0 ();
		} else {
			DialogueManager.instance.StartSubjectMonologue ("0_13", 1, 0);
			ToggleContract ("Interactable_Contract_01");
			ToggleContract ("Interactable_Contract_02");
		}

		//Maybe add possibility here of zooming in on a contract.
		//player.GetComponent<Player> ().CameraZoom ();
	}

	void Start_0_Interactable_Contract_Two (AudioSource audioSource, InteractableObject interactable)
	{
		interactable.Disable ();
		DialogueManager.instance.StartSubjectMonologue ("0_14", 1, 0);
		ToggleContract ("Interactable_Contract_02");
		ToggleContract ("Interactable_Contract_03");
	}

	void Start_0_Interactable_Contract_Three (AudioSource audioSource, InteractableObject interactable)
	{
		interactable.Disable ();
		StartCoroutine(ContractThreeCoroutine(audioSource));

	}

	//Because there are multiple timed Events happening on Interaction with the Contract, we need a Coroutine here.
	IEnumerator ContractThreeCoroutine (AudioSource audioSource)
	{
		DialogueManager.instance.StartDialogueBetweenSubjectAndTestManager ("0_15", 1, 1, 0);
		yield return new WaitForSecondsRealtime(15);
		SoundManager.instance.PlayEffect (audioSource, "signature", 1, 0);
		yield return new WaitForSecondsRealtime(3);
		DialogueManager.instance.StartSubjectMonologue ("0_17", 1, 0);
		yield return new WaitForSecondsRealtime(4);
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

	//---------------------------
	//Act 0 Additional Functions
	//---------------------------


	//A certain number of Interactables in Level 0 need to be clicked in Order for the game to continue
	void countClickedObjectsLevel0 ()
	{
		clickedObjectsInHospitalRoom++;
		print (clickedObjectsInHospitalRoom);
		if (clickedObjectsInHospitalRoom == 3) {
			Invoke ("Start_0_08", 8);
		}
	}

	void ToggleContract (string nameOfContract)
	{
		GameObject contractParent = GameObject.Find ("Contracts");
		for (int i = 0; i < contractParent.transform.childCount; i++) {
			Transform contract = contractParent.gameObject.transform.GetChild (i);
			if (contract.name == nameOfContract) {
				contract.gameObject.SetActive (!contract.gameObject.activeSelf);
			}
		}
	}

	void EnableInteractableContractOneForSecondInteraction ()
	{
		GameObject.Find ("Interactable_Contract_01").GetComponent<InteractableObject> ().Enable ();
	}

	#endregion


	#region Level1 Act1

	//---------------------
	//Act 1 Main Dialogues
	//---------------------


	void Start_1_01 ()
	{
		GameObject.Find ("Interactable_Door_Hospital_Floor").GetComponent<InteractableDoorHospitalToFloor> ().Enable ();
		GameObject.Find ("Interactable_Door_Hospital_Floor").GetComponent<InteractableDoorHospitalToFloor> ().CloseDoor ();
		floorEntered = true;
		DialogueManager.instance.StartSubjectMonologue ("1_01", 1, 0);
	}


	void Start_1_05_Interactable_Pill_Floor (AudioSource audioSource, InteractableObject interactable)
	{
		//Retromodine F - Recall Enhancer. Fair enough… what could possibly go wrong?! 	
		DialogueManager.instance.StartSubjectMonologue ("1_05", 1, 0);

		SoundManager.instance.PlayEffect (audioSource, "eat_pill", 1, 4);

		SoundManager.instance.PlayEffect (audioSource, "gulp", 1, 6);
		interactable.Disable ();

		SoundManager.instance.PlayBackgroundMusicLoop ("DarnParadise_Level1_0", 1, 5);

		Invoke ("OpenDoorFloorToChildrensRoom", 8);
	}

	void Start_1_06 ()
	{
		GameObject.Find ("Interactable_Door_Floor_Childrens_Room").GetComponent<InteractableDoorFloorToChildrensRoom> ().CloseDoor ();
		DialogueManager.instance.StartDialogueBetweenSubjectAndTestManagerAlterEgo ("1_06", 1, 1, 0);
	}

	void Start_1_16 ()
	{
		DialogueManager.instance.StartTestManagerMonologue ("1_16", 1, 0);
	}

	void Start_1_25 ()
	{
		DialogueManager.instance.StartTestManagerMonologue ("1_25", 1, 0);

		Invoke ("OpenDoorFloorToChildrensRoom", 2);

		GameObject.Find ("Interactable_Neutralizer").GetComponent<Rigidbody> ().isKinematic = false;
	}

	void Start_1_30 ()
	{
		print ("1_30");
		DialogueManager.instance.StartDialogueBetweenSubjectAndTestManager ("1_30", 1, 1, 0);
	}


	//------------------------------------
	//Act 1 Interactables with Dialogue
	//------------------------------------


	public void Start_1_Interactable_Door_Floor_01 (AudioSource audioSource, InteractableObject interactable)
	{
		SoundManager.instance.PlayEffect (audioSource, "KnockOnDoor", 1, 0);
		interactable.Disable ();
	}

	public void Start_1_Interactable_Door_Floor_02 (AudioSource audioSource, InteractableObject interactable)
	{
		SoundManager.instance.PlayEffect (audioSource, "ScreamingMan", 1, 0);
		interactable.Disable ();
		DialogueManager.instance.StartSubjectMonologue ("1_04", 1, 2);
	}

	void Start_1_Interactable_Wooden_Train_Happy (InteractableObject interactable)
	{
		interactable.Disable ();
		DialogueManager.instance.StartSubjectMonologue ("1_09", 1, 0);
		countClickedObjectsChildrensRoomHappy ();
	}

	void Start_1_Interactable_Frame_Family (InteractableObject interactable)
	{
		interactable.Disable ();
		DialogueManager.instance.StartSubjectMonologue ("1_10", 1, 0);
		countClickedObjectsChildrensRoomHappy ();
	}

	void Start_1_Interactable_Frame_Dog (InteractableObject interactable)
	{
		interactable.Disable ();
		DialogueManager.instance.StartSubjectMonologue ("1_11", 1, 0);
		countClickedObjectsChildrensRoomHappy ();
	}

	void Start_1_Interactable_Teddy_Happy (InteractableObject interactable)
	{
		interactable.Disable ();
		DialogueManager.instance.StartSubjectMonologue ("1_12", 1, 0);
		countClickedObjectsChildrensRoomHappy ();
	}

	void Start_1_Interactable_Light_Switch (AudioSource audioSource, InteractableObject interactable)
	{
		interactable.Disable ();
		SoundManager.instance.PlayBackgroundMusicLoop ("OrWasIt_Level1_1_provisionally", 1, 5);

		SwitchChildrooms ("Childroom_Sad", "Childroom_Happy");

		DialogueManager.instance.StartDialogueBetweenSubjectAndTestManagerAlterEgo ("1_17", 1, 1, 0);
	}

	void Start_1_Interactable_Beer_Bottles (InteractableObject interactable)
	{
		interactable.Disable ();
		DialogueManager.instance.StartSubjectMonologue ("1_20", 1, 0);
		countClickedObjectsChildrensRoomSad ();
	}

	void Start_1_Interactable_Cubes_Sad (InteractableObject interactable)
	{
		interactable.Disable ();
		DialogueManager.instance.StartSubjectMonologue ("1_21", 1, 0);
		countClickedObjectsChildrensRoomSad ();
	}

	void Start_1_Interactable_Frame_Friend (InteractableObject interactable)
	{
		interactable.Disable ();
		DialogueManager.instance.StartSubjectMonologue ("1_22", 1, 0);
		countClickedObjectsChildrensRoomSad ();
	}

	void Start_1_Interactable_Teddy_Sad (InteractableObject interactable)
	{
		interactable.Disable ();
		DialogueManager.instance.StartSubjectMonologue ("1_23", 1, 0);
		countClickedObjectsChildrensRoomSad ();
	}

	void Start_1_Interactable_Wooden_Train_Sad (InteractableObject interactable)
	{
		interactable.Disable ();
		DialogueManager.instance.StartSubjectMonologue ("1_24", 1, 0);
		countClickedObjectsChildrensRoomSad ();
	}

	void Start_1_Interactable_Neutralizer (InteractableObject interactable)
	{
		interactable.Disable ();
		GameObject.Find ("Interactable_Door_Floor_Childrens_Room").GetComponent<InteractableDoorFloorToChildrensRoom> ().CloseDoor ();
		SwitchChildrooms ("Childroom_Sober", "Childroom_Sad");
		SoundManager.instance.StopBackgroundMusic (0);
		Invoke ("OpenDoorFloorToChildrensRoom", 13);

		DialogueManager.instance.StartDialogueBetweenSubjectAndTestManager ("1_27", 1, 1, 0);

	}

	//------------------------------------
	//Act 1 Interactables without Dialogue
	//------------------------------------

	public void Start_1_Interactable_Door_Floor_To_Childrens_Room (AudioSource audioSource, InteractableDoorFloorToChildrensRoom interactable)
	{
		SoundManager.instance.PlayEffect (audioSource, "doorlocked", 1, 0);
		interactable.Disable ();

	}

	void Start_1_Interactable_Door_Childrens_Room_To_Garden (AudioSource audioSource, InteractableObject interactable)
	{
		SoundManager.instance.PlayEffect (audioSource, "dooropen", 1, 0);
		SceneManager.LoadScene ("Level2");
	}

	//---------------------------
	//Act 1 Additional Functions
	//---------------------------

	//A certain number of Interactables in Level 1 Childrens Room Happy need to be clicked in Order for the game to continue
	void countClickedObjectsChildrensRoomHappy ()
	{
		clickedObjectsInChildrensRoomHappy++;
		print (clickedObjectsInChildrensRoomHappy);
		if (clickedObjectsInChildrensRoomHappy == 3) {
			Invoke ("Start_1_16", 8);
		}
	}

	//A certain number of Interactables in Level 1 Childrens Room Sad need to be clicked in Order for the game to continue
	void countClickedObjectsChildrensRoomSad ()
	{
		clickedObjectsInChildrensRoomSad++;
		print (clickedObjectsInChildrensRoomSad);
		if (clickedObjectsInChildrensRoomSad == 3) {
			Invoke ("Start_1_25", 8);
		}
	}


	void OpenDoorFloorToChildrensRoom ()
	{
		SoundManager.instance.PlayEffect (GameObject.Find ("Interactable_Door_Floor_Childrens_Room").GetComponent<AudioSource> (), "dooropen", 1, 0);
		GameObject.Find ("Interactable_Door_Floor_Childrens_Room").GetComponent<InteractableDoorFloorToChildrensRoom> ().OpenDoor ();
		GameObject.Find ("Interactable_Door_Floor_Childrens_Room").GetComponent<InteractableDoorFloorToChildrensRoom> ().Disable ();
	}

	void SwitchChildrooms (string roomToActivate, string RoomToDeactivate)
	{
		GameObject childrooms = GameObject.Find ("Childrooms");
		for (int i = 0; i < childrooms.transform.childCount; i++) {
			Transform childroom = childrooms.gameObject.transform.GetChild (i);
			if (childroom.name == roomToActivate) {
				childroom.gameObject.SetActive (true);
			}
			if (childroom.name == RoomToDeactivate) {
				childroom.gameObject.SetActive (false);
			}
		}
	}


	#endregion

	#region Level2 Act2


	//---------------------
	//Act 2 Main Dialogues
	//---------------------

	void Start_2_01 ()
	{
		DialogueManager.instance.StartTestManagerMonologue ("2_01", 1, 0);
	}
		

	void Start_2_04 (InteractableObject interactable)
	{
		//Pille 1

		interactable.Disable ();

		StartCoroutine (Start_2_04_Coroutine ());
	}

	IEnumerator Start_2_04_Coroutine () {
		SoundManager.instance.PlayEffect(GameObject.FindWithTag ("Player").GetComponent<AudioSource> (), "gulp", 1, 0);
		yield return new WaitForSeconds (1f);
		//Schwarzblende hier
		StartCoroutine (FadeToBlack (2f));
		yield return new WaitForSeconds (3f);
		RawImage black = GameObject.Find ("Black").GetComponent<RawImage> ();
		Color c = black.color;
		c.a = 0;
		black.color = c;
		GameObject.FindWithTag ("MainCamera").GetComponent<CameraController> ().ToggleBlur();
		GameObject.FindWithTag ("MainCamera").GetComponent<CameraController> ().TogglePlayerMovement ();
		SoundManager.instance.PlayEffect (GameObject.FindWithTag ("Player").GetComponent<AudioSource> (), "trip", 1, 0);
		yield return new WaitForSeconds (3f);
		SoundManager.instance.PlayBackgroundMusicLoop ("Synapsis_-_04_-_psy_experiment", 1, 5);
		SwitchHoardings ();
		SwitchStaticRaveElements ();
		SwitchDynamicRaveElements ();
		ToggleFriendOnMap ("Interactable_Friend_Fence");
		yield return new WaitForSeconds (2f);
		DialogueManager.instance.StartDialogueBetweenSubjectAndTestManager ("2_04", 1, 1, 0);
		yield return new WaitForSeconds (2f);
		GameObject.FindWithTag ("MainCamera").GetComponent<CameraController> ().ToggleBlur();
		GameObject.FindWithTag ("MainCamera").GetComponent<CameraController> ().TogglePlayerMovement ();
	}

	void Start_2_08 (InteractableObject interactable)
	{
		interactable.Disable ();
		DialogueManager.instance.StartDialogueBetweenSubjectAndFriend ("2_08", 1, 1, 0);
		Invoke ("TogglePillsInLevel2", 14f);
	}

	void Start_2_11 (InteractableObject interactable)
	{
		//Schwarzblende Starten

		//SoundManager.instance.PlayEffect (audioSource, "eat_pill", 1, 0);

		interactable.Destroy (0);

		GameObject.Find ("Interactable_Friend_Fence").GetComponent<InteractableObject> ().Destroy (11);

		//Hier eigentlich Alter Ego am Reden -> Anpassen!
		DialogueManager.instance.StartSubjectMonologue ("2_11", 1, 0);
	}

	void Start_2_12 ()
	{
		DialogueManager.instance.StartSubjectMonologue ("2_12", 1, 0);
		ToggleFriendOnMap ("Interactable_Friend_On_Way_01");
	}

	void Start_2_13 ()
	{
		//Hier eigentlich Alter Ego am Reden -> Anpassen!
		DialogueManager.instance.StartSubjectMonologue ("2_13", 1, 0);
	}

	void Start_2_14 ()
	{
		DialogueManager.instance.StartSubjectMonologue ("2_14", 1, 0);
		ToggleFriendOnMap ("Interactable_Friend_On_Way_02");
		ToggleFriendOnMap ("Interactable_Friend_Dome");
	}

	void Start_2_15 (InteractableObject interactable)
	{
		interactable.Disable ();
		DialogueManager.instance.StartDialogueBetweenSubjectAndFriend ("2_15", 1, 1, 0);

		Invoke ("Start_2_18", 30);
	}

	void Start_2_16 ()
	{
		DialogueManager.instance.StartSubjectMonologue ("2_16", 1, 0);
	}

	void Start_2_18 ()
	{
		//Wenn Spieler zu lange nicht die Pille nimmt.
		if (!playerHasTakenPill03) {
			DialogueManager.instance.StartTestManagerMonologue ("2_18", 1, 0);
		}
	}

	void Start_2_19 (InteractableObject interactable)
	{
		//Pille 3

		// Hier Schwarzblende

		interactable.Destroy (0);

		playerHasTakenPill03 = true;

		//Hier eigentlich Alter Ego am Reden -> Anpassen!
		DialogueManager.instance.StartSubjectMonologue ("2_19", 1, 0);

		SoundManager.instance.StopBackgroundMusic (0);

		GameObject.Find ("Interactable_DJ_Console").GetComponent<InteractableObject> ().Disable ();
		GameObject.Find ("Interactable_Keypad").GetComponent<InteractableObject> ().Disable ();

		//Hier noch Licht anpassen

		ToggleFriendOnMap ("Interactable_Friend_Dome");
		ToggleFriendOnMap ("Interactable_Friend_Dead");

		SwitchDynamicRaveElements ();
		SwitchAfterRaveElements ();
		EnableTriggerZonesAfterRave ();
		ToggleEmergencyLight ();
	}

	void Start_2_20 ()
	{
		//Hier eigentlich Alter Ego am Reden -> Anpassen!
		DialogueManager.instance.StartSubjectMonologue ("2_20", 1, 0);
	}

	void Start_2_21 ()
	{
		DialogueManager.instance.StartSubjectMonologue ("2_21", 1, 0);
	}

	void Start_2_22 ()
	{
		//Hier eigentlich Alter Ego am Reden -> Anpassen!
		DialogueManager.instance.StartSubjectMonologue ("2_22", 1, 0);
	}

	void Start_2_23 (InteractableObject interactable)
	{
		interactable.Disable ();
		DialogueManager.instance.StartDialogueBetweenSubjectAndTestManagerAlterEgo ("2_23", 1, 1, 0);

		//Am Ende des Dialoges hier Blackout

		Invoke ("Start_2_23_While_Blackout", 23);

	}

	void Start_2_23_While_Blackout ()
	{
		//Nach Aufwachen aus Blackout
		//Garten ist wieder im Ausgangszustand, ohne Rave
		SwitchHoardings ();
		SwitchStaticRaveElements ();
		SwitchAfterRaveElements ();
		ToggleFriendOnMap ("Interactable_Friend_Dead");
		ToggleEmergencyLight ();

		//Notiz mit Code Spawnen
		SpawnNoteCodeForKeypad ();
	}

	void Start_2_Reached_Friend_01 ()
	{
		ToggleFriendOnMap ("Interactable_Friend_On_Way_01");
		ToggleFriendOnMap ("Interactable_Friend_On_Way_02");
	}

	//----------------------------------
	//Act 2 Interactables with Dialogue
	//----------------------------------

	void Start_2_Interactable_Keypad (InteractableObject interactable)
	{
		interactable.Disable ();
		DialogueManager.instance.StartSubjectMonologue ("2_03", 1, 0);
	}

	void Start_2_Interactable_Dancers_On_Floor (InteractableObject interactable)
	{
		interactable.Disable ();
		DialogueManager.instance.StartSubjectMonologue ("2_06", 1, 0);
	}

	void Start_2_Dancing_People (InteractableObject interactable)
	{
		interactable.Disable ();
		DialogueManager.instance.StartSubjectMonologue ("2_07", 1, 0);
	}

	void Start_2_Interactable_DJ_Console (InteractableObject interactable)
	{
		interactable.Disable ();
		DialogueManager.instance.StartSubjectMonologue ("2_17", 1, 0);
	}

	void Start_2_Interactable_Note_Code_For_Keypad (InteractableObject interactable)
	{
		interactable.Disable ();
		DialogueManager.instance.StartDialogueBetweenSubjectAndTestManager ("2_28", 1, 1, 0);
		StartCoroutine (FadeToBlack (30f));

		//Am Ende des Dialogs hier Ende einleiten; Hier Endscreen und Abspann starten.
		Invoke ("TEST_KILL_GAME", 35);
	}

	void TEST_KILL_GAME ()
	{
		Application.Quit ();
	}

	private YieldInstruction fadeInstruction = new YieldInstruction ();

	IEnumerator FadeToBlack (float duration)
	{
		RawImage black = GameObject.Find ("Black").GetComponent<RawImage> ();
		float elapsedTime = 0.0f;
		Color c = black.color;
		print ("Start");
		while (elapsedTime < duration) {
			yield return fadeInstruction;
			elapsedTime += Time.deltaTime;
			c.a = Mathf.Clamp01 (elapsedTime / duration);
			black.color = c;
		}
		print ("End");

	}



	//------------------------------------
	//Act 2 Interactables without Dialogue
	//------------------------------------

	//Put additional Interactables here.

	//---------------------------
	//Act 2 Additional Functions
	//---------------------------

	void SwitchHoardings ()
	{
		GameObject hoardings = GameObject.Find ("Hoardings_Dynamic");
		for (int i = 0; i < hoardings.transform.childCount; i++) {
			Transform hoarding = hoardings.gameObject.transform.GetChild (i);
			hoarding.gameObject.SetActive (!hoarding.gameObject.activeSelf);
		}
	}

	void SwitchStaticRaveElements ()
	{
		GameObject rave = GameObject.Find ("Static_Rave_Elements");
		for (int i = 0; i < rave.transform.childCount; i++) {
			Transform raveElement = rave.gameObject.transform.GetChild (i);
			raveElement.gameObject.SetActive (!raveElement.gameObject.activeSelf);
		}
	}

	void SwitchDynamicRaveElements ()
	{
		GameObject rave = GameObject.Find ("Dynamic_Rave_Elements");
		for (int i = 0; i < rave.transform.childCount; i++) {
			Transform raveElement = rave.gameObject.transform.GetChild (i);
			raveElement.gameObject.SetActive (!raveElement.gameObject.activeSelf);
		}
	}

	void SwitchAfterRaveElements ()
	{
		GameObject rave = GameObject.Find ("After_Rave_Elements");
		for (int i = 0; i < rave.transform.childCount; i++) {
			Transform raveElement = rave.gameObject.transform.GetChild (i);
			raveElement.gameObject.SetActive (!raveElement.gameObject.activeSelf);
		}
	}

	void ToggleFriendOnMap (string friendName)
	{
		GameObject friendObject = GameObject.Find ("Friend");
		for (int i = 0; i < friendObject.transform.childCount; i++) {
			Transform friend = friendObject.gameObject.transform.GetChild (i);
			if (friend.name == friendName) {
				friend.gameObject.SetActive (!friend.gameObject.activeSelf);
			}
		}
	}

	void TogglePillsInLevel2 ()
	{
		GameObject pills = GameObject.Find ("Pills");
		for (int i = 0; i < pills.transform.childCount; i++) {
			Transform pill = pills.gameObject.transform.GetChild (i);
			if (pill.name == "Interactable_Pill_02" || pill.name == "Interactable_Pill_03") {
				pill.gameObject.SetActive (!pill.gameObject.activeSelf);
			}
		}
	}

	void EnableTriggerZonesAfterRave ()
	{
		GameObject triggerZones = GameObject.Find ("Trigger_Zones_After_Rave");

		for (int i = 0; i < triggerZones.transform.childCount; i++) {
			Transform triggerZone = triggerZones.gameObject.transform.GetChild (i);
			triggerZone.gameObject.SetActive (true);
		}
	}

	void ToggleEmergencyLight ()
	{
		GameObject lightEffects = GameObject.Find ("Light_Effects");

		for (int i = 0; i < lightEffects.transform.childCount; i++) {
			Transform emergencyLight = lightEffects.gameObject.transform.GetChild (i);
			if (emergencyLight.name == "Emergency_Light") {
				emergencyLight.gameObject.SetActive (!emergencyLight.gameObject.activeSelf);
			}
		}
	}

	void SpawnNoteCodeForKeypad ()
	{
		GameObject keypad = GameObject.Find ("Keypad");

		for (int i = 0; i < keypad.transform.childCount; i++) {
			Transform noteWithCode = keypad.gameObject.transform.GetChild (i);
			if (noteWithCode.name == "Interactable_Note_Code_For_Keypad") {
				noteWithCode.gameObject.SetActive (true);
			}
		}
	}

	#endregion

}
