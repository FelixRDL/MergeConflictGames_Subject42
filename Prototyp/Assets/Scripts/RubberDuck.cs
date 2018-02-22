using UnityEngine;

public class RubberDuck : Interactable
{

	public AudioClip Quack01;
	public AudioClip Quack02;
	public AudioClip Quack03;
	public AudioClip Quack04;

	AudioClip[] quackArray;

	void Start ()
	{
		quackArray = new AudioClip[] { Quack01, Quack02, Quack03, Quack04 };
	}


	public override void OnInteraction ()
	{
		print ("On Interaction with Duck!");

		AudioClip randomQuack = quackArray[Random.Range(0, quackArray.Length)];

		SoundManager.instance.PlayEffect (randomQuack);

	}
}
