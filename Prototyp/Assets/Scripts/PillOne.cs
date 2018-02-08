using UnityEngine;

public class PillOne : Interactable
{

	public AudioClip EatSound;
	public AudioClip BackgroundMusicLight;
	public AudioClip Dialogue_S_1_0_Proceed;

	public override void OnInteraction ()
	{
		print ("On Interaction with Pill!");

		SoundManager.instance.PlayEffect (EatSound);
		SoundManager.instance.PlayBackgroundMusic (BackgroundMusicLight, 2f);
		SoundManager.instance.PlayTestManagerDialogue(Dialogue_S_1_0_Proceed, 0.5f);

		Destroy (gameObject);
	}
}
