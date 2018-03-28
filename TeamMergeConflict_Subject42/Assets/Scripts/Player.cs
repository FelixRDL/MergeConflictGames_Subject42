using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Player : MonoBehaviour
{

	private Camera mainCamera;
	private Interactable focusedObject;

	void Start ()
	{
		mainCamera = Camera.main;
		focusedObject = null;
	}

	//This needs to be an Update Loop because we need to check every frame if the player is looking at something he can interact with
	void Update ()
	{
		//Start an Raycast from the center of the screen where the Crosshair is positioned
		Ray ray = mainCamera.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0f));
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, 50)) {

			//Check if the Object in Focus is from Type Interactable
			Interactable newFocusedObject = hit.collider.GetComponent<Interactable> ();
			if (newFocusedObject != null) {

				focusedObject = newFocusedObject;
				focusedObject.OnFocused (transform);

				//If player presses E or LeftMouseButton
				if (Input.GetKeyDown (KeyCode.E) || Input.GetMouseButtonDown(0)) {
					focusedObject.OnClicked (transform);
				}

			} else {
				if (focusedObject != null) {
					focusedObject.OnDefocused ();
				}
			}
		}
	}

	//Player will not be able to Walk, but looking around still works.
	public void DisablePlayerControls () {
		GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().enabled = false;
	}


	//Player will be able to walk around again.
	public void EnablePlayerControls () {
		GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().enabled = true;
	}
}
