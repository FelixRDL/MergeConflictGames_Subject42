using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorNotOpenable: Interactable
{

	public AudioClip DoorLockedSound;


	public override void OnInteraction ()
	{
		if (!SoundManager.instance.GetEffectPlaying()) {
			print ("Door Locked!");
			SoundManager.instance.PlayEffect (DoorLockedSound);
		}
	}


}
