using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour {

	private bool isEnabled = true;

	//Change color of Crosshair to highlight the object currently in focus
	public void SetHighlight () {
		if (isEnabled) {
			gameObject.GetComponent<Image>().color = Color.red;
		}
	}

	//Revert Crosshair back to default Color
	public void RemoveHighlight () {
		if (isEnabled) {
			gameObject.GetComponent<Image> ().color = Color.white;
		}
	}

	public void HideCrosshair ()
	{
		print("HideCrosshair");
		isEnabled = false;
		Color imageColor = gameObject.GetComponent<Image>().color;
		imageColor.a = 0;
		gameObject.GetComponent<Image>().color = imageColor;
	}

	public void ShowCrosshair ()
	{
		isEnabled = true;
		Color imageColor = gameObject.GetComponent<Image>().color;
		imageColor.a = 1f;
		gameObject.GetComponent<Image>().color = imageColor;
	}

}
