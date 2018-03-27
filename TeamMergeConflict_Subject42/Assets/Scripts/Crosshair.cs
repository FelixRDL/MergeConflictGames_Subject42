using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour {

	//Change color of Crosshair to highlight the object currently in focus
	public void SetHighlight () {
		gameObject.GetComponent<Image>().color = Color.red;
	}

	//Revert Crosshair back to default Color
	public void RemoveHighlight () {
		gameObject.GetComponent<Image>().color = Color.white;
	}

}
