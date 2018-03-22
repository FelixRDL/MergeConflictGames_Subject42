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


	void Update ()
	{
		Ray ray = mainCamera.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0f));
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, 50)) {

			Interactable newFocusedObject = hit.collider.GetComponent<Interactable> ();
			if (newFocusedObject != null) {

				focusedObject = newFocusedObject;
				focusedObject.OnFocused (transform);

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

	//Player will not be able to move at all. For Cutscenes.
	public void DisablePlayerControls () {
		GameObject.FindGameObjectWithTag("Player").GetComponent<RigidbodyFirstPersonController>().enabled = false;
	}

	public void EnablePlayerControls () {
		GameObject.FindGameObjectWithTag("Player").GetComponent<RigidbodyFirstPersonController>().enabled = true;
	}
}
