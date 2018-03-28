using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{

	private EventManager eventManager;

	private void Start ()
	{
		GameObject go = GameObject.Find ("EventManager");
		eventManager = (EventManager)go.GetComponent (typeof(EventManager));
	}

	//When the Player enters the TriggerZone, the name of the TriggerZone gets passed to the EventManager and the TriggerZone gets removed
	void OnTriggerEnter ()
	{
		eventManager.OnTriggerZoneEntered (gameObject.name);
		Destroy (gameObject);
	}
}
