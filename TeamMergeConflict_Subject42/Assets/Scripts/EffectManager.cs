using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.ImageEffects;
using UnityStandardAssets.Characters.FirstPerson;

public class EffectManager : MonoBehaviour
{

	public RigidbodyFirstPersonController player;

	public BlurOptimized blur;

	private bool playerMovementEnabled = true;

	private const float DEFAULT_FOV = 75f;

	private AudioSource playerAudioSource;

	private Image blackBackground;

	private const float PLAYER_FORWARD_SPEED_LEVEL_1 = 1f;
	private const float PLAYER_BACKWARD_SPEED_LEVEL_1 = 0.5f;
	private const float PLAYER_STRAFE_SPEED_LEVEL_1 = 1f;

	private const float PLAYER_FORWARD_SPEED_LEVEL_2 = 1.75f;
	private const float PLAYER_BACKWARD_SPEED_LEVEL_2 = 1f;
	private const float PLAYER_STRAFE_SPEED_LEVEL_2 = 1.75f;

	//Singleton property
	public static EffectManager instance = null;

	void Start ()
	{
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

	public void ToggleBlur ()
	{
		blur.enabled = !blur.enabled;
	}

	public void TogglePlayerMovement ()
	{
		if (playerMovementEnabled) {
			player.movementSettings.ForwardSpeed = 0;
			player.movementSettings.BackwardSpeed = 0;
			player.movementSettings.StrafeSpeed = 0;
		} else {
			
			if (SceneManager.GetActiveScene ().name == "Level1") {
				
				player.movementSettings.ForwardSpeed = PLAYER_FORWARD_SPEED_LEVEL_1;
				player.movementSettings.BackwardSpeed = PLAYER_BACKWARD_SPEED_LEVEL_1;
				player.movementSettings.StrafeSpeed = PLAYER_STRAFE_SPEED_LEVEL_1;

			} else {
				player.movementSettings.ForwardSpeed = PLAYER_FORWARD_SPEED_LEVEL_2;
				player.movementSettings.BackwardSpeed = PLAYER_BACKWARD_SPEED_LEVEL_2;
				player.movementSettings.StrafeSpeed = PLAYER_STRAFE_SPEED_LEVEL_2;
			}
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

	public void StartNeutralizerTrip ()
	{
		StartCoroutine (StartNeutralizerTripCoroutine ());
	}

	public void StartPill02InLevel2 (AudioSource audioSource) 
	{
		StartCoroutine (StartPill02InLevel2Coroutine (audioSource));
	}

	//Functions for Trip

	IEnumerator StartFirstPartOfTripCoroutine (AudioSource audioSource)
	{
		TogglePlayerMovement ();
		GameObject.Find ("Crosshair").GetComponent<Crosshair> ().HideCrosshair ();
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
		GameObject.Find ("Crosshair").GetComponent<Crosshair> ().ShowCrosshair ();
	}

	IEnumerator StartPill02InLevel2Coroutine (AudioSource audioSource)
	{
		TogglePlayerMovement ();
		GameObject.Find ("Crosshair").GetComponent<Crosshair> ().HideCrosshair ();
		SoundManager.instance.PlayEffect (audioSource, "eat_pill");
		yield return new WaitForSecondsRealtime (1f);
		SoundManager.instance.PlayEffect (playerAudioSource, "gulp");
		yield return new WaitForSecondsRealtime (1f);
		SoundManager.instance.PlayEffect (playerAudioSource, "trip");

		//Schwarzblende hier
		StartCoroutine (FadeToBlack (3f));
		yield return new WaitForSecondsRealtime (16f);
		HideImage (blackBackground);
		TogglePlayerMovement ();
		GameObject.Find ("Crosshair").GetComponent<Crosshair> ().ShowCrosshair ();
	}

	IEnumerator StartNeutralizerTripCoroutine ()
	{
		EffectManager.instance.TogglePlayerMovement ();
		GameObject.Find ("Crosshair").GetComponent<Crosshair> ().HideCrosshair ();
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
		GameObject.Find ("Crosshair").GetComponent<Crosshair> ().ShowCrosshair ();
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
		while (elapsedTime < duration) {
			elapsedTime += Time.deltaTime;
			c.a = Mathf.Clamp01 (elapsedTime / duration);
			blackBackground.color = c;
			yield return null;
		}
	}


	private void HideImage (Image image)
	{
		Color imageColor = image.color;
		imageColor.a = 0;
		image.color = imageColor;
	}
}
