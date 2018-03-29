using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{

	//Flags for Level 1
	private int clickedObjectsInHospitalRoom = 0;
	private int clickedObjectsInChildrensRoomHappy = 0;
	private int clickedObjectsInChildrensRoomSad = 0;
	private bool floorEntered = false;
	private bool allowedToSignContract = false;

	//---------------------
	//EventManager Init
	//---------------------

	void Start ()
	{
		if (SceneManager.GetActiveScene ().name == "Level1") {
			Start_0_01 ();
		}

		if (SceneManager.GetActiveScene ().name == "Level2") {
			Start_2_01 ();
		}
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
	public void OnInteractableClicked (string nameOfInteractable, AudioSource audioSource, InteractableObject interactable, Animator animator)
	{
		switch (nameOfInteractable) {

		//Level 1 Interactables:
		case "Interactable_Window":
			Start_0_Interactable_Window ();
			break;
		case "Interactable_Medical_Devices":
			Start_0_Interactable_Medical_Devices ();
			break;
		case "Interactable_Picture_Frame_Hospital":
			Start_0_Interactable_Picture_Frame ();
			break;
		case "Interactable_Mirror_Bath":
			Start_0_Interactable_Bath_Mirror ();
			break;
		case "Interactable_Contract":
			Start_0_Interactable_Contract (audioSource);
			break;
		case "Interactable_Rubber_Duck":
			Start_0_Interactable_Rubber_Duck (audioSource);
			break;
		case "Interactable_Desinfection":
			Start_0_Interactable_Desinfection (audioSource);
			break;
		case "Interactable_Door_Hospital_To_Floor":
			Start_0_Interactable_Door_Hospital_To_Floor (audioSource);
			break;
		case "Interactable_Door_Bathroom":
			Start_0_Interactable_Door_Bathroom (audioSource, animator);
			break;
		case "Interactable_Door_Floor_01":
			Start_1_Interactable_Door_Floor_01 (audioSource);
			break;
		case "Interactable_Door_Floor_02":
			Start_1_Interactable_Door_Floor_02 (audioSource);
			break;
		case "Interactable_Pill_Floor":
			Start_1_05 (audioSource);
			break;
		case "Interactable_Door_Floor_To_Childrens_Room":
			Start_1_Interactable_Door_Floor_To_Childrens_Room (audioSource);
			break;
		case "Interactable_Wooden_Train_Happy":
			Start_1_Interactable_Wooden_Train_Happy ();
			break;
		case "Interactable_Frame_Family":
			Start_1_Interactable_Frame_Family ();
			break;
		case "Interactable_Frame_Dog":
			Start_1_Interactable_Frame_Dog ();
			break;
		case "Interactable_Teddy":
			Start_1_Interactable_Teddy_Happy ();
			break;
		case "Interactable_Light_Switch":
			Start_1_Interactable_Light_Switch (audioSource);
			break;
		case "Interactable_Beer_Bottle":
			Start_1_Interactable_Beer_Bottles ();
			break;
		case "Interactable_Cubes_Sad":
			Start_1_Interactable_Cubes_Sad ();
			break;
		case "Interactable_Frame_Friend_Sad":
			Start_1_Interactable_Frame_Friend ();
			break;
		case "Interactable_Teddy_Sad":
			Start_1_Interactable_Teddy_Sad ();
			break;
		case "Interactable_Wooden_Train_Sad":
			Start_1_Interactable_Wooden_Train_Sad ();
			break;
		case "Interactable_Door_Childrens_Room_To_Garden":
			Start_1_Interactable_Door_Childrens_Room_To_Garden (audioSource);
			break;
		case "Interactable_Neutralizer":
			Start_1_Interactable_Neutralizer ();
			break;

		//Level 2 Interactables:
		case "Interactable_Keypad":
			Start_2_Interactable_Keypad ();
			break;
		case "Interactable_DJ_Console":
			Start_2_Interactable_DJ_Console ();
			break;
		case "Interactable_Pill_01":
			Start_2_04 (audioSource);
			break;
		case "Interactable_Dancer":
			Start_2_Dancing_People ();
			break;
		case "Interactable_Dancer_On_Floor":
			Start_2_Interactable_Dancers_On_Floor ();
			break;
		case "Interactable_Friend_Fence":
			Start_2_08 (interactable);
			break;
		case "Interactable_Pill_02":
			Start_2_11 (audioSource, interactable);
			break;
		case "Interactable_Friend_Dome":
			Start_2_16 ();
			break;
		case "Interactable_Pill_03":
			Start_2_19 (audioSource);
			break;
		case "Interactable_Friend_Dead":
			Start_2_23 ();
			break;
		case "Interactable_Note_Code_For_Keypad":
			Start_2_Interactable_Note_Code_For_Keypad ();
			break;
		}
	}

	#region Level1 Act 0

	//---------------------
	//Act 0 Main Dialogues
	//---------------------

	void Start_0_01 ()
	{
		DialogueManager.instance.StartSubjectMonologue ("0_01");
	}

	//----------------------------------
	//Act 0 Interactables with Dialogue
	//----------------------------------

	void Start_0_Interactable_Window ()
	{
		DialogueManager.instance.StartSubjectMonologue ("0_02");
	}

	void Start_0_Interactable_Medical_Devices ()
	{
		DialogueManager.instance.StartSubjectMonologue ("0_03");
	}

	void Start_0_Interactable_Picture_Frame ()
	{
		DialogueManager.instance.StartSubjectMonologue ("0_04");
		CountClickedObjectsInHospitalRoom ();
	}

	void Start_0_Interactable_Bath_Mirror ()
	{
		DialogueManager.instance.StartSubjectMonologue ("0_05");
	}

	void Start_0_Interactable_Contract (AudioSource audioSource)
	{
		if (!allowedToSignContract) {
			DialogueManager.instance.StartSubjectMonologue ("0_06");
			CountClickedObjectsInHospitalRoom ();
		} else {
			StartCoroutine (Start_0_Interactable_Contract_Coroutine (audioSource));
		}
	}

	void Start_0_Interactable_Door_Hospital_To_Floor (AudioSource audioSource)
	{
		SoundManager.instance.PlayEffect (audioSource, "doorlocked");

		if (!floorEntered) {
			DialogueManager.instance.StartSubjectMonologue ("0_07");
			CountClickedObjectsInHospitalRoom ();
		} else {
			DialogueManager.instance.StartTestManagerMonologue ("1_03");
		}

	}

	//------------------------------------
	//Act 0 Interactables without Dialogue
	//------------------------------------

	void Start_0_Interactable_Door_Bathroom (AudioSource audioSource, Animator animator)
	{
		SoundManager.instance.PlayEffect (audioSource, "dooropen");
		animator.SetTrigger("doorBathOpen");
	}

	void Start_0_Interactable_Rubber_Duck (AudioSource audioSource)
	{
		System.Random random = new System.Random ();
		string clipName = "quack0" + random.Next (1, 5);
		SoundManager.instance.PlayEffect (audioSource, clipName);
	}

	void Start_0_Interactable_Desinfection (AudioSource audioSource)
	{
		SoundManager.instance.PlayEffect (audioSource, "desinfectant1");
	}

	//---------------------------
	//Act 0 Coroutines
	//---------------------------

	//Because there are multiple timed Events happening on Interaction with the Contract, we need a Coroutine here.
	IEnumerator Start_0_Interactable_Contract_Coroutine (AudioSource audioSource)
	{
		EffectManager.instance.TogglePlayerMovement ();

		DialogueManager.instance.StartDialogueBetweenSubjectAndTestManager ("0_15");
		yield return new WaitForSecondsRealtime (15);
		SoundManager.instance.PlayEffect (audioSource, "signature");
		yield return new WaitForSecondsRealtime (3);

		EffectManager.instance.TogglePlayerMovement ();

		DialogueManager.instance.StartTestManagerMonologue ("0_17");
		yield return new WaitForSecondsRealtime (6);
		OpenDoorHospitalToFloor ();
	}


	IEnumerator Start_0_08_Coroutine ()
	{
		//If another Dialogue is currently running, we wait here until that dialogue is finished.
		while (DialogueManager.instance.IsDialoguePlaying ()) {
			yield return null;

		}

		//After all previous dialogues finished, we wait another second, before the current dialogue starts.
		yield return new WaitForSecondsRealtime (1f);

		DialogueManager.instance.StartDialogueBetweenSubjectAndTestManager ("0_08");
		EnableInteractableContractForSecondInteraction ();
	}

	//---------------------------
	//Act 0 Additional Functions
	//---------------------------


	//A certain number of Interactables in the Hospital Room need to be clicked in order for the game to continue
	void CountClickedObjectsInHospitalRoom ()
	{
		clickedObjectsInHospitalRoom++;
		if (clickedObjectsInHospitalRoom == 3) {
			StartCoroutine (Start_0_08_Coroutine ());
		}
	}

	//Open the Door that connects the Hospital Room and the floor
	void OpenDoorHospitalToFloor ()
	{
		GameObject doorHospitalToFloor = GameObject.Find ("Interactable_Door_Hospital_To_Floor");
		SoundManager.instance.PlayEffect (doorHospitalToFloor.GetComponent<AudioSource> (), "dooropen");
		doorHospitalToFloor.GetComponent<Animator> ().SetTrigger("doorOpen");
	}

	//After the Testmanager talks to the Subject, Interaction with the Contract needs to be activated again
	void EnableInteractableContractForSecondInteraction ()
	{
		allowedToSignContract = true;
		GameObject.Find ("Interactable_Contract").GetComponent<InteractableObject> ().Enable ();
	}



	#endregion






	#region Level1 Act1

	//---------------------
	//Act 1 Main Dialogues
	//---------------------

	//Initial Dialogue when player enters the Floor
	void Start_1_01 ()
	{
		StartCoroutine (Start_1_01_Coroutine ());
	}


	void Start_1_05 (AudioSource audioSource)
	{
		StartCoroutine (Start_1_05_Coroutine (audioSource));
	}

	void Start_1_06 ()
	{
		CloseDoorFloorToChildrensRoom ();
		DialogueManager.instance.StartDialogueBetweenSubjectAndTestManagerAlterEgo ("1_06");
	}

	void Start_1_30 ()
	{
		DialogueManager.instance.StartDialogueBetweenSubjectAndTestManager ("1_30");
	}


	//------------------------------------
	//Act 1 Interactables with Dialogue
	//------------------------------------


	void Start_1_Interactable_Door_Floor_01 (AudioSource audioSource)
	{
		SoundManager.instance.PlayEffect (audioSource, "KnockOnDoor");
	}

	void Start_1_Interactable_Door_Floor_02 (AudioSource audioSource)
	{
		StartCoroutine (Start_1_Interactable_Door_Floor_02_Coroutine (audioSource));
	}

	void Start_1_Interactable_Wooden_Train_Happy ()
	{
		DialogueManager.instance.StartSubjectMonologue ("1_09");
		countClickedObjectsChildrensRoomHappy ();
	}

	void Start_1_Interactable_Frame_Family ()
	{
		DialogueManager.instance.StartTestManagerAlterEgoMonologue ("1_10");
		countClickedObjectsChildrensRoomHappy ();
	}

	void Start_1_Interactable_Frame_Dog ()
	{
		DialogueManager.instance.StartTestManagerAlterEgoMonologue ("1_11");
		countClickedObjectsChildrensRoomHappy ();
	}

	void Start_1_Interactable_Teddy_Happy ()
	{
		DialogueManager.instance.StartSubjectMonologue ("1_12");
		countClickedObjectsChildrensRoomHappy ();
	}

	void Start_1_Interactable_Light_Switch (AudioSource audioSource)
	{
		SoundManager.instance.PlayEffect (audioSource, "lightswitch");
		SwitchChildrooms ("Childroom_Sad", "Childroom_Happy");
		DialogueManager.instance.StartDialogueBetweenSubjectAndTestManagerAlterEgo ("1_17");
		SoundManager.instance.PlayBackgroundMusicLoop ("OrWasIt_Level1_1_provisionally", 1, 5);
	}

	void Start_1_Interactable_Beer_Bottles ()
	{
		DialogueManager.instance.StartSubjectMonologue ("1_20");
		countClickedObjectsChildrensRoomSad ();
	}

	void Start_1_Interactable_Cubes_Sad ()
	{
		DialogueManager.instance.StartSubjectMonologue ("1_21");
		countClickedObjectsChildrensRoomSad ();
	}

	void Start_1_Interactable_Frame_Friend ()
	{
		DialogueManager.instance.StartTestManagerAlterEgoMonologue ("1_22");
		countClickedObjectsChildrensRoomSad ();
	}

	void Start_1_Interactable_Teddy_Sad ()
	{
		DialogueManager.instance.StartSubjectMonologue ("1_23");
		countClickedObjectsChildrensRoomSad ();
	}

	void Start_1_Interactable_Wooden_Train_Sad ()
	{
		DialogueManager.instance.StartSubjectMonologue ("1_24");
		countClickedObjectsChildrensRoomSad ();
	}

	void Start_1_Interactable_Neutralizer ()
	{
		StartCoroutine (Start_1_Interactable_Neutralizer_Coroutine ());
	}



	//------------------------------------
	//Act 1 Interactables without Dialogue
	//------------------------------------

	void Start_1_Interactable_Door_Floor_To_Childrens_Room (AudioSource audioSource)
	{
		SoundManager.instance.PlayEffect (audioSource, "doorlocked");
	}

	void Start_1_Interactable_Door_Childrens_Room_To_Garden (AudioSource audioSource)
	{
		SoundManager.instance.PlayEffect (audioSource, "dooropen");
		StartCoroutine(LoadLevelTwo ());
	}

	//---------------------------
	//Act 1 Coroutines
	//---------------------------

	IEnumerator Start_1_01_Coroutine ()
	{
		CloseDoorHospitalToFloor ();
		DeactivateCamerasInHospitalRoom ();
		GameObject.Find ("Interactable_Door_Hospital_To_Floor").GetComponent<InteractableObject> ().Enable ();
		floorEntered = true;
		DialogueManager.instance.StartTestManagerMonologue ("1_01");
		yield return new WaitForSecondsRealtime (6);

		DropNeutralizerInTray ();
	}

	IEnumerator Start_1_Interactable_Door_Floor_02_Coroutine (AudioSource audioSource)
	{
		SoundManager.instance.PlayEffect (audioSource, "ScreamingMan");
		yield return new WaitForSecondsRealtime (3);
		DialogueManager.instance.StartSubjectMonologue ("1_04");
	}

	IEnumerator Start_1_05_Coroutine (AudioSource audioSource)
	{
		EffectManager.instance.StartFirstPartOfTrip (audioSource);

		yield return new WaitForSecondsRealtime (10f);

		SoundManager.instance.PlayBackgroundMusicLoop ("DarnParadise_Level1_0", 1, 5);

		EffectManager.instance.StartLastPartOfTrip ();
		yield return new WaitForSecondsRealtime (6f);

		OpenDoorFloorToChildrensRoom ();
	}

	IEnumerator Start_1_16_Coroutine ()
	{
		while (DialogueManager.instance.IsDialoguePlaying ()) {
			yield return null;
		}
		yield return new WaitForSecondsRealtime (2f);
		DialogueManager.instance.StartTestManagerMonologue ("1_16");
	}

	IEnumerator Start_1_25_Coroutine ()
	{
		while (DialogueManager.instance.IsDialoguePlaying ()) {
			yield return null;
		}
		DialogueManager.instance.StartTestManagerMonologue ("1_25");
		yield return new WaitForSecondsRealtime (2);
		//Prevent Player from Getting Crushed here!
		OpenDoorFloorToChildrensRoom ();
		yield return new WaitForSecondsRealtime (2);
		GameObject.Find ("Interactable_Neutralizer").GetComponent<Rigidbody> ().isKinematic = false;
	}

	//When the Player interacts with the Neutralizer
	IEnumerator Start_1_Interactable_Neutralizer_Coroutine ()
	{
		CloseDoorFloorToChildrensRoom ();
		yield return new WaitForSecondsRealtime (1f);
		SwitchChildrooms ("Childroom_Sober", "Childroom_Sad");

		EffectManager.instance.StartNeutralizerTrip ();
		yield return new WaitForSecondsRealtime (15f);

		DialogueManager.instance.StartDialogueBetweenSubjectAndTestManager ("1_27");
		yield return new WaitForSecondsRealtime (14f);
		OpenDoorFloorToChildrensRoom ();
	}

	IEnumerator LoadLevelTwo ()
	{
		//Disable all Movements here

		Slider slider = null;

		GameObject canvas = GameObject.Find ("Canvas");
		for (int i = 0; i < canvas.transform.childCount; i++) {
			Transform canvasElement = canvas.gameObject.transform.GetChild (i);
			if (canvasElement.name == "LoadingBar") {
				canvasElement.gameObject.SetActive (true);
				slider = canvasElement.GetComponent<Slider>();
				break;
			}
		}


		StartCoroutine (FadeToBlack (0.5f));
		AsyncOperation loadLevelTwoAsync = SceneManager.LoadSceneAsync ("Level2");
		while (!loadLevelTwoAsync.isDone) {
			print ("Progress:" + Mathf.Clamp01 (loadLevelTwoAsync.progress / 0.9f) * 100f + "%");
			float progress = Mathf.Clamp01(loadLevelTwoAsync.progress / 0.9f);
			slider.value = progress;
			yield return null;
		}
			
	}

	//---------------------------
	//Act 1 Additional Functions
	//---------------------------

	//To improve Performance, the Cameras in the Hospital Room can be deactivated here after the door is closed.
	void DeactivateCamerasInHospitalRoom ()
	{
		Destroy (GameObject.Find ("Surveillance_Camera_Hospital_01"));
		Destroy (GameObject.Find ("Surveillance_Camera_Hospital_02"));
	}

	//A certain number of Interactables in Level 1 Childrens Room Happy need to be clicked in Order for the game to continue
	void countClickedObjectsChildrensRoomHappy ()
	{
		clickedObjectsInChildrensRoomHappy++;
		if (clickedObjectsInChildrensRoomHappy == 3) {
			StartCoroutine (Start_1_16_Coroutine ());
		}
	}

	//A certain number of Interactables in Level 1 Childrens Room Sad need to be clicked in Order for the game to continue
	void countClickedObjectsChildrensRoomSad ()
	{
		clickedObjectsInChildrensRoomSad++;
		if (clickedObjectsInChildrensRoomSad == 3) {
			StartCoroutine (Start_1_25_Coroutine ());
		}
	}

	void CloseDoorHospitalToFloor ()
	{
		GameObject doorHospitalToFloor = GameObject.Find ("Interactable_Door_Hospital_To_Floor");

		SoundManager.instance.PlayEffect (doorHospitalToFloor.GetComponent<AudioSource> (), "doorclose");
		doorHospitalToFloor.GetComponent<Animator> ().SetTrigger("doorClose");
	}


	void OpenDoorFloorToChildrensRoom ()
	{
		GameObject doorFloorToChildrensRoom = GameObject.Find ("Interactable_Door_Floor_To_Childrens_Room");

		SoundManager.instance.PlayEffect (doorFloorToChildrensRoom.GetComponent<AudioSource> (), "dooropen");
		doorFloorToChildrensRoom.GetComponent<Animator> ().SetTrigger("doorOpen");
	}

	void CloseDoorFloorToChildrensRoom ()
	{
		GameObject doorFloorToChildrensRoom = GameObject.Find ("Interactable_Door_Floor_To_Childrens_Room");

		SoundManager.instance.PlayEffect (doorFloorToChildrensRoom.GetComponent<AudioSource> (), "doorclose");
		doorFloorToChildrensRoom.GetComponent<Animator> ().SetTrigger("doorClose");
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

	void DropNeutralizerInTray () 
	{
		GameObject.Find ("Interactable_Pill_Floor").GetComponent<Rigidbody> ().isKinematic = false;
		//Play DropSound here
	}
		

	#endregion







	#region Level2 Act2

	//---------------------
	//Act 2 Main Dialogues
	//---------------------

	//The initial Dialogue for Level 2. Gets played when the scene is loaded.
	void Start_2_01 ()
	{
		DialogueManager.instance.StartTestManagerMonologue ("2_01");
	}


	void Start_2_04 (AudioSource audioSource)
	{
		StartCoroutine (Start_2_04_Coroutine (audioSource));
	}

	void Start_2_08 (InteractableObject interactable)
	{
		StartCoroutine (Start_2_08_Coroutine ());
	}

	void Start_2_11 (AudioSource audioSource, InteractableObject interactable)
	{
		interactable.Destroy (0);
		StartCoroutine (Start_2_11_Coroutine (audioSource));
	}

	void Start_2_12 ()
	{
		DialogueManager.instance.StartSubjectMonologue ("2_12");
		ToggleFriendOnMap ("Friend_On_Way_01");
	}

	void Start_2_13 ()
	{
		DialogueManager.instance.StartTestManagerAlterEgoMonologue ("2_13");
	}

	void Start_2_14 ()
	{
		DialogueManager.instance.StartSubjectMonologue ("2_14");
		ToggleFriendOnMap ("Friend_On_Way_02");
		ToggleFriendOnMap ("Interactable_Friend_Dome");
	}

	void Start_2_15 ()
	{
		DialogueManager.instance.StartSubjectMonologue ("2_15");
	}

	void Start_2_16 ()
	{
		StartCoroutine (Start_2_16_Coroutine ());
	}


	//Pille 3
	void Start_2_19 (AudioSource audioSource)
	{
		DisableInteractablesOnRaveEnding ();

		StartCoroutine (Start_2_19_Coroutine (audioSource));
	}

	void Start_2_20 ()
	{
		DialogueManager.instance.StartTestManagerAlterEgoMonologue ("2_20");
	}

	void Start_2_21 ()
	{
		DialogueManager.instance.StartSubjectMonologue ("2_21");
	}

	void Start_2_22 ()
	{
		DialogueManager.instance.StartTestManagerAlterEgoMonologue ("2_22");
	}

	void Start_2_23 ()
	{
		StartCoroutine (Start_2_23_Coroutine ());
	}

	void Start_2_Reached_Friend_01 ()
	{
		ToggleFriendOnMap ("Friend_On_Way_01");
		ToggleFriendOnMap ("Friend_On_Way_02");
	}

	//----------------------------------
	//Act 2 Interactables with Dialogue
	//----------------------------------

	//When the player interacts with the keypad at the door
	void Start_2_Interactable_Keypad ()
	{
		DialogueManager.instance.StartSubjectMonologue ("2_03");
	}

	//When the player looks at the group of passed out people on the floor in the parking lot
	void Start_2_Interactable_Dancers_On_Floor ()
	{
		DialogueManager.instance.StartSubjectMonologue ("2_06");
	}

	//When the player looks at the group of dancers in the parking lot
	void Start_2_Dancing_People ()
	{
		DialogueManager.instance.StartSubjectMonologue ("2_07");
	}

	//When the player talks to the DJ
	void Start_2_Interactable_DJ_Console ()
	{
		DialogueManager.instance.StartSubjectMonologue ("2_17");
	}

	//When the player interacts with the Note that contains the Code for the Lock
	void Start_2_Interactable_Note_Code_For_Keypad ()
	{
		StartCoroutine (Start_2_Interactable_Note_Code_For_Keypad_Coroutine ());
	}

	//---------------------------
	//Act 2 Coroutines
	//---------------------------

	IEnumerator Start_2_04_Coroutine (AudioSource audioSource)
	{
		//Beginning of Trip
		EffectManager.instance.StartFirstPartOfTrip (audioSource);
		yield return new WaitForSecondsRealtime (8f);


		//During Trip
		SoundManager.instance.PlayBackgroundMusicLoop ("Synapsis_-_04_-_psy_experiment", 0.4f, 10);
		SwitchHoardings ();
		yield return new WaitForSecondsRealtime (4f);
		SwitchStaticRaveElements ();
		yield return new WaitForSecondsRealtime (4f);
		SwitchDynamicRaveElements ();
		ToggleFriendOnMap ("Interactable_Friend_Fence");


		//End of Trip
		EffectManager.instance.StartLastPartOfTrip ();
		yield return new WaitForSeconds (6f);

		//After Trip Ending
		DialogueManager.instance.StartDialogueBetweenSubjectAndTestManagerAlterEgo("2_04");
	}
		
	IEnumerator Start_2_08_Coroutine ()
	{
		DialogueManager.instance.StartDialogueBetweenSubjectAndFriend ("2_08");
		yield return new WaitForSecondsRealtime (16f);
		TogglePillsInLevel2 ();
	}

	IEnumerator Start_2_11_Coroutine (AudioSource audioSource)
	{
		//Beginning of Trip
		EffectManager.instance.StartFirstPartOfTrip (audioSource);
		yield return new WaitForSecondsRealtime (6f);

		//During Trip
		DialogueManager.instance.StartTestManagerAlterEgoMonologue ("2_11");
		yield return new WaitForSecondsRealtime (10f);

		//End of Trip
		EffectManager.instance.StartLastPartOfTrip ();
		yield return new WaitForSecondsRealtime (6f);

		//After Trip Ending
		GameObject.Find ("Interactable_Friend_Fence").GetComponent<InteractableObject> ().Destroy (0);
	}


	IEnumerator Start_2_16_Coroutine ()
	{
		DialogueManager.instance.StartFriendMonologue ("2_16");
		yield return new WaitForSecondsRealtime (13f);
		DialogueManager.instance.StartTestManagerMonologue ("2_18");
	}


	IEnumerator Start_2_19_Coroutine (AudioSource audioSource)
	{
		//Beginning of Trip
		EffectManager.instance.StartFirstPartOfTrip (audioSource);
		yield return new WaitForSecondsRealtime (6f);

		//During Trip
		ToggleFriendOnMap ("Interactable_Friend_Dome");
		ToggleFriendOnMap ("Interactable_Friend_Dead");
		SwitchDynamicRaveElements ();
		SwitchAfterRaveElements ();
		EnableTriggerZonesAfterRave ();
		SoundManager.instance.StopBackgroundMusic (5f);

		yield return new WaitForSecondsRealtime (4f);
		ToggleEmergencyLight ();

		//End of Trip
		EffectManager.instance.StartLastPartOfTrip ();
		yield return new WaitForSeconds (6f);

		//After Trip Ending
		DialogueManager.instance.StartTestManagerAlterEgoMonologue ("2_19");
	}


	IEnumerator Start_2_23_Coroutine ()
	{
		DialogueManager.instance.StartDialogueBetweenSubjectAndTestManagerAlterEgo ("2_23");
		yield return new WaitForSecondsRealtime (20f);

		StartCoroutine (FadeToBlack (3f));
		yield return new WaitForSeconds (4f);

		SwitchHoardings ();
		SwitchStaticRaveElements ();
		SwitchAfterRaveElements ();
		ToggleFriendOnMap ("Interactable_Friend_Dead");
		ToggleEmergencyLight ();

		//Spawn Note with Code to Keypad
		SpawnNoteCodeForKeypad ();
		yield return new WaitForSeconds (4f);

		Image black = GameObject.Find ("Black").GetComponent<Image> ();
		HideImage (black);
	}



	IEnumerator Start_2_Interactable_Note_Code_For_Keypad_Coroutine ()
	{
		DialogueManager.instance.StartDialogueBetweenSubjectAndTestManager ("2_28");
		yield return new WaitForSecondsRealtime (15f);
		StartCoroutine (FadeToBlack (15f));
		yield return new WaitForSecondsRealtime (16f);

		//Am Ende des Dialogs hier Ende einleiten; Hier Endscreen und Abspann starten.
		Application.Quit ();
	}

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

	//There are additional Trigger Zones in Level 2 that are only needed for the way back to the parking lot, after the rave has ended
	void EnableTriggerZonesAfterRave ()
	{
		GameObject triggerZones = GameObject.Find ("Trigger_Zones_After_Rave");

		for (int i = 0; i < triggerZones.transform.childCount; i++) {
			Transform triggerZone = triggerZones.gameObject.transform.GetChild (i);
			triggerZone.gameObject.SetActive (true);
		}
	}

	void DisableInteractablesOnRaveEnding()
	{
		GameObject.Find ("Interactable_DJ_Console").GetComponent<InteractableObject> ().Disable ();
		GameObject.Find ("Interactable_Keypad").GetComponent<InteractableObject> ().Disable ();
	}

	//Activate/Deactivate the Siren at the parking lot
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

	//Enable the Note that contains the code for the Keypad that is needed at the end of the game.
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










	IEnumerator FadeToBlack (float duration)
	{
		Image black = GameObject.Find ("Black").GetComponent<Image> ();
		float elapsedTime = 0.0f;
		Color c = black.color;
		print ("Start");
		while (elapsedTime < duration) {
			elapsedTime += Time.deltaTime;
			c.a = Mathf.Clamp01 (elapsedTime / duration);
			black.color = c;
			yield return null;
		}
		print ("End");

	}


	private void HideImage (Image image)
	{
		Color imageColor = image.color;
		imageColor.a = 0;
		image.color = imageColor;
	}




}
