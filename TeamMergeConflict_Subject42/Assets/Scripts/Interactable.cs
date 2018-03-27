using UnityEngine;

public class Interactable : MonoBehaviour
{
	//Important: Every clickable object needs a box collider in order to be a raycast goal.

	//The Radius of the the distance that allows interaction
	public float radius = 1.5f;

	//If set to true, the GameObject can also be interacted with while a dialogue is running.
	public bool interactionAllowedDuringDialogue = false;

	private Crosshair crosshair;

	private bool showHint = false;
	private bool isEnabled = true;

	private GUIStyle hintGUIStyle = new GUIStyle ();

	void Awake ()
	{
		crosshair = GameObject.Find ("Crosshair").GetComponent<Crosshair> ();
		InitHintGUIStile ();
	}

	private void InitHintGUIStile ()
	{
		//Values for GUIStile taken from the following tutorial: https://www.youtube.com/watch?v=1NW0BYn5KfE
		hintGUIStyle.fixedWidth = Screen.width / 1.5f;
		hintGUIStyle.wordWrap = true;
		hintGUIStyle.alignment = TextAnchor.MiddleCenter;
		hintGUIStyle.normal.textColor = Color.white;
		hintGUIStyle.fontSize = Mathf.FloorToInt (Screen.height * 0.0225f);
	}

	public void OnFocused (Transform player)
	{

		if (isEnabled) {
			
			float distance = Vector3.Distance (player.position, transform.position);

			if (distance <= radius) {
				showHint = true;
				crosshair.SetHighlight ();
			} else {
				OnDefocused ();
			}	
		}
	}

	//Removes the Highlight from the Crosshair
	public void OnDefocused ()
	{
		showHint = false;
		crosshair.RemoveHighlight ();
	}

	//If the GameObject gets clicked the distance to the player gets checked and if he is within radius, OnInteraction() gets called.
	public void OnClicked (Transform player)
	{
		if (isEnabled) {
			float distance = Vector3.Distance (player.position, transform.position);
			if (distance <= radius) {
				if (GetInterActionAllowed()) {
					OnInteraction ();
				}
			}
			OnDefocused ();
		}
	}


	//Enables the Interaction with the GameObject
	public void Enable ()
	{
		isEnabled = true;
		GetComponent<BoxCollider> ().enabled = true;
	}

	//Disables the Interaction with the GameObject
	public void Disable ()
	{
		OnDefocused ();
		isEnabled = false;
	}

	//Destroys the GameObject. But first, the Crosshair Highlight gets removed.
	public void Destroy (float delay)
	{
		OnDefocused ();
		Destroy (gameObject, delay);
	}

	void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere (transform.position, radius);
	}

	//Each Interactable Object will overwrite this function to allow for custom interaction.
	public virtual void OnInteraction ()
	{
	}

	private bool GetInterActionAllowed()
	{
		if (!DialogueManager.instance.IsDialoguePlaying () || interactionAllowedDuringDialogue) {
			return true;
		} else {
			return false;
		}
	}

	void OnGUI ()
	{
		//If Object is focused and interaction is allowed, show hint to press "E".

		if (showHint) {

			string hint = "";

			if (GetInterActionAllowed()) {
				hint = "<b>[E] to interact</b>";
			} else {
				hint = "...";
			}

			Vector2 size = hintGUIStyle.CalcSize (new GUIContent ());

			//Draw the Hint with 1px white offset.
			GUI.contentColor = Color.black;
			GUI.Label (new Rect (Screen.width / 2 - size.x / 2 + 1, Screen.height / 1.1f - size.y + 1, size.x, size.y), hint, hintGUIStyle);
			GUI.contentColor = Color.white;
			GUI.Label (new Rect (Screen.width / 2 - size.x / 2, Screen.height / 1.1f - size.y, size.x, size.y), hint, hintGUIStyle);
		}
	}
}
