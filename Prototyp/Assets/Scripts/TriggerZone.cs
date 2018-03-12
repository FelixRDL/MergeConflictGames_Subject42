using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour {

	private EventManager eventManager;


	private void Start() {
		GameObject go = GameObject.Find("EventManager");
		eventManager = (EventManager) go.GetComponent(typeof(EventManager));
	}

	void OnTriggerEnter ()
	{
		eventManager.OnTriggerZoneEntered (gameObject.name);
		Destroy (gameObject);
	}
}
