using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurveillanceCamera : MonoBehaviour {

	private float RotationSpeed = 1;

	private GameObject Player;

	void Start () 
	{
		Player = GameObject.FindWithTag("Player");
	}

	// TODO: Stop if player not in view
	void Update ()
	{
		//The Vector between the player and the camera
		Vector3 directionToLookAt = (Player.transform.position - transform.position).normalized;

		//Rotation
		Quaternion lookRotation = Quaternion.LookRotation (directionToLookAt);

		//Rotate camera using the lookRotation and the RotationSpeed
		transform.rotation = Quaternion.Slerp (transform.rotation, lookRotation, Time.deltaTime * RotationSpeed);
	}
}
