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

	private const float PLAYER_DEFAULT_FORWARD_SPEED_LEVEL_1 = 1f;
	private const float PLAYER_DEFAULT_BACKWARD_SPEED_LEVEL_1 = 0.5f;
	private const float PLAYER_DEFAULT_STRAFE_SPEED_LEVEL_1 = 1f;

	private const float PLAYER_DEFAULT_FORWARD_SPEED_LEVEL_2 = 1.75f;
	private const float PLAYER_DEFAULT_BACKWARD_SPEED_LEVEL_2 = 1f;
	private const float PLAYER_DEFAULT_STRAFE_SPEED_LEVEL_2 = 1.75f;

	// Use this for initialization
	void Start ()
	{
		blur.enabled = false;
	}

	public void ToggleBlur ()
	{
		blur.enabled = !blur.enabled;
	}

	public void ZoomIn ()
	{
		float fov = Camera.main.fieldOfView;
		Camera.main.fieldOfView = 70;
		//Camera.main.fieldOfView = Mathf.Lerp (30, 5, Time.deltaTime * 5);
	}

	public void ZoomOut ()
	{
		float fov = Camera.main.fieldOfView;
		Camera.main.fieldOfView = 75;
		//Camera.main.fieldOfView = Mathf.Lerp (75, 5, Time.deltaTime * 5);
	}


	//TODO: Put this in another Class
	public void TogglePlayerMovement ()
	{
		if (playerMovementEnabled) {
			player.movementSettings.ForwardSpeed = 0;
			player.movementSettings.BackwardSpeed = 0;
			player.movementSettings.StrafeSpeed = 0;
		} else {
			if (SceneManager.GetActiveScene ().name == "Level1") {
				player.movementSettings.ForwardSpeed = PLAYER_DEFAULT_FORWARD_SPEED_LEVEL_1;
				player.movementSettings.BackwardSpeed = PLAYER_DEFAULT_BACKWARD_SPEED_LEVEL_1;
				player.movementSettings.StrafeSpeed = PLAYER_DEFAULT_STRAFE_SPEED_LEVEL_1;
			} else {
				player.movementSettings.ForwardSpeed = PLAYER_DEFAULT_FORWARD_SPEED_LEVEL_2;
				player.movementSettings.BackwardSpeed = PLAYER_DEFAULT_BACKWARD_SPEED_LEVEL_2;
				player.movementSettings.StrafeSpeed = PLAYER_DEFAULT_STRAFE_SPEED_LEVEL_2;
			}
		}
		playerMovementEnabled = !playerMovementEnabled;
	}

}
