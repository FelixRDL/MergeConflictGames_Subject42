using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : Interactable {

	private EventManager eventManager;
	private AudioSource audioSource;

	private void Start() {
		GameObject go = GameObject.Find("EventManager");
		eventManager = (EventManager) go.GetComponent(typeof(EventManager));
		if (GetComponent<AudioSource> () != null) {
			audioSource = GetComponent<AudioSource> ();
		} else {
			audioSource = null;
		}
	}


	public override void OnInteraction ()
	{
		eventManager.OnInteractableClicked (gameObject.name, audioSource, gameObject.GetComponent<InteractableObject>());
	}
}
