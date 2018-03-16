//Code used from: https://hellocoding.wordpress.com/2017/07/11/starting-animation-at-different-time-unity/ retrieved 16. March 2018

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startAnimationOnRandomFrame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Animator anim = GetComponent<Animator> ();
		AnimatorStateInfo state = anim.GetCurrentAnimatorStateInfo (0);
		anim.Play (state.fullPathHash, -1, Random.Range(0f,1f));
		print ("Anim");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
