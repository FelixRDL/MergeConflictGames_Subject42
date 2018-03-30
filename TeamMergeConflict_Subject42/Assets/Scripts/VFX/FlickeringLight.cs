using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This Class triggers a flickering animation
public class FlickeringLight : MonoBehaviour
{
	public List<GameObject> Children;

	public Material materialOn;
	public Material materialOff;
	public Material materialPlastic;

	//Intervals between flickering (in millis)
	public float[] flickerIntervals = { 0.1f, 0.4f, 0.2f, 0.4f, 0.1f, 1f };
	//Interval, that the light will be off (in millis)
	public float offIntervall = 0.2f;

	//This boolean saves the current state of the lights
	private bool isOn = true;

	//Current pos in the flickerIntervals[] Array
	private int flickerIndex = 0;

	private AudioSource flickerOneShot;
	private float passedTime = 0;


	public void Start ()
	{
		flickerOneShot = gameObject.GetComponent<AudioSource> ();
	}

	public void Update ()
	{
		passedTime += Time.deltaTime;

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

	private void toggleChildren ()
	{
		foreach (Transform child in transform) {
			child.gameObject.SetActive (!child.gameObject.activeSelf);
		}
	}

	private void onSwitchOn ()
	{
		Material[] materials = GetComponent<Renderer> ().materials;
		materials [1] = materialOn;
		GetComponent<Renderer> ().materials = materials;
		toggleChildren ();
		isOn = !isOn;	
		flickerOneShot.Play ();
	}

	private void onSwitchOff ()
	{
		Material[] materials = GetComponent<Renderer> ().materials;
		materials [1] = materialOff;
		GetComponent<Renderer> ().materials = materials;
		toggleChildren ();
		isOn = !isOn;
	}
}
