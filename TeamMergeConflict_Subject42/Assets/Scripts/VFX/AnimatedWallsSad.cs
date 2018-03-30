using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Inspired by http://wiki.unity3d.com/index.php?title=Animating_Tiled_texture“, Courtesy to Joachim Ante (16.2.18)
//This class is responsible for the movement of the Clouds on the walls in the Childrens Room Sad State
public class AnimatedWallsSad : MonoBehaviour
{

	//The movement speed of the Clouds on the walls
	public float movementSpeed = 2;

	void Update ()
	{
		Vector2 offset = new Vector2 (-Time.time * movementSpeed / 4, 0);
		GetComponent<Renderer> ().material.SetTextureOffset ("_MainTex", offset);
	}
}
