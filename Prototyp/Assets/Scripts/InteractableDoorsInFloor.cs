using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDoorsInFloor : Interactable {

	private EventManager eventManager;
	private AudioSource audioSource;

	private void Start() {
		GameObject go = GameObject.Find("EventManager");
		eventManager = (EventManager) go.GetComponent(typeof(EventManager));
			audioSource = GetComponent<AudioSource> ();
	}


	public override void OnInteraction ()
	{
		eventManager.Start_1_Interactable_Doors_In_Floor (audioSource, gameObject.GetComponent<InteractableDoorsInFloor>());
	}
}
