using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorChildrensRoomGarden: Interactable
{

	public AudioClip OpenDoorSound;
	public AudioClip DoorLockedSound;

	bool allowedToOpenDoor;


	void Start ()
	{
		allowedToOpenDoor = true;
	}


	public override void OnInteraction ()
	{
		if (allowedToOpenDoor) {
			SoundManager.instance.PlayEffect (OpenDoorSound);
			SceneManager.LoadScene ("Level2");
		} else {
			if (!SoundManager.instance.GetEffectPlaying ()) {
				print ("Door Locked!");
				SoundManager.instance.PlayEffect (DoorLockedSound);
			}
		}
	}

	public void allowPlayerToGoToGarden ()
	{
		allowedToOpenDoor = true;
	}


}
