using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDoorHospitalToFloor : Interactable {

	private EventManager eventManager;
	private Animator animator;

	private void Start() {
		GameObject go = GameObject.Find("EventManager");
		eventManager = (EventManager) go.GetComponent(typeof(EventManager));
		animator = GetComponent<Animator> ();
	}


	public override void OnInteraction ()
	{
		OpenDoor ();
	}

	public void OpenDoor() {
		print ("DoorOpen");
		animator.SetTrigger("doorOpen");
	}

	public void CloseDoor() {
		print ("DoorClose");
		animator.SetTrigger("doorClose");
	}
}
