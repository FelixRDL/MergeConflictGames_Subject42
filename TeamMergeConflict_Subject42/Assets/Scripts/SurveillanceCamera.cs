using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class controls the movement of a surveillance camera
public class SurveillanceCamera : MonoBehaviour
{
	//The speed of the camera rotation
	public float rotationSpeed = 1;

	//The sound of the rotation movement
	public AudioClip cameraMovementSound;

	private GameObject player;
	private AudioSource audioSource;

	//The last Rotation of the Camera gets saved here to allow for comparisons
	private Vector3 lastCameraRotation;

	void Start ()
	{
		player = GameObject.FindWithTag ("Player");
		InitAudioSource ();
	}

	//Init the AudioSource of the Surveillance Camera
	private void InitAudioSource ()
	{
		audioSource = GetComponent<AudioSource> ();
		audioSource.clip = cameraMovementSound;
	}

	void Update ()
	{
		RotateCameraTowardsPlayer ();
		PlaySoundIfCameraMoving ();
	}

	//Calculates a Vector between the Player and the Surveillance camera and from that a rotation
	//for the Surveillance camera that needs to be performed in order to look at the player
	private Quaternion CalculateLookRotation ()
	{
		//The Vector between the player and the camera
		Vector3 directionToLookAt = (player.transform.position - transform.position).normalized;

		//Rotation
		Quaternion lookRotation = Quaternion.LookRotation (directionToLookAt);

		return lookRotation;

	}


	//If Camera is rotating and the rotation sound is not playing yet, it plays the sound
	private void PlaySoundIfCameraMoving ()
	{
		if (GetCameraMoving () && !audioSource.isPlaying) {
			audioSource.Play ();
		}
	}


	//Rotate camera towards the player
	private void RotateCameraTowardsPlayer ()
	{
		transform.rotation = Quaternion.Lerp (transform.rotation, CalculateLookRotation (), Time.deltaTime * rotationSpeed);
	}

	//Calculates if the camera is currently moving using the last Rotation and the current Rotation of the surveillance camera
	private bool GetCameraMoving ()
	{
		Vector3 currentCameraRotation = transform.rotation.eulerAngles;

		if ((int)currentCameraRotation.x == (int)lastCameraRotation.x && (int)currentCameraRotation.y == (int)lastCameraRotation.y && (int)currentCameraRotation.z == (int)lastCameraRotation.z) {
			lastCameraRotation = currentCameraRotation;
			return false;
		} else {
			lastCameraRotation = currentCameraRotation;
			return true;
		}
	}



}
