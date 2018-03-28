using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractableObject : Interactable {

	private EventManager eventManager;
	private AudioSource audioSource;

	private Animator animator;

	private void Start() {
		GameObject go = GameObject.Find("EventManager");
		eventManager = (EventManager) go.GetComponent(typeof(EventManager));

		if (GetComponent<AudioSource> () != null) {
			audioSource = GetComponent<AudioSource> ();
		} else {
			audioSource = null;
		}

		if (GetComponent<Animator> () != null) {
			animator = GetComponent<Animator> ();
		} else {
			animator = null;
		}
	}


	public override void OnInteraction ()
	{
		eventManager.OnInteractableClicked (gameObject.name, audioSource, gameObject.GetComponent<InteractableObject>(), animator);
		if (disableAfterFirstInteraction) {
			Disable ();
		}
	}

}
