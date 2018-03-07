using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

	private AudioSource playerAudioSource;




	void Start () {
		playerAudioSource = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
		Lvl1_Scn_01_WakeUp ();
	}

	void Lvl1_Scn_01_WakeUp ()
	{
		//
		DialogueManager.instance.StartDialogue(playerAudioSource, "S_0_beide", 1, 0);
	}

	public void Lvl1_Interactable_OpenDoorBath() {
		print ("Open Bath Door");

		//DoorManager.instance.OpenBathroomDoor ();
	}




	void Lvl1_Scn_09_ToggleDarkness() {
		GameObject ceilingParent = GameObject.Find ("CeilingLightGroup");
		for (int i = 0; i < ceilingParent.transform.childCount; i++) {
			Transform lamp = ceilingParent.gameObject.transform.GetChild (i);
			lamp.gameObject.SetActive (!lamp.gameObject.activeSelf);
		}

		GameObject happyPaintings = GameObject.Find ("HappyPaintings");
		for (int i = 0; i < happyPaintings.transform.childCount; i++) {
			Transform painting = happyPaintings.gameObject.transform.GetChild (i);
			painting.gameObject.SetActive (!painting.gameObject.activeSelf);
		}

		GameObject sadPaintings = GameObject.Find ("SadPaintings");
		for (int i = 0; i < sadPaintings.transform.childCount; i++) {
			Transform painting = sadPaintings.gameObject.transform.GetChild (i);
			painting.gameObject.SetActive (!painting.gameObject.activeSelf);
		}

		GameObject happyCubes = GameObject.Find ("HappyCubes");
		for (int i = 0; i < happyCubes.transform.childCount; i++) {
			Transform cube = happyCubes.gameObject.transform.GetChild (i);
			cube.gameObject.SetActive (!cube.gameObject.activeSelf);
		}

		GameObject sadCubes = GameObject.Find ("SadCubes");
		for (int i = 0; i < sadCubes.transform.childCount; i++) {
			Transform cube = sadCubes.gameObject.transform.GetChild (i);
			cube.gameObject.SetActive (!cube.gameObject.activeSelf);
		}

		GameObject happyTrainTracks = GameObject.Find ("HappyTrainTracks");
		for (int i = 0; i < happyTrainTracks.transform.childCount; i++) {
			Transform trainTrackPiece = happyTrainTracks.gameObject.transform.GetChild (i);
			trainTrackPiece.gameObject.SetActive (!trainTrackPiece.gameObject.activeSelf);
		}

		GameObject sadTrainTracks = GameObject.Find ("SadTrainTracks");
		for (int i = 0; i < sadTrainTracks.transform.childCount; i++) {
			Transform trainTrackPiece = sadTrainTracks.gameObject.transform.GetChild (i);
			trainTrackPiece.gameObject.SetActive (!trainTrackPiece.gameObject.activeSelf);
		}

		GameObject happyBottles = GameObject.Find ("HappyBottles");
		for (int i = 0; i < happyBottles.transform.childCount; i++) {
			Transform bottle = happyBottles.gameObject.transform.GetChild (i);
			bottle.gameObject.SetActive (!bottle.gameObject.activeSelf);
		}

		GameObject sadBottles = GameObject.Find ("SadBottles");
		for (int i = 0; i < sadBottles.transform.childCount; i++) {
			Transform bottle = sadBottles.gameObject.transform.GetChild (i);
			bottle.gameObject.SetActive (!bottle.gameObject.activeSelf);
		}
	}
}
