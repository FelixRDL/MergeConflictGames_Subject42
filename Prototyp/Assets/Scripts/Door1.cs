using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1 : Interactable
{

	public AudioClip OpenDoorSound;
	public AudioClip CloseDoorSound;
	public AudioClip Dialogue_S_1_1;

	Animator animator;
	bool doorOpen;
	bool doorAllowedToOpen;

	void Start ()
	{
		doorOpen = false;
		doorAllowedToOpen = true;
		animator = GetComponent<Animator> ();
	}


	public override void OnInteraction ()
	{
		print ("On Interaction with Door 1!");

		if (doorAllowedToOpen) {

			doorOpen = true;
			doorAllowedToOpen = false;
			DoorControl ("Open");

			SoundManager.instance.PlayEffect (OpenDoorSound, 0.5f);
		} else {
			print ("Not allowed to open door!");
		}

	}

	void DoorControl (string direction)
	{
		animator.SetTrigger (direction);
	}

	//temp
	public void OpenDoor () {
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

	void OnTriggerExit (Collider col)
	{
		
		if (doorOpen) {
			
			doorOpen = false;
			DoorControl ("Close");
			
			SoundManager.instance.PlayEffect (CloseDoorSound, 0.5f);
			SoundManager.instance.PlayCombinedDialogue (Dialogue_S_1_1, 1f);
		}
	}

}
