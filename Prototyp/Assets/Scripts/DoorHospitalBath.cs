using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHospitalBath : Interactable
{

	public AudioClip OpenDoorSound;
	public AudioClip CloseDoorSound;


	Animator animator;
	bool doorOpen;

	void Start ()
	{
		doorOpen = false;
		animator = GetComponent<Animator> ();
	}


	public override void OnInteraction ()
	{
		print ("On Interaction with the Door from Hospital to Floor!");

		if (!doorOpen) {
			doorOpen = true;
			DoorControl ("Open");

			SoundManager.instance.PlayEffect (OpenDoorSound, 0.5f);
		} else {

		}
	}


	void DoorControl (string direction)
	{
		animator.SetTrigger (direction);
	}

}
