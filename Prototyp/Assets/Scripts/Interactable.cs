using UnityEngine;

public class Interactable : MonoBehaviour
{
	//Every clickable object needs a box collider.

	//To move the interaction box, create here a new Interactiontransform object

	//Change the radius of the the distance that allows interaction
	public float radius = 1f;

	bool isFocused = false;
	Transform player;


	void Update ()
	{
		if (isFocused) {
			float distance = Vector3.Distance (player.position, transform.position);
			if (distance <= radius) {
				OnInteraction ();
			}
			OnDefocused ();
		}
	}

	public void OnFocused (Transform playerTransform)
	{
		isFocused = true;
		player = playerTransform;
	}

	public void OnDefocused ()
	{
		isFocused = false;
		player = null;
	}

	void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere (transform.position, radius);
	}


	public virtual void OnInteraction ()
	{
	}
}
