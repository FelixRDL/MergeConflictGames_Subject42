using UnityEngine;

public class PillOne : Interactable
{

	public AudioClip EatSound;
	public AudioClip BackgroundMusicLight;
	public AudioClip Dialogue_S_1_0_Proceed;

	//temp
	public DoorFloorChildrensRoom door;

	bool pillAlreadyEaten;
	bool pillAlowedToEat;

	void Start ()
	{
		pillAlowedToEat = false;
		pillAlreadyEaten = false;
	}


	public override void OnInteraction ()
	{
		print ("On Interaction with Pill!");

		if (!pillAlreadyEaten && pillAlowedToEat) {
			SoundManager.instance.PlayEffect (EatSound);
			SoundManager.instance.PlayBackgroundMusic (BackgroundMusicLight, 2f);
			SoundManager.instance.PlayTestManagerDialogue(Dialogue_S_1_0_Proceed, 0.5f);
			
			//temp
			Invoke ("openDoor", 2);
			
			pillAlreadyEaten = true;
		}

		//Destroy (gameObject);

	}

	public void allowPlayerToEatPill()
	{
		print("Player ist now allowed to eat the Pill!");
		pillAlowedToEat = true;
	}

	void openDoor ()
	{
		door.OpenDoor ();
	}
}
