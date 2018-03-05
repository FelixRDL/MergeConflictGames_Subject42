using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

	private AudioSource playerAudioSource;


	void Start () {
		playerAudioSource = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
		Lvl1_Scn_01_WakeUp ();
	}

	public void Lvl1_Scn_01_WakeUp ()
	{
		//
		DialogueManager.instance.StartDialogue(playerAudioSource, "S_0_beide", 1, 0);
	}
}
