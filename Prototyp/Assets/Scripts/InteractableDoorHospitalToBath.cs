using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDoorHospitalToBath : Interactable {

	private EventManager eventManager;
	private Animator animator;

	private void Start() {
		GameObject go = GameObject.Find("EventManager");
		eventManager = (EventManager) go.GetComponent(typeof(EventManager));
		animator = GetComponent<Animator> ();
	}

	public override void OnInteraction ()
	{
		eventManager.Lvl1_Interactable_OpenDoorBath ();
		OpenBathroomDoor ();
	}

	public void OpenBathroomDoor() {
		print ("DoorBath");
		animator.SetTrigger("doorBathOpen");
	}
}
