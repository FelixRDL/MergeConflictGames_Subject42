using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script triggers a flickering animation by enabling and disabling children Elements with an activated and deactivated lamp.

public class FlickeringLight : MonoBehaviour {
	public List<GameObject> Children;
	// whether the light currently is switched on or off
	// 
	private bool isOn = true;

	public Material materialOn;
	public Material materialOff;
	public Material materialPlastic;

	private AudioSource flickerOneShot;

	private MeshRenderer meshRenderer;


	// intervals between flickering (in millis)
	public float[] flickerIntervals = {.1f, .4f, .2f, .4f, .1f, 1};
	private int flickerIndex = 0;
	// interval, that the light will be off (in millis)
	public float offIntervall = .2f;

	private float passedTime = 0;

	public void Start(){
		meshRenderer = gameObject.GetComponent <MeshRenderer>();
		flickerOneShot = gameObject.GetComponent<AudioSource> ();
	}

	public void Update(){
		passedTime += Time.deltaTime;
		//print ("passed time " + passedTime);

		if (isOn == true) {
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
		// TODO trigger sound
		Material[] materials= GetComponent<Renderer>().materials;
		materials [1] = materialOn;
		GetComponent<Renderer> ().materials = materials;
		toggleChildren ();
		isOn = !isOn;	
		flickerOneShot.Play ();
	}

	private void onSwitchOff(){
		Material[] materials= GetComponent<Renderer>().materials;
		materials [1] = materialOff;
		GetComponent<Renderer> ().materials = materials;
		toggleChildren ();
		isOn = !isOn;
	}
}
