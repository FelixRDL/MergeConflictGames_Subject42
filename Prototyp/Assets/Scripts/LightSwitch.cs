using UnityEngine;

public class LightSwitch : Interactable
{

	public AudioClip OnOffSound;
	public AudioClip BackgroundMusicDark;
	public AudioClip Dialogue_S_1_2;

	//temp
	public DoorFloorChildrensRoom door;

	bool alreadyPressed;

	void Start ()
	{
		alreadyPressed = false;
	}

	public override void OnInteraction ()
	{

		print ("On Interaction with LightSwitch!");


		if (!alreadyPressed) {
			alreadyPressed = true;	
			LightManager.instance.ToggleLightsInNursery ();

			SoundManager.instance.PlayEffect (OnOffSound);
			SoundManager.instance.PlayBackgroundMusic (BackgroundMusicDark, 0.5f);
			SoundManager.instance.PlayCombinedDialogue (Dialogue_S_1_2, 1f);
	
			//temp
			Invoke ("openDoor", 26);
		}

	}

	void openDoor ()
	{
		door.OpenDoor ();
	}
}
