using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strobe : MonoBehaviour
{

	float interval = 0;
	bool lightState = false;
	public int bpm;
	public int measureFraction;

	private float elapsedMillis;

	public  float INTENSITY_HIGH = 73.79f;
	public float INTENSITY_LOW = 20.0f;


	void Start ()
	{
		interval = (60000 / bpm) / measureFraction;
	}

	void Update ()
	{
		elapsedMillis += Time.deltaTime * 1000;

		if (elapsedMillis > interval) {
			elapsedMillis = elapsedMillis % interval;
			lightState = !lightState;

			if (lightState)
				gameObject.GetComponent<Light> ().intensity = INTENSITY_LOW;
			else
				gameObject.GetComponent<Light> ().intensity = INTENSITY_HIGH;
		}
	}
}
