using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	Camera camera;

	//Object currently in Focus
	Interactable focus;

	// Use this for initialization
	void Start ()
	{
		camera = Camera.main;
		Cursor.lockState = CursorLockMode.Locked; //Temp
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.E)) {
			
			Ray ray = camera.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0f));
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 50)) {
				print ("I'm looking at " + hit.transform.name);

				Interactable interactable = hit.collider.GetComponent<Interactable> ();
				if (interactable != null) {
					SetFocus (interactable);
				}
			}
		} else {
			RemoveFocus ();
		}
	}

	void SetFocus (Interactable newFocus)
	{
		if (newFocus != focus) {

			if (focus != null) {
				focus.OnDefocused ();
			}
			focus = newFocus;

		}
			
		newFocus.OnFocused (transform);
	}

	void RemoveFocus ()
	{
		if (focus != null) {
			focus.OnDefocused ();
		}
		focus = null;
	}

}
