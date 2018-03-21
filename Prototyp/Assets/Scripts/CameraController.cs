using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;
using UnityStandardAssets.Characters.FirstPerson;

//DELETE THIS CLASS! CONTENT NOW IN EFFECTMANAGER


public class CameraController : MonoBehaviour {

	public BlurOptimized blur;
	public RigidbodyFirstPersonController player;

	private bool playerMovementEnabled = true;

	// Use this for initialization
	void Start () {
		blur.enabled = false;
	}

	public void ToggleBlur() {
		blur.enabled = !blur.enabled;
	}

	public void ZoomIn()
	{
		float fov = Camera.main.fieldOfView;
		Camera.main.fieldOfView = 70;
		//Camera.main.fieldOfView = Mathf.Lerp (30, 5, Time.deltaTime * 5);
	}

	public void ZoomOut()
	{
		float fov = Camera.main.fieldOfView;
		Camera.main.fieldOfView = 75;
		//Camera.main.fieldOfView = Mathf.Lerp (75, 5, Time.deltaTime * 5);
	}


	//TODO: Put this in another Class
	public void TogglePlayerMovement() {
		if (playerMovementEnabled) {
			player.movementSettings.ForwardSpeed = 0;
			player.movementSettings.BackwardSpeed = 0;
			player.movementSettings.StrafeSpeed = 0;
		} else {
			player.movementSettings.ForwardSpeed = 1.75f;
			player.movementSettings.BackwardSpeed = 1f;
			player.movementSettings.StrafeSpeed = 1.75f;
		}
		playerMovementEnabled = !playerMovementEnabled;
	}

}
