using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;
using UnityStandardAssets.Characters.FirstPerson;

public class EffectManager : MonoBehaviour {

	public BlurOptimized blur;
	public RigidbodyFirstPersonController player;

	private bool playerMovementEnabled = true;

	float minFov = 15f;
	float maxFov = 90f;
	float sensitivity = 20f;

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
		Camera.main.fieldOfView = 30;

		//Zoom test:
		/*
		float fov = camera.fieldOfView;
		fov -= Input.GetAxis("Mouse ScrollWheel") * sensitivity;
		fov = Mathf.Clamp(fov, minFov, maxFov);
		Camera.main.fieldOfView = fov;
		*/
	}

	public void CameraZoom () {

		//Zoom 5 Units per frame
		Camera.mainCamera.fieldOfView = Mathf.Lerp (Camera.mainCamera.fieldOfView, 5, Time.deltaTime * 5);
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
