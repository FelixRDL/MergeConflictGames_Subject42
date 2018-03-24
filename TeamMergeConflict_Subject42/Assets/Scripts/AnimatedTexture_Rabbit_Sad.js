//	Code used from http://wiki.unity3d.com/index.php?title=Animating_Tiled_texture", Courtesy to Joachim Ante (16.2.18)


var uvAnimationTileX = 2; //Here you can place the number of columns of your sheet.
                           //The above sheet has 24

var uvAnimationTileY = 1; //Here you can place the number of rows of your sheet.
                          //The above sheet has 1
var framesPerSecond = 1.0;

function Update () {

	// Calculate index
	var index : int = Time.time * framesPerSecond;
	// repeat when exhausting all frames
	index = index % (uvAnimationTileX * uvAnimationTileY);

	// Size of every tile
	var size = Vector2 (1.0 / uvAnimationTileX, 1.0 / uvAnimationTileY);
	//var size = Vector2 (1024, 1024);

	// split into horizontal and vertical index
	var uIndex = index % uvAnimationTileX;
	// var vIndex = index / uvAnimationTileX;

	//var vIndex = index % uvAnimationTileX;

	// build offset
	// v coordinate is the bottom of the image in opengl so we need to invert.
	//var offset = Vector2 (uIndex * size.x, 1.0 - size.y - vIndex * size.y);
	var offset = Vector2 (uIndex * size.x, 0.0);
	GetComponent.<Renderer>().material.SetTextureOffset ("_MainTex", offset);
}
