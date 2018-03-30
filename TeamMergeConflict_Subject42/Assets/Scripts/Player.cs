using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

//This class takes care of sending Raycasts from the player and determining if he is looking at a GameObject he can interact with
public class Player : MonoBehaviour
{

	//The Interactable Object currently in focus
	private Interactable focusedObject = null;


	//This needs to be an Update Loop because we need to check every frame if the player is looking at something he can interact with
	void Update ()
	{
		//Start an Raycast from the center of the screen where the Crosshair is positioned
		Ray ray = Camera.main.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0f));
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, 50)) {

			//Check if the Object in Focus is from type Interactable
			Interactable newFocusedObject = hit.collider.GetComponent<Interactable> ();
			if (newFocusedObject != null) {

				focusedObject = newFocusedObject;
				focusedObject.OnFocused (transform);

				//If player presses E or LeftMouseButton
				if (Input.GetKeyDown (KeyCode.E) || Input.GetMouseButtonDown (0)) {
					focusedObject.OnClicked (transform);
				}

			} else {
				if (focusedObject != null) {
					focusedObject.OnDefocused ();
				}
			}
		}
	}

}
