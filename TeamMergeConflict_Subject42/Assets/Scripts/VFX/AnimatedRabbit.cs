using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Inspired by http://wiki.unity3d.com/index.php?title=Animating_Tiled_texture", Courtesy to Joachim Ante (16.2.18)
public class AnimatedRabbit : MonoBehaviour
{

	public float secondsEyesOpen = 4.0f;
	public float secondsEyesClosed = 0.1f;

	private Vector2 OFFSET_OPEN = new Vector2 (0.0f, 0.0f);
	private Vector2 OFFSET_CLOSED = new Vector2 (0.5f, 0.0f);

	private bool isOpen = true;
	private float passedTime = 0.0f;

	void Start ()
	{
		StartCoroutine (BlinkEyeCoroutine ());
	}


	IEnumerator BlinkEyeCoroutine ()
	{
		while (true) {
			closeEye ();
			yield return new WaitForSeconds (secondsEyesClosed);
			openEye ();
			yield return new WaitForSeconds (secondsEyesClosed);
			closeEye ();
			yield return new WaitForSeconds (secondsEyesClosed);
			openEye ();
			yield return new WaitForSeconds (secondsEyesOpen);
		}
	}


	private void closeEye ()
	{
		GetComponent<Renderer> ().material.SetTextureOffset ("_MainTex", OFFSET_CLOSED);
		isOpen = false;
	}

	private void openEye ()
	{
		GetComponent<Renderer> ().material.SetTextureOffset ("_MainTex", OFFSET_OPEN);
		isOpen = true;
	}

}
