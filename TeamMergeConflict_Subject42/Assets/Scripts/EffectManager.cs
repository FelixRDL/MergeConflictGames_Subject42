﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;
using UnityStandardAssets.Characters.FirstPerson;

public class EffectManager : MonoBehaviour {

	public BlurOptimized blur;
	public RigidbodyFirstPersonController player;

	private bool playerMovementEnabled = true;

	void Start () {
		blur.enabled = false;
	}

	public void ToggleBlur() {
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
