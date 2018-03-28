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

	private const float DEFAULT_FOV = 75f;

	private AudioSource playerAudioSource;

	private Image blackBackground;

	//Singleton property
	public static EffectManager instance = null;

	void Start () {
		InitSingleton ();

		blur.enabled = false;
		playerAudioSource = GameObject.FindWithTag ("Player").GetComponent<AudioSource> ();
		blackBackground = GameObject.Find ("Black").GetComponent<Image> ();
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

	public void StartFirstPartOfTrip (AudioSource audioSource)
	{
		StartCoroutine (StartFirstPartOfTripCoroutine (audioSource));
	}

	public void StartLastPartOfTrip ()
	{
		StartCoroutine (StartLastPartOfTripCoroutine ());
	}

	public void StartNeutralizerTrip()
	{

	}

	//Functions for Trip

	IEnumerator StartFirstPartOfTripCoroutine (AudioSource audioSource)
	{
		TogglePlayerMovement ();
		SoundManager.instance.PlayEffect (audioSource, "eat_pill");
		yield return new WaitForSecondsRealtime (1f);
		SoundManager.instance.PlayEffect (playerAudioSource, "gulp");
		yield return new WaitForSecondsRealtime (1f);
		SoundManager.instance.PlayEffect (playerAudioSource, "trip");
		StartCoroutine (FadeToBlack (3f));
		yield return new WaitForSecondsRealtime (4f);
		HideImage (blackBackground);
		ToggleBlur ();
		StartCoroutine (TrippyFOVChanges (10f));
		yield return new WaitForSecondsRealtime (2f);
	}

	IEnumerator StartLastPartOfTripCoroutine ()
	{
		StartCoroutine (FadeToBlack (3f));
		yield return new WaitForSeconds (4f);
		HideImage (blackBackground);
		EffectManager.instance.ToggleBlur ();
		EffectManager.instance.TogglePlayerMovement ();
	}

	IEnumerator StartNeutralizerTripCoroutine ()
	{
		EffectManager.instance.TogglePlayerMovement ();
		SoundManager.instance.PlayEffect (GameObject.FindWithTag ("Player").GetComponent<AudioSource> (), "gulp");
		yield return new WaitForSecondsRealtime (1f);

		SoundManager.instance.StopBackgroundMusic (5);
		SoundManager.instance.PlayEffect (GameObject.FindWithTag ("Player").GetComponent<AudioSource> (), "trip");

		//Schwarzblende hier
		StartCoroutine (FadeToBlack (3f));
		yield return new WaitForSecondsRealtime (4f);
		EffectManager.instance.ToggleBlur ();
		StartCoroutine (TrippyFOVChanges (10f));

		HideImage (blackBackground);
		yield return new WaitForSecondsRealtime (10f);
		StartCoroutine (FadeToBlack (3f));

		yield return new WaitForSeconds (4f);
		HideImage (blackBackground);
		EffectManager.instance.ToggleBlur ();
		EffectManager.instance.TogglePlayerMovement ();
	}


	IEnumerator TrippyFOVChanges (float duration)
	{
		float elapsedTime = 0.0f;
		while (elapsedTime < duration) {
			elapsedTime += Time.deltaTime;
			Camera.main.fieldOfView = Mathf.Lerp (Random.Range (60, 90), 5, Time.deltaTime * 5);
			yield return null;
		}
		Camera.main.fieldOfView = DEFAULT_FOV;
	}
		

	IEnumerator FadeToBlack (float duration)
	{
		float elapsedTime = 0.0f;
		Color c = blackBackground.color;
		print ("Start");
		while (elapsedTime < duration) {
			elapsedTime += Time.deltaTime;
			c.a = Mathf.Clamp01 (elapsedTime / duration);
			blackBackground.color = c;
			yield return null;
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
