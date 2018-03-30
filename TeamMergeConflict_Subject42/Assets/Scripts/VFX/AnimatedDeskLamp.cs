using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Inspired by http://wiki.unity3d.com/index.php?title=Animating_Tiled_texture“, Courtesy to Joachim Ante (16.2.18)
public class AnimatedDeskLamp : MonoBehaviour {


	private float speed = 0.5f;

	void Start () {
		
	}

	void Update () {
		// build offset
		Vector2 offset = new Vector2 (-Time.time*speed/4, 0);

		// size offset 
		Vector2 size = new Vector2(1,Mathf.Sin(-Time.time*speed/8));

		GetComponent<Renderer>().material.SetTextureOffset ("_MainTex", offset);
		GetComponent<Renderer>().material.SetTextureScale ("_MainTex", size);
	}
}
