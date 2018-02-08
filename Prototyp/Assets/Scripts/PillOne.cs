using UnityEngine;

public class PillOne : Interactable
{

	public AudioClip EatSound;
	public AudioClip BackgroundMusicLight;


	public override void OnInteraction ()
	{
		print ("On Interaction with Pill!");

		SoundManager.instance.PlayEffect (EatSound);
		SoundManager.instance.PlayBackgroundMusic (BackgroundMusicLight, 2f);

		Destroy (gameObject);
	}
}
