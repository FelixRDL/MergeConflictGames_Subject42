using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{

	private int clickedObjectsInHospitalRoom;
	private int clickedObjectsInChildrensRoom;
	private bool floorEntered;

	//---------------------
	//EventManager Init
	//---------------------

	void Start ()
	{

		InitFlags ();
		InitInteractables ();

		Start_0_01 ();

	}

	void InitFlags ()
	{
		clickedObjectsInHospitalRoom = 0;
		clickedObjectsInChildrensRoom = 0;
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
	void TEST_OPEN_DOORS ()
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

	//---------------------
	//Act 0 Interactables with Dialogue
	//---------------------

	void Start_0_Interactable_Window (InteractableObject interactable)
	{
		DialogueManager.instance.StartSubjectMonologue ("0_02", 1, 0);
		//countClickedObjectsLevel0 ();
		interactable.Disable ();
	}

	void Start_0_Interactable_Medical_Devices (InteractableObject interactable)
	{
		DialogueManager.instance.StartSubjectMonologue ("0_03", 1, 0);
		//countClickedObjectsLevel0 ();
		interactable.Disable ();
	}

	void Start_0_Interactable_Picture_Frame (InteractableObject interactable)
	{
		DialogueManager.instance.StartSubjectMonologue ("0_04", 1, 0);
		countClickedObjectsLevel0 ();
		interactable.Disable ();
	}

	void Start_0_Interactable_Bath_Mirror (InteractableObject interactable)
	{
		DialogueManager.instance.StartSubjectMonologue ("0_05", 1, 0);
		//countClickedObjectsLevel0 ();
		interactable.Disable ();
	}

	void Start_0_Interactable_Contracts (InteractableObject interactable)
	{
		DialogueManager.instance.StartSubjectMonologue ("0_06", 1, 0);
		countClickedObjectsLevel0 ();
		interactable.Disable ();

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
		if (clickedObjectsInHospitalRoom > 2) {
			Invoke ("Start_0_08", 8);
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

		SwitchChildrooms ("Childroom_Sad","Childroom_Happy");

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

	void Start_1_Interactable_Neutralizer () {
		SwitchChildrooms ("Childroom_Sober", "Childroom_Sad");
	}

	//------------------------------------
	//Act 1 Interactables without Dialogue
	//------------------------------------

	void Start_1_Interactable_Door_Childrens_Room_To_Garden (AudioSource audioSource, InteractableObject interactable)
	{
		SoundManager.instance.PlayEffect (audioSource, "dooropen", 1, 0);
		SceneManager.LoadScene ("Level2");
	}


	void SwitchChildrooms(string roomToActivate, string RoomToDeactivate)  {
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


}
