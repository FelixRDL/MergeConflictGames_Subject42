using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.ImageEffects;
using UnityStandardAssets.Characters.FirstPerson;


//The Effect Manager takes care of all Effects happening to or with the player
//E.g Blur, Drug Trips, FadeToBlack
public class EffectManager : MonoBehaviour
{
	//The Player
	public RigidbodyFirstPersonController player;

	//The Blur Script attached to the MainCamera
	public BlurOptimized blur;

	//The main AudioSource of the Player
	private AudioSource playerAudioSource;

	//A black Canvas Image used for FadeToBlack
	private Image blackBackground;

	//The default Field of View of the game
	private const float DEFAULT_FOV = 75f;

	//The default movement speeds of the player for each level
	private const float PLAYER_FORWARD_SPEED_LEVEL_1 = 1f;
	private const float PLAYER_BACKWARD_SPEED_LEVEL_1 = 0.5f;
	private const float PLAYER_STRAFE_SPEED_LEVEL_1 = 1f;
	private const float PLAYER_FORWARD_SPEED_LEVEL_2 = 1.75f;
	private const float PLAYER_BACKWARD_SPEED_LEVEL_2 = 1f;
	private const float PLAYER_STRAFE_SPEED_LEVEL_2 = 1.75f;

	private bool playerMovementEnabled = true;

	//Singleton property
	public static EffectManager instance = null;

	void Start ()
	{
		InitSingleton ();

		blur.enabled = false;
		playerAudioSource = GameObject.FindWithTag ("Player").GetComponent<AudioSource> ();
		blackBackground = GameObject.Find ("Black").GetComponent<Image> ();
	}

	//Create an Instance of the Singleton
	private void InitSingleton ()
	{
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
	}

	//Enable of disable the Blur Effect
	private void ToggleBlur ()
	{
		blur.enabled = !blur.enabled;
	}

	//Enables or disables the movement of the player
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

	//Disable the players ability to sprint
	public void DisablePlayerRunning ()
	{
		player.movementSettings.RunMultiplier = 1f;
	}

	//Starts the first part of a drug trip
	//A drug trip is split in to parts. Like that, it's easier to time all the events,
	//that are happening during the drug trip
	public void StartFirstPartOfTrip (AudioSource audioSource)
	{
		StartCoroutine (StartFirstPartOfTripCoroutine (audioSource));
	}

	//Starts the last part of a drug trip
	public void StartLastPartOfTrip ()
	{
		StartCoroutine (StartLastPartOfTripCoroutine ());
	}

	//Starts the trip after the player has taken the neutralizer
	public void StartNeutralizerTrip ()
	{
		StartCoroutine (StartNeutralizerTripCoroutine ());
	}

	//There is a special drug trip for pill 2 in Level 2
	public void StartPill02InLevel2 (AudioSource audioSource)
	{
		StartCoroutine (StartPill02InLevel2Coroutine (audioSource));
	}

	//---------------------------------
	//Coroutines for the drug trips
	//---------------------------------

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

	//---------------------------------
	//Functions for Additional Effects
	//---------------------------------

	//This Coroutine randomly changes the FOV for a certain duration.
	//This creates a trippy effect
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

	//This Coroutine Fades the screen to black for a certain duration
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

	//Hides an Image on the canvas, e.g. the black overlay
	private void HideImage (Image image)
	{
		Color imageColor = image.color;
		imageColor.a = 0;
		image.color = imageColor;
	}
}
