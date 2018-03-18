using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script triggers a flickering animation by enabling and disabling children Elements with an activated and deactivated lamp.

public class FlickeringLight : MonoBehaviour {
	public List<GameObject> Children;
	// whether the light currently is switched on or off
	// 
	private bool isOn = false;

	// intervals between flickering (in millis)
	public int[] flickerIntervals = {100, 400, 200, 400, 100, 1000};
	private int flickerIndex = 0;
	// interval, that the light will be off (in millis)
	public int offIntervall = 200;

	private float passedTime = Time.deltaTime;


	public void Update(){
		passedTime += Time.deltaTime;
		if (isOn) {
			if (passedTime >= flickerIntervals [flickerIndex]) {
				// reset passedTime
				passedTime = passedTime % flickerIntervals [flickerIndex];
				onSwitchOff ();

				flickerIndex = (flickerIndex + 1) % flickerIntervals.Length;
			}	
		} else {
			if (passedTime >= offIntervall) {
				passedTime = passedTime % offIntervall;
				onSwitchOn ();
			}
		}
	}

	private void toggleChildren(){
		foreach (Transform child in transform)
		{
			// toggle state 
			child.gameObject.active = !child.gameObject.active;
		}
	}
	
	



	private void onSwitchOn(){
		toggleChildren ();
		isOn = !isOn;		
	}

	private void onSwitchOff(){
		toggleChildren ();
		isOn = !isOn;
	}
}
