using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This class is responsible for the Credits of the game
public class Credits : MonoBehaviour {

	void Start () {
		//Loads the Main Menu after the Credits
		Invoke ("LoadMainMenu", 36f);
	}

	//Loads the Main Menu
	private void LoadMainMenu ()
	{
		AsyncOperation loadMainMenuAsync = SceneManager.LoadSceneAsync ("MainMenu");
	}

}
