using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strobe : MonoBehaviour {

	float interval = 0;
	bool lightState = false;
	public int bpm;
	public int measureFraction;

	private float elapsedMillis;

	public  float INTENSITY_HIGH = 73.79f;
	public float INTENSITY_LOW = 20.0f;



	// Use this for initialization
	void Start () {
		interval = (60000/bpm)/measureFraction;
		Debug.Log(interval);

	}

	// Update is called once per frame
	void Update () {
			Debug.Log(elapsedMillis);
			elapsedMillis += Time.deltaTime * 1000;

			if(elapsedMillis > interval){
				Debug.Log(elapsedMillis%interval);
				elapsedMillis = elapsedMillis%interval;
				lightState = !lightState;

				if(lightState) gameObject.GetComponent<Light>().intensity = INTENSITY_LOW;
				else gameObject.GetComponent<Light>().intensity = INTENSITY_HIGH;
				Debug.Log(lightState);
			}
	}
}
