using UnityEngine;

public class PillOne : Interactable
{

	public AudioClip EatSound;
	public AudioClip BackgroundMusicLight;
	public AudioClip Dialogue_S_1_0_Proceed;

	//temp
	public DoorFloorChildrensRoom door;

	bool pillAlreadyEaten;

	void Start ()
	{
		pillAlreadyEaten = false;
	}


	public override void OnInteraction ()
	{
		print ("On Interaction with Pill!");

		if (!pillAlreadyEaten) {
			SoundManager.instance.PlayEffect (EatSound);
			SoundManager.instance.PlayBackgroundMusic (BackgroundMusicLight, 2f);
			SoundManager.instance.PlayTestManagerDialogue(Dialogue_S_1_0_Proceed, 0.5f);
			
			//temp
			Invoke ("openDoor", 4);
			
			pillAlreadyEaten = true;
		}

		//Destroy (gameObject);

	}

	void openDoor ()
	{
		door.OpenDoor ();
	}
}
