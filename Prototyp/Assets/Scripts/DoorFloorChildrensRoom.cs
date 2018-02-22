using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorFloorChildrensRoom: Interactable
{

	public AudioClip OpenDoorSound;
	public AudioClip CloseDoorSound;
	public AudioClip DoorLockedSound;

	public AudioClip Dialogue_S_1_1;

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
		print ("On Interaction with Door!");

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
			SoundManager.instance.PlayCombinedDialogue (Dialogue_S_1_1, 1f);
		}
	}

	//temp
	public void OpenDoor ()
	{
		doorOpen = true;

		DoorControl ("Open");
	}


	//
	//	void OnTriggerEnter(Collider col)
	//	{
	//		if (col.gameObject.tag == "Player")
	//		{
	//			doorOpen = true;
	//			DoorControl("Open");
	//		}
	//	}
	//

}
