using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour {

	public static DoorManager instance = null;

	Animator animator;

	void Awake ()
	{
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}

		DontDestroyOnLoad (gameObject);

		animator = GetComponent<Animator> ();
	}


	public void OpenDoor (int id) {
		
	}
}
