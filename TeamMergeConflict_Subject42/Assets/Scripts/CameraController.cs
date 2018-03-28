using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.ImageEffects;
using UnityStandardAssets.Characters.FirstPerson;

//DELETE THIS CLASS! CONTENT NOW IN EFFECTMANAGER


public class CameraController : MonoBehaviour
{

	public BlurOptimized blur;
	public RigidbodyFirstPersonController player;

	private bool playerMovementEnabled = true;

	private const float PLAYER_DEFAULT_WALK_SPEED_LEVEL_1 = 1f;
	private const float PLAYER_DEFAULT_RUN_SPEED_LEVEL_1 = 1f;
	private const float PLAYER_DEFAULT_WALK_SPEED_LEVEL_2 = 1.75f;
	private const float PLAYER_DEFAULT_RUN_SPEED_LEVEL_2 = 2.5f;


	// Use this for initialization
	void Start ()
	{
		blur.enabled = false;
	}

	public void ToggleBlur ()
	{
		blur.enabled = !blur.enabled;
	}


	//TODO: Put this in another Class
	public void TogglePlayerMovement() {
		if (playerMovementEnabled) {
			player.movementSettings.ForwardSpeed = 0;
			player.movementSettings.BackwardSpeed = 0;
			player.movementSettings.StrafeSpeed = 0;
		} else {
			player.movementSettings.ForwardSpeed = 1.75f;
			player.movementSettings.BackwardSpeed = 1f;
			player.movementSettings.StrafeSpeed = 1.75f;
		}
		playerMovementEnabled = !playerMovementEnabled;
	}

}
