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
				if (GetInteractionAllowed ()) {
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

	private bool GetInteractionAllowed ()
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

			if (GetInteractionAllowed ()) {
				hint = "<b>[E]: " + GetHintForCurrentInteractable () + "</b>";
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

	private string GetHintForCurrentInteractable ()
	{
		switch (gameObject.name) {

		//Level 1 Interactables:
		case "Interactable_Window":
			return "Look out of Window";
		case "Interactable_Medical_Devices":
			return "Look at Medical Devices";
		case "Interactable_Picture_Frame_Hospital":
			return "Look at Picture";
		case "Interactable_Mirror_Bath":
			return "Look at Mirror";
		case "Interactable_Contract":
			return "Look at Contract";
		case "Interactable_Rubber_Duck":
			return "Look at Rubber Duck";
		case "Interactable_Desinfection":
			return "Look at Disinfectant Dispenser";
		case "Interactable_Door_Hospital_To_Floor":
			return "Look at Door";
		case "Interactable_Door_Bathroom":
			return "Open Door";
		case "Interactable_Door_Floor_01":
			return "Open Door";
		case "Interactable_Door_Floor_02":
			return "Open Door";
		case "Interactable_Pill_Floor":
			return "Eat Pill from Packet";
		case "Interactable_Door_Floor_To_Childrens_Room":
			return "Open Door";
		case "Interactable_Wooden_Train_Happy":
			return "Look at Wooden Train";
		case "Interactable_Frame_Family":
			return "Look at Painting";
		case "Interactable_Frame_Dog":
			return "Look at Painting";
		case "Interactable_Teddy":
			return "Look at Teddy";
		case "Interactable_Light_Switch":
			return "Press Lightswitch";
		case "Interactable_Beer_Bottle":
			return "Look at Beer Bottles";
		case "Interactable_Cubes_Sad":
			return "Look at Toy Cubes";
		case "Interactable_Frame_Friend_Sad":
			return "Look at Painting";
		case "Interactable_Teddy_Sad":
			return "Look at Teddy";
		case "Interactable_Wooden_Train_Sad":
			return "Look at Wooden Train";
		case "Interactable_Door_Childrens_Room_To_Garden":
			return "Go through Door";
		case "Interactable_Neutralizer":
			return "Drink Neutralizer";

		//Level 2 Interactables:
		case "Interactable_Keypad":
			return "Look at Keypad";
		case "Interactable_DJ_Console":
			return "Talk with DJ";
		case "Interactable_Pill_01":
			return "Eat Pill from Packet";
		case "Interactable_Dancer":
			return "Look at Dancers";
		case "Interactable_Dancer_On_Floor":
			return "Look at People on Floor";
		case "Interactable_Friend_Fence":
			return "Talk with Friend";
		case "Interactable_Pill_02":
			return "Eat Pill from Packet";
		case "Interactable_Friend_Dome":
			return "Talk with Friend";
		case "Interactable_Pill_03":
			return "Eat Pill from Packet";
		case "Interactable_Friend_Dead":
			return "Look at Friend";
		case "Interactable_Note_Code_For_Keypad":
			return "Look at Note";
		default:
			return "To Interact";
		}
	}
}
