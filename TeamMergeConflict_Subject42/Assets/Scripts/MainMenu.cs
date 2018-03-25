using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Script for the Main Menu of the Game
public class MainMenu : MonoBehaviour {

	private Image warning;
	private Image logo;
	private Image black;

	private bool gameStarted;

	void Awake() 
	{
		warning = GameObject.Find ("Warning").GetComponent<Image> ();
		logo = GameObject.Find ("Logo").GetComponent<Image> ();
		black = GameObject.Find ("Black").GetComponent<Image> ();

		gameStarted = false;
	}

	//When pressed on the Start Game Button, the SceneManager loads Level 1
	public void StartGame ()
	{
		if (!gameStarted) {
			gameStarted = true;
			StartCoroutine(LoadLevelOne());
		}
	}

	//When pressed on the Quit Game Button, Unity gets closed
	public void QuitGame ()
	{
		Application.Quit ();
	}


	IEnumerator LoadLevelOne ()
	{
		print ("Coroutine");
		StartCoroutine (FadeInImage (warning, 3f));
		yield return new WaitForSecondsRealtime (10f);
		HideImage (warning);

		StartCoroutine (FadeInImage (logo, 3f));

		//AsyncOperation loadLevelOneAsync = SceneManager.LoadSceneAsync("Level1");
		yield return new WaitForSecondsRealtime (5f);
		HideImage (logo);


		/*
		 while (!async.isDone)
        {
            float progress = Mathf.Clamp01(async.progress / 0.9f);
            sliderBar.value = progress;
            loadingText.text = progress * 100f + "%";
            yield return null;

        }
		 */

	}


	IEnumerator FadeInImage (Image image, float duration)
	{
		float elapsedTime = 0.0f;
		Color imageColor = image.color;
		while (elapsedTime < duration) {
			print (elapsedTime);
			elapsedTime += Time.deltaTime;
			imageColor.a = Mathf.Clamp01 (elapsedTime / duration);
			image.color = imageColor;
			yield return null;
		}
	}

	private void HideImage (Image image) {
		Color imageColor = image.color;
		imageColor.a = 0;
		image.color = imageColor;
	}

}
