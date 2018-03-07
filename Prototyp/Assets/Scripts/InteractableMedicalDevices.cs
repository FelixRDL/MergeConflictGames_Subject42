using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableMedicalDevices : Interactable {

	private EventManager eventManager;

	private void Start() {
		GameObject go = GameObject.Find("EventManager");
		eventManager = (EventManager) go.GetComponent(typeof(EventManager));
	}


	public override void OnInteraction ()
	{
		eventManager.Start_0_Interactable_Medical_Devices ();
		this.enabled = false;
	}
}
