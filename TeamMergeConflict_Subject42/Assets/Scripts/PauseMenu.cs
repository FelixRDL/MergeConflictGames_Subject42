using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public static bool gamePaused = false;
	public GameObject pauseMenu;

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Escape)) {
			if (gamePaused) {
				Resume ();	
			} else {
				Pause ();
			}
		}
	}

	public void Resume() 
	{
		pauseMenu.SetActive (false);
		Time.timeScale = 1f;
		gamePaused = false;
		AudioListener.pause = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	private void Pause()
	{
		pauseMenu.SetActive (true);
		Time.timeScale = 0f;
		gamePaused = true;
		AudioListener.pause = true;
		Cursor.lockState = CursorLockMode.Confined;
	}

	public void QuitGame ()
	{
		Application.Quit ();
	}
}
