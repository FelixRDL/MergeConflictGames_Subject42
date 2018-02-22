using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHospitalFloor : Interactable
{

	public AudioClip OpenDoorSound;
	public AudioClip CloseDoorSound;
	public AudioClip DoorLockedSound;
	public AudioClip DontGoBackWarning;

	public AudioClip Dialogue_S_1_0;

	Animator animator;
	bool doorOpen;
	bool doorAllowedToOpen;

	void Start ()
	{
		print ("In Start()");
		doorOpen = false;
		doorAllowedToOpen = true;
		animator = GetComponent<Animator> ();
	}


	public override void OnInteraction ()
	{
		print ("On Interaction with the Door from Hospital to Floor!");

		if (doorAllowedToOpen) {

			doorOpen = true;
			doorAllowedToOpen = false;
			DoorControl ("Open");

			SoundManager.instance.PlayEffect (OpenDoorSound, 0.5f);
		} else {
			print ("Not allowed to open door!");
			if (!doorOpen) {
				SoundManager.instance.PlayEffect (DoorLockedSound);
			}
			if (!SoundManager.instance.GetDialoguePlaying ()) {
				SoundManager.instance.PlayTestManagerDialogue (DontGoBackWarning, 0.5f);
			}
		}
	}


	void DoorControl (string direction)
	{
		animator.SetTrigger (direction);
	}


	void OnTriggerExit (Collider col)
	{

		if (doorOpen) {

			doorOpen = false;
			DoorControl ("Close");

			SoundManager.instance.PlayEffect (CloseDoorSound, 0.5f);
			SoundManager.instance.PlayCombinedDialogue (Dialogue_S_1_0, 1f);
		}
	}

	//temp
	public void OpenDoor ()
	{
		DoorControl ("Open");
	}

}
