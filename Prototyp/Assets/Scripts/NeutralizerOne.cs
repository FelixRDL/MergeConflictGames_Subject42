using UnityEngine;

public class NeutralizerOne : Interactable
{

	public AudioClip DrinkSound;
	public AudioClip Dialogue_S_1_3;


	public override void OnInteraction ()
	{
		print ("On Interaction with Neutralizer!");

		SoundManager.instance.PlayEffect (DrinkSound);
		SoundManager.instance.StopBackgroundMusic ();
		SoundManager.instance.PlayCombinedDialogue (Dialogue_S_1_3, 1f);

		LightManager.instance.ToggleLightsInNursery ();
	}
}
