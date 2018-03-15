using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDoorFloorToChildrensRoom : Interactable {

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
		eventManager.Start_1_Interactable_Door_Floor_To_Childrens_Room (audioSource, gameObject.GetComponent<InteractableDoorFloorToChildrensRoom> ());
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
