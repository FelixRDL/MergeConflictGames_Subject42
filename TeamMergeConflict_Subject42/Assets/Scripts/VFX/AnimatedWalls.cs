using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Inspired by http://wiki.unity3d.com/index.php?title=Animating_Tiled_texture“, Courtesy to Joachim Ante (16.2.18)
//This class is responsible for the movement of the Clouds on the walls in the Childrens Room
public class AnimatedWalls : MonoBehaviour {

	//The movement speed of the Clouds on the walls
	public float movementSpeed = 0.5f;

	void Update () {

		// build offset
		Vector2 offset = new Vector2 (-Time.time*movementSpeed/4, 0);

		// size offset 
		Vector2 size = new Vector2(1,Mathf.Sin(-Time.time*movementSpeed/8));

		GetComponent<Renderer>().material.SetTextureOffset ("_MainTex", offset);
	}
}
