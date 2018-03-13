using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManagerLevel2 : MonoBehaviour {


	private bool playerHasPasscode;

	//---------------------
	//EventManager Init
	//---------------------

	void Start ()
	{
		InitFlags ();
		InitInteractables ();

		Start_2_01 ();
	}

	void InitFlags ()
	{
		playerHasPasscode = false;
	}

	void InitInteractables ()
	{
		
	}
		
	//---------------------
	// Main Game Functions
	//---------------------

	public void OnTriggerZoneEntered (string nameOfTriggerZone)
	{
		switch (nameOfTriggerZone) {
		case "A":
			break;
		default:
			break;
		}
	}

	public void OnInteractableClicked (string nameOfInteractable, AudioSource audioSource, InteractableObject interactable)
	{
		switch (nameOfInteractable) {
		case "Interactable_Keypad":
			Start_2_Interactable_Keypad ();
			break;
		case "Interactable_DJ_Console":
			Start_2_Interactable_DJ_Console ();
			break;
		default:
			break;
		}
	}



	//---------------------
	//Act 2 Main Dialogues
	//---------------------

	void Start_2_01 () {
		DialogueManager.instance.StartTestManagerMonologue ("2_01", 1, 0);
		SoundManager.instance.PlayBackgroundMusicLoop ("Synapsis_-_04_-_psy_experiment", 0, 0);
	}

	void Start_2_04 () {
		DialogueManager.instance.StartDialogueBetweenSubjectAndTestManager ("2_04", 1, 1, 0);
	}

	void Start_2_08 () {
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





	void Start_2_31 () {
		DialogueManager.instance.StartDialogueBetweenSubjectAndTestManager ("2_31", 1, 1, 0);
	}

	//----------------------------------
	//Act 2 Interactables with Dialogue
	//----------------------------------

	void Start_2_Interactable_Keypad () {
		if (!playerHasPasscode) {
			DialogueManager.instance.StartSubjectMonologue ("2_03", 1, 0);
		} else {
			Start_2_31 ();
		}
	}

	void Start_2_Interactable_Lying_Junkies () {
		DialogueManager.instance.StartSubjectMonologue ("2_06", 1, 0);
	}

	void Start_2_Dancing_People () {
		DialogueManager.instance.StartSubjectMonologue ("2_07", 1, 0);
	}

	void Start_2_Interactable_DJ_Console () {
		DialogueManager.instance.StartSubjectMonologue ("2_17", 1, 0);
	}

	void Start_2_Interactable_Note_Passcode () {
		DialogueManager.instance.StartSubjectMonologue ("2_30", 1, 0);
	}



	//------------------------------------
	//Act 2 Interactables without Dialogue
	//------------------------------------




}

