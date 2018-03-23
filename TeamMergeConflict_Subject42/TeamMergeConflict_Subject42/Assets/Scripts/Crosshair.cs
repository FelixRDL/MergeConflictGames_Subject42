using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Change appearance of Crosshair
public class Crosshair : MonoBehaviour {

	//Crosshair changes Color
	public void SetHighlight () {
		gameObject.GetComponent<Image>().color = Color.red;
	}

	//Crosshair reverts back to default Color
	public void RemoveHighlight () {
		gameObject.GetComponent<Image>().color = Color.white;
	}
		

}
