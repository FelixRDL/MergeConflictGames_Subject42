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
		case "Interactable_Contract":
			Start_0_Interactable_Contract (audioSource, interactable);
			break;
		case "Interactable_Rubber_Duck":
			Start_0_Interactable_Rubber_Duck (audioSource);
			break;
		case "Interactable_Desinfection":
			Start_0_Interactable_Desinfection (audioSource, interactable);
			break;
		case "Interactable_Door_Hospital_To_Floor":
			Start_0_Interactable_Door_Hospital_To_Floor (audioSource, interactable);
			break;
		case "Interactable_Door_Bathroom":
			Start_0_Interactable_Door_Bathroom (audioSource, interactable, animator);
			break;
		case "Interactable_Door_Floor_01":
			Start_1_Interactable_Door_Floor_01 (audioSource, interactable);
			break;
		case "Interactable_Door_Floor_02":
			Start_1_Interactable_Door_Floor_02 (audioSource, interactable);
			break;
		case "Interactable_Pill_Floor":
			Start_1_05 (audioSource, interactable);
			break;
		case "Interactable_Door_Floor_To_Childrens_Room":
			Start_1_Interactable_Door_Floor_To_Childrens_Room (audioSource, interactable);
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
			Start_2_04 (audioSource, interactable);
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
			Start_2_11 (audioSource, interactable);
			break;
		case "Interactable_Friend_Dome":
			Start_2_16 (interactable);
			break;
		case "Interactable_Pill_03":
			Start_2_19 (audioSource, interactable);
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
		DialogueManager.instance.StartSubjectMonologue ("0_01");
	}

	//----------------------------------
	//Act 0 Interactables with Dialogue
	//----------------------------------

	void Start_0_Interactable_Window (InteractableObject interactable)
	{
		DialogueManager.instance.StartSubjectMonologue ("0_02");
	}

	void Start_0_Interactable_Medical_Devices (InteractableObject interactable)
	{
		DialogueManager.instance.StartSubjectMonologue ("0_03");
	}

	void Start_0_Interactable_Picture_Frame (InteractableObject interactable)
	{
		DialogueManager.instance.StartSubjectMonologue ("0_04");
		CountClickedObjectsInHospitalRoom ();
	}

	void Start_0_Interactable_Bath_Mirror (InteractableObject interactable)
	{
		DialogueManager.instance.StartSubjectMonologue ("0_05");
	}

	void Start_0_Interactable_Contract (AudioSource audioSource, InteractableObject interactable)
	{
		if (!allowedToSignContract) {
			DialogueManager.instance.StartSubjectMonologue ("0_06");
			CountClickedObjectsInHospitalRoom ();
		} else {
			StartCoroutine (Start_0_Interactable_Contract_Coroutine (audioSource));
		}
	}

	public void Start_0_Interactable_Door_Hospital_To_Floor (AudioSource audioSource, InteractableObject interactable)
	{
		interactable.Disable ();
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

	public void Start_0_Interactable_Door_Bathroom (AudioSource audioSource, InteractableObject interactable, Animator animator)
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

	void Start_0_Interactable_Desinfection (AudioSource audioSource, InteractableObject interactable)
	{
		SoundManager.instance.PlayEffect (audioSource, "quack04");
	}

	//---------------------------
	//Act 0 Coroutines
	//---------------------------

	//Because there are multiple timed Events happening on Interaction with the Contract, we need a Coroutine here.
	IEnumerator Start_0_Interactable_Contract_Coroutine (AudioSource audioSource)
	{
		GameObject.FindWithTag ("MainCamera").GetComponent<CameraController> ().TogglePlayerMovement ();

		DialogueManager.instance.StartDialogueBetweenSubjectAndTestManager ("0_15");
		yield return new WaitForSecondsRealtime (15);
		SoundManager.instance.PlayEffect (audioSource, "signature");
		yield return new WaitForSecondsRealtime (3);

		GameObject.FindWithTag ("MainCamera").GetComponent<CameraController> ().TogglePlayerMovement ();

		DialogueManager.instance.StartTestManagerMonologue ("0_17");
		yield return new WaitForSecondsRealtime (6);
		OpenDoorHospitalToFloor ();
	}


	//Because there are multiple timed Events happening on Interaction with the Contract, we need a Coroutine here.
	IEnumerator Start_0_Interactable_Contract_One_Coroutine (AudioSource audioSource)
	{
		DialogueManager.instance.StartSubjectMonologue ("0_13");
		yield return new WaitForSecondsRealtime (2.5f);
		SoundManager.instance.PlayEffect (audioSource, "signature");
		yield return new WaitForSecondsRealtime (3);
		ToggleContract ("Interactable_Contract_01");
		ToggleContract ("Interactable_Contract_02");
	}

	//Because there are multiple timed Events happening on Interaction with the Contract, we need a Coroutine here.
	IEnumerator Start_0_Interactable_Contract_Two_Coroutine (AudioSource audioSource)
	{
		DialogueManager.instance.StartSubjectMonologue ("0_14");
		yield return new WaitForSecondsRealtime (6);
		SoundManager.instance.PlayEffect (audioSource, "signature");
		yield return new WaitForSecondsRealtime (3);
		ToggleContract ("Interactable_Contract_02");
		ToggleContract ("Interactable_Contract_03");
	}

	//Because there are multiple timed Events happening on Interaction with the Contract, we need a Coroutine here.
	IEnumerator Start_0_Interactable_Contract_Three_Coroutine (AudioSource audioSource)
	{
		DialogueManager.instance.StartDialogueBetweenSubjectAndTestManager ("0_15");
		yield return new WaitForSecondsRealtime (15);
		SoundManager.instance.PlayEffect (audioSource, "signature");
		yield return new WaitForSecondsRealtime (3);
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
		allowedToSignContract = true;
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

	void OpenDoorHospitalToFloor ()
	{
		GameObject doorHospitalToFloor = GameObject.Find ("Interactable_Door_Hospital_To_Floor");
		SoundManager.instance.PlayEffect (doorHospitalToFloor.GetComponent<AudioSource> (), "dooropen");
		doorHospitalToFloor.GetComponent<Animator> ().SetTrigger("doorOpen");
	}

	void EnableInteractableContractForSecondInteraction ()
	{
		GameObject.Find ("Interactable_Contract").GetComponent<InteractableObject> ().Enable ();
	}



	#endregion






	#region Level1 Act1

	//---------------------
	//Act 1 Main Dialogues
	//---------------------


	void Start_1_01 ()
	{
		StartCoroutine (Start_1_01_Coroutine ());
	}


	void Start_1_05 (AudioSource audioSource, InteractableObject interactable)
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


	public void Start_1_Interactable_Door_Floor_01 (AudioSource audioSource, InteractableObject interactable)
	{
		SoundManager.instance.PlayEffect (audioSource, "KnockOnDoor");
	}

	public void Start_1_Interactable_Door_Floor_02 (AudioSource audioSource, InteractableObject interactable)
	{
		StartCoroutine (Start_1_Interactable_Door_Floor_02_Coroutine (audioSource));
	}

	void Start_1_Interactable_Wooden_Train_Happy (InteractableObject interactable)
	{
		DialogueManager.instance.StartSubjectMonologue ("1_09");
		countClickedObjectsChildrensRoomHappy ();
	}

	void Start_1_Interactable_Frame_Family (InteractableObject interactable)
	{
		DialogueManager.instance.StartTestManagerAlterEgoMonologue ("1_10");
		countClickedObjectsChildrensRoomHappy ();
	}

	void Start_1_Interactable_Frame_Dog (InteractableObject interactable)
	{
		DialogueManager.instance.StartTestManagerAlterEgoMonologue ("1_11");
		countClickedObjectsChildrensRoomHappy ();
	}

	void Start_1_Interactable_Teddy_Happy (InteractableObject interactable)
	{
		DialogueManager.instance.StartSubjectMonologue ("1_12");
		countClickedObjectsChildrensRoomHappy ();
	}

	void Start_1_Interactable_Light_Switch (AudioSource audioSource, InteractableObject interactable)
	{
		SoundManager.instance.PlayEffect (audioSource, "lightswitch");
		SwitchChildrooms ("Childroom_Sad", "Childroom_Happy");
		DialogueManager.instance.StartDialogueBetweenSubjectAndTestManagerAlterEgo ("1_17");
		SoundManager.instance.PlayBackgroundMusicLoop ("OrWasIt_Level1_1_provisionally", 1, 5);
	}

	void Start_1_Interactable_Beer_Bottles (InteractableObject interactable)
	{
		DialogueManager.instance.StartSubjectMonologue ("1_20");
		countClickedObjectsChildrensRoomSad ();
	}

	void Start_1_Interactable_Cubes_Sad (InteractableObject interactable)
	{
		DialogueManager.instance.StartSubjectMonologue ("1_21");
		countClickedObjectsChildrensRoomSad ();
	}

	void Start_1_Interactable_Frame_Friend (InteractableObject interactable)
	{
		DialogueManager.instance.StartTestManagerAlterEgoMonologue ("1_22");
		countClickedObjectsChildrensRoomSad ();
	}

	void Start_1_Interactable_Teddy_Sad (InteractableObject interactable)
	{
		DialogueManager.instance.StartSubjectMonologue ("1_23");
		countClickedObjectsChildrensRoomSad ();
	}

	void Start_1_Interactable_Wooden_Train_Sad (InteractableObject interactable)
	{
		DialogueManager.instance.StartSubjectMonologue ("1_24");
		countClickedObjectsChildrensRoomSad ();
	}

	void Start_1_Interactable_Neutralizer (InteractableObject interactable)
	{
		StartCoroutine (Start_1_Interactable_Neutralizer_Coroutine ());
	}



	//------------------------------------
	//Act 1 Interactables without Dialogue
	//------------------------------------

	void Start_1_Interactable_Door_Floor_To_Childrens_Room (AudioSource audioSource, InteractableObject interactable)
	{
		SoundManager.instance.PlayEffect (audioSource, "doorlocked");
	}

	void Start_1_Interactable_Door_Childrens_Room_To_Garden (AudioSource audioSource, InteractableObject interactable)
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
		GameObject.Find ("Interactable_Pill_Floor").GetComponent<Rigidbody> ().isKinematic = false;
		//Play DropSound here
	}

	IEnumerator Start_1_Interactable_Door_Floor_02_Coroutine (AudioSource audioSource)
	{
		SoundManager.instance.PlayEffect (audioSource, "ScreamingMan");
		yield return new WaitForSecondsRealtime (3);
		DialogueManager.instance.StartSubjectMonologue ("1_04");
	}

	IEnumerator Start_1_05_Coroutine (AudioSource audioSource)
	{
		DialogueManager.instance.StartSubjectMonologue ("1_05");
		yield return new WaitForSecondsRealtime (9);
		GameObject.FindWithTag ("MainCamera").GetComponent<CameraController> ().TogglePlayerMovement ();
		SoundManager.instance.PlayEffect (audioSource, "eat_pill");
		yield return new WaitForSecondsRealtime (1);
		SoundManager.instance.PlayEffect (GameObject.FindWithTag ("Player").GetComponent<AudioSource> (), "gulp");
		yield return new WaitForSecondsRealtime (1);
		//Start Trip here

		//Hier besser als BackgroundMusic abspielen...
		SoundManager.instance.PlayEffect (GameObject.FindWithTag ("Player").GetComponent<AudioSource> (), "trip");

		//Schwarzblende hier
		StartCoroutine (FadeToBlack (3f));
		yield return new WaitForSecondsRealtime (4f);
		GameObject.FindWithTag ("MainCamera").GetComponent<CameraController> ().ToggleBlur ();
		StartCoroutine (TrippyFOVChanges (10f));
		Image black = GameObject.Find ("Black").GetComponent<Image> ();
		HideImage (black);
		yield return new WaitForSecondsRealtime (10f);
		SoundManager.instance.PlayBackgroundMusicLoop ("DarnParadise_Level1_0", 1, 5);
		//Schwarzblende hier
		StartCoroutine (FadeToBlack (3f));
		yield return new WaitForSeconds (4f);
		HideImage (black);
	
		GameObject.FindWithTag ("MainCamera").GetComponent<CameraController> ().ToggleBlur ();
		GameObject.FindWithTag ("MainCamera").GetComponent<CameraController> ().TogglePlayerMovement ();
		yield return new WaitForSecondsRealtime (1);
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

	IEnumerator Start_1_Interactable_Neutralizer_Coroutine ()
	{
		CloseDoorFloorToChildrensRoom ();
		yield return new WaitForSecondsRealtime (1);
		GameObject.FindWithTag ("MainCamera").GetComponent<CameraController> ().TogglePlayerMovement ();
		SoundManager.instance.PlayEffect (GameObject.FindWithTag ("Player").GetComponent<AudioSource> (), "gulp");
		yield return new WaitForSecondsRealtime (1);
		SoundManager.instance.StopBackgroundMusic (5);
		//Start Trip here

		//Hier besser als BackgroundMusic abspielen...
		SoundManager.instance.PlayEffect (GameObject.FindWithTag ("Player").GetComponent<AudioSource> (), "trip");

		//Schwarzblende hier
		StartCoroutine (FadeToBlack (3f));
		yield return new WaitForSecondsRealtime (4f);
		GameObject.FindWithTag ("MainCamera").GetComponent<CameraController> ().ToggleBlur ();
		StartCoroutine (TrippyFOVChanges (10f));
		Image black = GameObject.Find ("Black").GetComponent<Image> ();
		HideImage (black);
		yield return new WaitForSecondsRealtime (10f);
		//Schwarzblende hier
		StartCoroutine (FadeToBlack (3f));
		SwitchChildrooms ("Childroom_Sober", "Childroom_Sad");
		yield return new WaitForSeconds (4f);
		HideImage (black);
		GameObject.FindWithTag ("MainCamera").GetComponent<CameraController> ().ToggleBlur ();
		GameObject.FindWithTag ("MainCamera").GetComponent<CameraController> ().TogglePlayerMovement ();

		yield return new WaitForSecondsRealtime (1f);

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


	void Start_2_04 (AudioSource audioSource, InteractableObject interactable)
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

	void Start_2_16 (InteractableObject interactable)
	{
		StartCoroutine (Start_2_16_Coroutine ());
	}


	//Pille 3
	void Start_2_19 (AudioSource audioSource, InteractableObject interactable)
	{
		GameObject.Find ("Interactable_DJ_Console").GetComponent<InteractableObject> ().Disable ();
		GameObject.Find ("Interactable_Keypad").GetComponent<InteractableObject> ().Disable ();

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

	void Start_2_23 (InteractableObject interactable)
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
	void Start_2_Interactable_Keypad (InteractableObject interactable)
	{
		DialogueManager.instance.StartSubjectMonologue ("2_03");
	}

	//When the player looks at the group of passed out people on the floor in the parking lot
	void Start_2_Interactable_Dancers_On_Floor (InteractableObject interactable)
	{
		DialogueManager.instance.StartSubjectMonologue ("2_06");
	}

	//When the player looks at the group of dancers in the parking lot
	void Start_2_Dancing_People (InteractableObject interactable)
	{
		DialogueManager.instance.StartSubjectMonologue ("2_07");
	}

	//When the player talks to the DJ
	void Start_2_Interactable_DJ_Console (InteractableObject interactable)
	{
		DialogueManager.instance.StartSubjectMonologue ("2_17");
	}

	//When the player interacts with the Note that contains the Code for the Lock
	void Start_2_Interactable_Note_Code_For_Keypad (InteractableObject interactable)
	{
		StartCoroutine (Start_2_Interactable_Note_Code_For_Keypad_Coroutine ());
	}

	//---------------------------
	//Act 2 Coroutines
	//---------------------------

	IEnumerator Start_2_04_Coroutine (AudioSource audioSource)
	{

		GameObject.FindWithTag ("MainCamera").GetComponent<CameraController> ().TogglePlayerMovement ();

		SoundManager.instance.PlayEffect (audioSource, "eat_pill");
		yield return new WaitForSecondsRealtime (1);
		SoundManager.instance.PlayEffect (GameObject.FindWithTag ("Player").GetComponent<AudioSource> (), "gulp");
		yield return new WaitForSecondsRealtime (1);
		SoundManager.instance.PlayEffect (GameObject.FindWithTag ("Player").GetComponent<AudioSource> (), "trip");
		StartCoroutine (FadeToBlack (3f));
		yield return new WaitForSecondsRealtime (4f);
		Image black = GameObject.Find ("Black").GetComponent<Image> ();
		HideImage (black);
		GameObject.FindWithTag ("MainCamera").GetComponent<CameraController> ().ToggleBlur ();
		StartCoroutine (TrippyFOVChanges (10f));
		yield return new WaitForSecondsRealtime (2f);
		SoundManager.instance.PlayBackgroundMusicLoop ("Synapsis_-_04_-_psy_experiment", 0.4f, 10);
		SwitchHoardings ();
		yield return new WaitForSecondsRealtime (4f);
		SwitchStaticRaveElements ();
		yield return new WaitForSecondsRealtime (4f);
		SwitchDynamicRaveElements ();
		ToggleFriendOnMap ("Interactable_Friend_Fence");

		StartCoroutine (FadeToBlack (3f));
		yield return new WaitForSeconds (4f);
		HideImage (black);

		GameObject.FindWithTag ("MainCamera").GetComponent<CameraController> ().ToggleBlur ();
		GameObject.FindWithTag ("MainCamera").GetComponent<CameraController> ().TogglePlayerMovement ();

		yield return new WaitForSeconds (2f);
		DialogueManager.instance.StartDialogueBetweenSubjectAndTestManager ("2_04");
	}




	IEnumerator Start_2_08_Coroutine ()
	{
		DialogueManager.instance.StartDialogueBetweenSubjectAndFriend ("2_08");
		yield return new WaitForSecondsRealtime (16f);
		TogglePillsInLevel2 ();
	}

	IEnumerator Start_2_11_Coroutine (AudioSource audioSource)
	{
		GameObject.FindWithTag ("MainCamera").GetComponent<CameraController> ().TogglePlayerMovement ();
		SoundManager.instance.PlayEffect (audioSource, "eat_pill");
		yield return new WaitForSecondsRealtime (1);
		SoundManager.instance.PlayEffect (GameObject.FindWithTag ("Player").GetComponent<AudioSource> (), "gulp");
		yield return new WaitForSecondsRealtime (1);
		//Start Trip here
		SoundManager.instance.ReduceBackgroundMusicWhileDrugTrip ();

		//Hier besser als BackgroundMusic abspielen...
		SoundManager.instance.PlayEffect (GameObject.FindWithTag ("Player").GetComponent<AudioSource> (), "trip");

		//Schwarzblende hier
		StartCoroutine (FadeToBlack (3f));
		yield return new WaitForSecondsRealtime (4f);
		DialogueManager.instance.StartTestManagerAlterEgoMonologue ("2_11");
		GameObject.FindWithTag ("MainCamera").GetComponent<CameraController> ().ToggleBlur ();
		StartCoroutine (TrippyFOVChanges (10f));
		Image black = GameObject.Find ("Black").GetComponent<Image> ();
		HideImage (black);
		yield return new WaitForSecondsRealtime (10f);

		StartCoroutine (FadeToBlack (3f));
		yield return new WaitForSeconds (4f);
		GameObject.Find ("Interactable_Friend_Fence").GetComponent<InteractableObject> ().Destroy (0);
		HideImage (black);

		GameObject.FindWithTag ("MainCamera").GetComponent<CameraController> ().ToggleBlur ();
		GameObject.FindWithTag ("MainCamera").GetComponent<CameraController> ().TogglePlayerMovement ();
	}


	IEnumerator Start_2_16_Coroutine ()
	{
		DialogueManager.instance.StartFriendMonologue ("2_16");
		yield return new WaitForSecondsRealtime (13f);
		DialogueManager.instance.StartTestManagerMonologue ("2_18");
	}


	IEnumerator Start_2_19_Coroutine (AudioSource audioSource)
	{
		GameObject.FindWithTag ("MainCamera").GetComponent<CameraController> ().TogglePlayerMovement ();
		SoundManager.instance.PlayEffect (audioSource, "eat_pill");
		yield return new WaitForSecondsRealtime (1);
		SoundManager.instance.PlayEffect (GameObject.FindWithTag ("Player").GetComponent<AudioSource> (), "gulp");
		yield return new WaitForSecondsRealtime (1);
		//Start Trip here

		//Hier besser als BackgroundMusic abspielen...
		SoundManager.instance.PlayEffect (GameObject.FindWithTag ("Player").GetComponent<AudioSource> (), "trip");

		StartCoroutine (FadeToBlack (3f));
		yield return new WaitForSecondsRealtime (4f);
		SoundManager.instance.StopBackgroundMusic (10f);
		GameObject.FindWithTag ("MainCamera").GetComponent<CameraController> ().ToggleBlur ();
		StartCoroutine (TrippyFOVChanges (10f));
		Image black = GameObject.Find ("Black").GetComponent<Image> ();
		HideImage (black);

		yield return new WaitForSecondsRealtime (6f);

		ToggleFriendOnMap ("Interactable_Friend_Dome");
		ToggleFriendOnMap ("Interactable_Friend_Dead");

		SwitchDynamicRaveElements ();
		SwitchAfterRaveElements ();
		EnableTriggerZonesAfterRave ();
		yield return new WaitForSecondsRealtime (4f);
		ToggleEmergencyLight ();

		//Schwarzblende hier
		StartCoroutine (FadeToBlack (3f));
		yield return new WaitForSeconds (4f);
		HideImage (black);

		GameObject.FindWithTag ("MainCamera").GetComponent<CameraController> ().ToggleBlur ();
		GameObject.FindWithTag ("MainCamera").GetComponent<CameraController> ().TogglePlayerMovement ();

		yield return new WaitForSeconds (2f);
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













	//Additional Functions for Trip

	private YieldInstruction fovInstruction = new YieldInstruction ();

	IEnumerator TrippyFOVChanges (float duration)
	{
		float elapsedTime = 0.0f;
		while (elapsedTime < duration) {
			yield return fovInstruction;
			elapsedTime += Time.deltaTime;
			Camera.main.fieldOfView = Mathf.Lerp (Random.Range (40, 80), 5, Time.deltaTime * 5);
		}
		Camera.main.fieldOfView = 75;
	}

	private YieldInstruction fadeInstruction = new YieldInstruction ();

	IEnumerator FadeToBlack (float duration)
	{
		Image black = GameObject.Find ("Black").GetComponent<Image> ();
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


	private void HideImage (Image image)
	{
		Color imageColor = image.color;
		imageColor.a = 0;
		image.color = imageColor;
	}

}
