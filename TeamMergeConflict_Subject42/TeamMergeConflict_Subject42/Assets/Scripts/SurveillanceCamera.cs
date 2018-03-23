using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurveillanceCamera : MonoBehaviour
{

	public float RotationSpeed = 1;
	public float volume = 1;
	public AudioClip cameraMovementSound;

	private GameObject player;
	private AudioSource audioSource;

	private Vector3 lastCameraRotation;

	void Start ()
	{
		player = GameObject.FindWithTag ("Player");

		audioSource = GetComponent<AudioSource> ();
		audioSource.clip = cameraMovementSound;
	}

	void Update ()
	{
		RotateCameraTowardsPlayer ();
		PlaySoundIfCameraMoving ();
	}

	private Quaternion CalculateLookRotation()
	{
		//The Vector between the player and the camera
		Vector3 directionToLookAt = (player.transform.position - transform.position).normalized;

		//Rotation
		Quaternion lookRotation = Quaternion.LookRotation (directionToLookAt);

		return lookRotation;

	}

	private void PlaySoundIfCameraMoving ()
	{
		//If Camera is rotating and the sound is not playing yet, play the sound
		if (GetCameraMoving() && !audioSource.isPlaying) {
			audioSource.Play ();
		}
	}

	private void RotateCameraTowardsPlayer() {
		//Rotate camera using the lookRotation and the RotationSpeed
		transform.rotation = Quaternion.Lerp (transform.rotation, CalculateLookRotation(), Time.deltaTime * RotationSpeed);
	}

	private bool GetCameraMoving () {
		Vector3 currentCameraRotation = transform.rotation.eulerAngles;

		if ( (int) currentCameraRotation.x  == (int) lastCameraRotation.x && (int) currentCameraRotation.y  == (int) lastCameraRotation.y && (int) currentCameraRotation.z == (int) lastCameraRotation.z) {
			lastCameraRotation = currentCameraRotation;
			return false;
		} else {
			lastCameraRotation = currentCameraRotation;
			return true;
		}
	}



}
