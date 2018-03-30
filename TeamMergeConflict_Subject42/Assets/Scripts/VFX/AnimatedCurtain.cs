using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Inspired by http://wiki.unity3d.com/index.php?title=Animating_Tiled_texture“, Courtesy to Joachim Ante (16.2.18)
public class AnimatedCurtain : MonoBehaviour
{

	public float animationSpeed = 0.5f;

	void Start ()
	{
		StartCoroutine (AnimateCurtainsCoroutine ());
	}

	IEnumerator AnimateCurtainsCoroutine ()
	{
		while (true) {
			
			// build offset
			Vector2 offset = new Vector2 (-Time.time * animationSpeed / 4, 0);

			// size offset 
			Vector2 size = new Vector2 (1, Mathf.Sin (-Time.time * animationSpeed / 8));

			GetComponent<Renderer> ().material.SetTextureOffset ("_MainTex", offset);
			GetComponent<Renderer> ().material.SetTextureScale ("_MainTex", size);
			yield return null;
		}
	}
}
