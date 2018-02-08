using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTwo: Interactable
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
		print ("in door One start()");
		doorOpen = false;
		doorAllowedToOpen = true;
		animator = GetComponent<Animator> ();
	}


	public override void OnInteraction ()
	{
		print ("On Interaction with Door One!");

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
