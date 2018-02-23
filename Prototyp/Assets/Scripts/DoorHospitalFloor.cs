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

	public PillOne pill;

	Animator animator;

	bool doorOpen;
	bool doorAllowedToOpen;

	void Start ()
	{
		doorOpen = false;
		doorAllowedToOpen = false;
		animator = GetComponent<Animator> ();
	}


	public override void OnInteraction ()
	{
		print ("Door from Hospital to Floor! Open: " + doorOpen + "; AllowedToOpen: " + doorAllowedToOpen);

		if (doorAllowedToOpen) {

			doorOpen = true;
			doorAllowedToOpen = false;
			DoorControl ("Open");

			SoundManager.instance.PlayEffect (OpenDoorSound, 0.5f);

			GameObject blocker = GameObject.Find ("Blocker");
			Vector3 temp = new Vector3 (14.1f, 0, 0);
			blocker.transform.position += temp;


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

			Invoke ("allowPlayerToEatPill", 23);
		}
	}

	void allowPlayerToEatPill ()
	{
		pill.allowPlayerToEatPill ();
	}

	public void playerAllowedToOpenDoor ()
	{
		doorAllowedToOpen = true;

	}
}
