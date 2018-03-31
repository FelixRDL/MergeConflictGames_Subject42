//Code used from http://wiki.unity3d.com/index.php?title=Animating_Tiled_texture", Courtesy to Joachim Ante (16.2.18)

var uvAnimationTileX = 2;
var uvAnimationTileY = 2;
var framesPerSecond = 20.0;

function Update () {

	var index : int = Time.time * framesPerSecond;
	index = index % (uvAnimationTileX * uvAnimationTileY);
	var size = Vector2 (1.0 / uvAnimationTileX, 1.0 / uvAnimationTileY);

	// split into horizontal and vertical index
	var uIndex = index % uvAnimationTileX;
	var vIndex = index / uvAnimationTileX;

	// build offset
	// v coordinate is the bottom of the image in opengl so we need to invert.
	var offset = Vector2 (uIndex * size.x, 1.0 - size.y - vIndex * size.y);

	GetComponent.<Renderer>().material.SetTextureOffset ("_MainTex", offset);
	GetComponent.<Renderer>().material.SetTextureScale ("_MainTex", size);
}
