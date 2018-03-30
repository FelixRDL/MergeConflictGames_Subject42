using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The Pause Many that can be accessed by pressing ESC during the game
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

	//Contiunes a paused game
	public void Resume() 
	{
		pauseMenu.SetActive (false);
		Time.timeScale = 1f;
		gamePaused = false;
		AudioListener.pause = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	//Pauses the currently running game
	private void Pause()
	{
		pauseMenu.SetActive (true);
		//Freeze time
		Time.timeScale = 0f;
		gamePaused = true;
		//Pause all Sounds curently playing
		AudioListener.pause = true;
		//Allowes the MouseCursor to be moved on the Menu
		Cursor.lockState = CursorLockMode.Confined;
	}

	//If the Quit Button is pressed, the game gets closed
	public void QuitGame ()
	{
		Application.Quit ();
	}

}
