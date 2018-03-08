using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePen : Interactable {

	private EventManager eventManager;

	private AudioSource audioSource;


	private void Start() {
		GameObject go = GameObject.Find("EventManager");
		eventManager = (EventManager) go.GetComponent(typeof(EventManager));

		audioSource = GetComponent<AudioSource>();
	}


	public override void OnInteraction ()
	{
		eventManager.Start_0_Interactable_Pen (audioSource);
	}
}
