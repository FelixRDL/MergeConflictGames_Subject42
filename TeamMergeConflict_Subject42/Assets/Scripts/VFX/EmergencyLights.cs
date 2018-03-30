using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//If this Script is active, it controls the rotation of the Emergency Light of the ambulance
public class EmergencyLights : MonoBehaviour
{
	//The speed of the rotating light
	public float rotationSpeed = 300f;

	void Start ()
	{
		StartCoroutine (RotateLightCoroutine ());
	}

	//The loop is in a coroutine for performance reasons.
	IEnumerator RotateLightCoroutine ()
	{
		while (true) {
			transform.Rotate (new Vector3 (0f, Time.deltaTime * rotationSpeed, 0f));	
			yield return null;
		}
	}

}
