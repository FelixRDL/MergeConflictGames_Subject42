using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;
using UnityStandardAssets.Characters.FirstPerson;

public class EffectManager : MonoBehaviour {

	public RigidbodyFirstPersonController player;

	public BlurOptimized blur;

	private bool playerMovementEnabled = true;

	//Singleton property
	public static EffectManager instance = null;

	void Start () {
		InitSingleton ();
		blur.enabled = false;
	}

	private void InitSingleton ()
	{
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
	}

	public void ToggleBlur() {
		blur.enabled = !blur.enabled;
	}
		
	public void TogglePlayerMovement() {
		if (playerMovementEnabled) {
			player.movementSettings.ForwardSpeed = 0;
			player.movementSettings.BackwardSpeed = 0;
			player.movementSettings.StrafeSpeed = 0;
		} else {
			player.movementSettings.ForwardSpeed = 1.75f;
			player.movementSettings.BackwardSpeed = 1f;
			player.movementSettings.StrafeSpeed = 1.75f;
		}
		playerMovementEnabled = !playerMovementEnabled;
	}


	//Additional Functions for Trip

	private YieldInstruction fovInstruction = new YieldInstruction ();

	IEnumerator TrippyFOVChanges (float duration)
	{
		float elapsedTime = 0.0f;
		while (elapsedTime < duration) {
			yield return fovInstruction;
			elapsedTime += Time.deltaTime;
			Camera.main.fieldOfView = Mathf.Lerp (Random.Range (40, 80), 5, Time.deltaTime * 5);
		}
		Camera.main.fieldOfView = 75;
	}

	private YieldInstruction fadeInstruction = new YieldInstruction ();

	IEnumerator FadeToBlack (float duration)
	{
		Image black = GameObject.Find ("Black").GetComponent<Image> ();
		float elapsedTime = 0.0f;
		Color c = black.color;
		print ("Start");
		while (elapsedTime < duration) {
			yield return fadeInstruction;
			elapsedTime += Time.deltaTime;
			c.a = Mathf.Clamp01 (elapsedTime / duration);
			black.color = c;
		}
		print ("End");

	}


	private void HideImage (Image image)
	{
		Color imageColor = image.color;
		imageColor.a = 0;
		image.color = imageColor;
	}
}
