using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Script for the Main Menu of the Game
public class MainMenu : MonoBehaviour
{
	//FadeIn- and DisplayTimes of the Warning and Loading Screen. Can be set directly from the Inspector
	public float warningScreenFadeInTime = 3f;
	public float warningScreenDisplayTime = 10f;
	public float logoScreenFadeInTime = 3f;
	public float logoScreenDisplayTime = 5f;

	//Images to be displayed
	private Image warning;
	private Image logo;
	private Image black;

	//Bool set to true, if Play Button has been pressed. Prevents a second press.
	private bool gameStarted;

	void Awake ()
	{
		InitImages ();
		gameStarted = false;
	}

	private void InitImages()
	{
		warning = GameObject.Find ("Warning").GetComponent<Image> ();
		logo = GameObject.Find ("Logo").GetComponent<Image> ();
		black = GameObject.Find ("Black").GetComponent<Image> ();
		black.gameObject.SetActive (false);
	}

	//When pressed on the Start Game Button, the Game Intro starts in a Coroutine.
	public void StartGame ()
	{
		if (!gameStarted) {
			gameStarted = true;
			StartCoroutine (StartGameIntro ());
		}
	}

	//When pressed on the Quit Game Button, Unity gets closed
	public void QuitGame ()
	{
		Application.Quit ();
	}

	//Coroutine for the Game Intro
	IEnumerator StartGameIntro ()
	{
		//Display a black Screen as overlay over the Menu
		black.gameObject.SetActive (true);

		StartCoroutine (FadeInImage (warning, warningScreenFadeInTime));
		yield return new WaitForSecondsRealtime (warningScreenDisplayTime);
		HideImage (warning);

		StartCoroutine (FadeInImage (logo,logoScreenFadeInTime));
		yield return new WaitForSecondsRealtime (logoScreenDisplayTime);

		StartCoroutine (LoadLevelOne ());

	}

	//Load Level 1 asynchonous
	IEnumerator LoadLevelOne ()
	{
		AsyncOperation loadLevelOneAsync = SceneManager.LoadSceneAsync ("Level1");
		while (!loadLevelOneAsync.isDone) {
			print ("Progress:" + Mathf.Clamp01 (loadLevelOneAsync.progress / 0.9f) * 100f + "%");
			yield return null;
		}
	}

	IEnumerator FadeInImage (Image image, float duration)
	{
		float elapsedTime = 0.0f;
		Color imageColor = image.color;
		while (elapsedTime < duration) {
			elapsedTime += Time.deltaTime;
			imageColor.a = Mathf.Clamp01 (elapsedTime / duration);
			image.color = imageColor;
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
