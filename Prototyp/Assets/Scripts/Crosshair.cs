using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {

	//The highlighted crosshair
	public GameObject crosshairFocus;

	public void SetHighlight () {
		crosshairFocus.SetActive (true);
	}

	public void RemoveHighlight () {
		crosshairFocus.SetActive (false);
	}
		

}
