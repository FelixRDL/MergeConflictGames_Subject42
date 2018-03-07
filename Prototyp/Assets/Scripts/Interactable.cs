using UnityEngine;

public class Interactable : MonoBehaviour
{
	//Every clickable object needs a box collider.
	//TODO: Allow to move the interaction box with Interactiontransform object

	//Change the radius of the the distance that allows interaction
	public float radius = 1.5f;

	private Material outline;
	private Shader outlineShader;

	private Renderer rend;
	private Material defaultMaterial;

	private Crosshair crosshair;

	bool showHint = false;

	private GUIStyle subtitleStyle = new GUIStyle ();

	void Awake ()
	{
		rend = GetComponent<Renderer> ();
		rend.enabled = true;

		//outline = Resources.Load ("Custom_Outline", typeof(Material)) as Material;
		//outlineShader = Shader.Find ("Custom/Outline");

		crosshair = GameObject.Find("Crosshair").GetComponent<Crosshair> ();

	}

	public void OnFocused (Transform player)
	{
		//Outline anzeigen

		float distance = Vector3.Distance (player.position, transform.position);
		if (distance <= radius) {
			showHint = true;
			crosshair.SetHighlight ();

			//defaultMaterial = rend.material;
			//rend.material = outline;
			//rend.material.color = Color.blue; 

			//rend.material.shader = outlineShader;
		} else {
			OnDefocused ();
		}
			
	}

	public void OnDefocused ()
	{
		//Outline entfernen

		showHint = false;
		crosshair.RemoveHighlight ();

		//rend.material = defaultMaterial;

	}

	public void OnClicked (Transform player)
	{
		print ("Interactable clicked");

		float distance = Vector3.Distance (player.position, transform.position);
		if (distance <= radius) {
			print ("Interactable clicked and within reach");
			OnInteraction ();
		} else {
			print ("Interactable clicked BUT not within reach");
		}
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

	void OnGUI ()
	{
		//If Object is focused, show hint to press "E".

		if (showHint) {
			//Put hint over everything and position on screen.
			GUI.depth = -1001;
			subtitleStyle.fixedWidth = Screen.width / 1.5f;
			subtitleStyle.wordWrap = true;
			subtitleStyle.alignment = TextAnchor.MiddleCenter;
			subtitleStyle.normal.textColor = Color.white;
			subtitleStyle.fontSize = Mathf.FloorToInt (Screen.height * 0.0225f);

			Vector2 size = subtitleStyle.CalcSize (new GUIContent ());

			//Draw text with 1px white offset.
			GUI.contentColor = Color.black;
			GUI.Label (new Rect (Screen.width / 2 - size.x / 2 + 1, Screen.height / 1.5f - size.y + 1, size.x, size.y), "Press E to interact", subtitleStyle);
			GUI.contentColor = Color.white;
			GUI.Label (new Rect (Screen.width / 2 - size.x / 2, Screen.height / 1.5f - size.y, size.x, size.y), "Press E to interact", subtitleStyle);
		}
	}
}
