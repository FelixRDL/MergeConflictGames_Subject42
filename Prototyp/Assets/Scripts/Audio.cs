using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour {

	public AudioClip audio;
	public AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource.clip = audio;
	}

	public void playAudio() {
		audioSource.Play ();
	}
	

}
