using UnityEngine;

public class NeutralizerOne : Interactable
{

	public AudioClip DrinkSound;
	public AudioClip Dialogue_S_1_3;

	bool allowInteraction;

	void Start ()
	{
		allowInteraction = false;
	}


	public override void OnInteraction ()
	{
		if (allowInteraction) {
			
			print ("On Interaction with Neutralizer!");
			
			SoundManager.instance.PlayEffect (DrinkSound);
			SoundManager.instance.StopBackgroundMusic ();
			SoundManager.instance.PlayCombinedDialogue (Dialogue_S_1_3, 1f);
			
			LightManager.instance.ToggleLightsInNursery ();
		} 
	}


	public void allowInteractionWithNeutralizer()
	{
		allowInteraction = true;
	}
}
