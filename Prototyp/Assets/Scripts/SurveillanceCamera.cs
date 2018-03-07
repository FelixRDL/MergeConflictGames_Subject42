﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurveillanceCamera : MonoBehaviour {

	public float RotationSpeed = 1;
	public float volume = 1;

	public AudioClip cameraMovementSound;

	private GameObject player;

	private AudioSource audioSource;

	private Quaternion lastLookRotation;

	void Start () 
	{
		player = GameObject.FindWithTag("Player");

		audioSource = GetComponent<AudioSource>();
		audioSource.clip = cameraMovementSound;
	}

	// TODO: Stop if player not in view
	void Update ()
	{
		//The Vector between the player and the camera
		Vector3 directionToLookAt = (player.transform.position - transform.position).normalized;

		//Rotation
		Quaternion lookRotation = Quaternion.LookRotation (directionToLookAt);
		if (lookRotation != lastLookRotation && !audioSource.isPlaying) {
			audioSource.Play ();
		}
		lastLookRotation = lookRotation;

		//Rotate camera using the lookRotation and the RotationSpeed
		transform.rotation = Quaternion.Slerp (transform.rotation, lookRotation, Time.deltaTime * RotationSpeed);


	}


}
