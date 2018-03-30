using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//A concrete instance of an Object from the class Interactable.
//Inherits from Interactable
public class InteractableObject : Interactable {

	private EventManager eventManager;
	private AudioSource audioSource;
	private Animator animator;

	private void Start() {
		InitEventManager ();
		InitAudioSource ();
		InitAnimator ();

	}

	//Init the EventManager GameOject
	private void InitEventManager ()
	{
		GameObject go = GameObject.Find("EventManager");
		eventManager = (EventManager) go.GetComponent(typeof(EventManager));
	}

	//Checks, if the GameObject has an AudioSource attached to it.
	private void InitAudioSource ()
	{
		if (GetComponent<AudioSource> () != null) {
			audioSource = GetComponent<AudioSource> ();
		} else {
			audioSource = null;
		}
	}

	//Checks, if the GameObject has an Animator attached to it.
	private void InitAnimator () 
	{
		if (GetComponent<Animator> () != null) {
			animator = GetComponent<Animator> ();
		} else {
			animator = null;
		}
	}

	//Overrides the OnInteraction () Function of the Parent Class "Interactable", like this, different manifestations would be possible  
	public override void OnInteraction ()
	{
		//Calls the Function for Interactable Objects in the EventManager and passes the GameObjects name, AudioSource and Animator whith it
		eventManager.OnInteractableClicked (gameObject.name, audioSource, gameObject.GetComponent<InteractableObject>(), animator);
		//If the bool is set to true, the Interaction gets disabled after the first interaction.
		if (disableAfterFirstInteraction) {
			Disable ();
		}
	}

}
