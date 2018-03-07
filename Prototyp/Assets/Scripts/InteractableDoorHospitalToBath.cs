using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDoorHospitalToBath : Interactable {

	private EventManager eventManager;
	private Animator animator;

	private AudioSource audioSource;


	private void Start() {
		GameObject go = GameObject.Find("EventManager");
		eventManager = (EventManager) go.GetComponent(typeof(EventManager));
		animator = GetComponent<Animator> ();
		audioSource = GetComponent<AudioSource>();
	}

	public override void OnInteraction ()
	{
		eventManager.Start_0_Interactable_Door_Bath (audioSource);
	}

	public void OpenBathroomDoor() {
		print ("DoorBath");
		animator.SetTrigger("doorBathOpen");
	}
}
