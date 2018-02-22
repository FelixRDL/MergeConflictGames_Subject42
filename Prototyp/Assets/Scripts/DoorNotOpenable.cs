using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorNotOpenable: Interactable
{

	public AudioClip DoorLockedSound;


	public override void OnInteraction ()
	{
		SoundManager.instance.PlayEffect (DoorLockedSound);
	}


}
