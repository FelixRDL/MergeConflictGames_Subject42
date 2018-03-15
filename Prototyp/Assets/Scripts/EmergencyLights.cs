using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergencyLights : MonoBehaviour {

	void Update () {
		transform.Rotate (new Vector3(0f, Time.deltaTime *400f, 0f));	
	}
}
