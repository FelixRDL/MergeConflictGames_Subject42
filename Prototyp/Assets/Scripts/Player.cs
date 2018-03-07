using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Player : MonoBehaviour
{

	Camera camera;

	Interactable focusedObject;


	float minFov = 15f;
	float maxFov = 90f;
	float sensitivity = 20f;


	void Start ()
	{
		camera = Camera.main;
		//Lock Cursor in Window
		//Cursor.lockState = CursorLockMode.Locked; 

		focusedObject = null;
	}


	void Update ()
	{
		Ray ray = camera.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0f));
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, 50)) {

			Interactable newFocusedObject = hit.collider.GetComponent<Interactable> ();
			if (newFocusedObject != null) {

				focusedObject = newFocusedObject;
				focusedObject.OnFocused (transform);

				if (Input.GetKeyDown (KeyCode.E)) {
					focusedObject.OnClicked (transform);
				}

			} else {
				if (focusedObject != null) {
					focusedObject.OnDefocused ();
				}
			}
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}
			
		//Zoom test:
		float fov = camera.fieldOfView;
		fov -= Input.GetAxis("Mouse ScrollWheel") * sensitivity;
		fov = Mathf.Clamp(fov, minFov, maxFov);
		Camera.main.fieldOfView = fov;

	}

	//Player will not be able to move at all. For Cutscenes.
	public void disablePlayerControls () {
		GameObject.FindGameObjectWithTag("Player").GetComponent<RigidbodyFirstPersonController>().enabled = false;
	}

	public void enablePlayerControls () {
		GameObject.FindGameObjectWithTag("Player").GetComponent<RigidbodyFirstPersonController>().enabled = true;
	}
}
