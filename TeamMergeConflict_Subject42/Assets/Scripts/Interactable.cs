using UnityEngine;

//The Main Class for all Objects that allow Interaction
public class Interactable : MonoBehaviour
{
	//Important: Every clickable object needs a box collider in order to be a raycast target.

	//The Radius of the the distance between the player and the Object within that interaction is allowed
	public float radius = 1.5f;

	//If set to true, the GameObject can also be interacted with while a dialogue is running.
	public bool interactionAllowedDuringDialogue = false;

	//Defines wether Interaction is only possible once or multiple times. 
	public bool disableAfterFirstInteraction = true;

	//the Crosshair of the game.
	private Crosshair crosshair;

	//Defines wether a hint for interaction, e.g "[E] to interact" should be displayed.
	private bool showHint = false;

	//Defines if the Interactable Object is enabled or not
	private bool isEnabled = true;

	//This GUIStyle holds the definition for the appearance of the Interaction Hints on sceen
	private GUIStyle hintGUIStyle = new GUIStyle ();

	void Awake ()
	{
		crosshair = GameObject.Find ("Crosshair").GetComponent<Crosshair> ();
		InitHintGUIStile ();
	}

	//Defines the appearance of the hints displayed on screen
	private void InitHintGUIStile ()
	{
		//Values for GUIStile taken mostly from the following tutorial: https://www.youtube.com/watch?v=1NW0BYn5KfE
		hintGUIStyle.fixedWidth = Screen.width / 1.5f;
		hintGUIStyle.wordWrap = true;
		hintGUIStyle.alignment = TextAnchor.MiddleCenter;
		hintGUIStyle.normal.textColor = Color.white;
		hintGUIStyle.fontSize = Mathf.FloorToInt (Screen.height * 0.0225f);
	}

	//This function gets called, if an Interactable Object is in Focus
	public void OnFocused (Transform player)
	{
		if (isEnabled) {
			//Calculate distance between player and the Interactable Object
			float distance = Vector3.Distance (player.position, transform.position);

			//Checks if the distance is smaller than the radius within Interaction is allowed
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

	//This function gets called, if an Interactable Object gets clicked
	public void OnClicked (Transform player)
	{
		if (isEnabled) {
			//The distance to the player gets checked and if he is within radius, OnInteraction() gets called.
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

	//Destroys the GameObject. But first, OnFocused () gets called to remove the Crosshair Highlight.
	public void Destroy (float delay)
	{
		OnDefocused ();
		Destroy (gameObject, delay);
	}

	//Displays a yellow Sphere that highlights the radius within Interaction is allowed
	void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere (transform.position, radius);
	}

	//Each Interactable Object will overwrite this function to allow for custom interaction.
	public virtual void OnInteraction ()
	{
	}

	//Checks, if Interaction with the GameObject currently is allowed
	private bool GetInteractionAllowed ()
	{
		if (!DialogueManager.instance.IsDialoguePlaying () || interactionAllowedDuringDialogue) {
			return true;
		} else {
			return false;
		}
	}

	//If Object is focused and interaction is allowed, a hint is displayed on screen
	void OnGUI ()
	{
		if (showHint) {

			string hint = "";

			if (GetInteractionAllowed ()) {
				hint = "<b>[E]: " + GetHintForCurrentInteractable () + "</b>";
			} else {
				hint = "...";
			}

			DrawHintOnScreen (hint);
		}
	}

	//Displays the hint on the screen
	private void DrawHintOnScreen (string hint)
	{
		Vector2 size = hintGUIStyle.CalcSize (new GUIContent ());

		//Draw the Hint with 1px white offset.
		GUI.contentColor = Color.black;
		GUI.Label (new Rect (Screen.width / 2 - size.x / 2 + 1, Screen.height / 1.1f - size.y + 1, size.x, size.y), hint, hintGUIStyle);
		GUI.contentColor = Color.white;
		GUI.Label (new Rect (Screen.width / 2 - size.x / 2, Screen.height / 1.1f - size.y, size.x, size.y), hint, hintGUIStyle);
	}

	//This switch statement contains all Interactables in the game and defines a custom hint for each one
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
			return "Look at Door";
		case "Interactable_Door_Floor_02":
			return "Look at Door";
		case "Interactable_Pill_Floor":
			return "Eat Pill from Packet";
		case "Interactable_Door_Floor_To_Childrens_Room":
			return "Look at Door";
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
			return "Open Door";
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
