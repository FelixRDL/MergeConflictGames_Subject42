//	Code used from http://wiki.unity3d.com/index.php?title=Animating_Tiled_texture", Courtesy to Joachim Ante (16.2.18)
// and from https://unity3d.com/de/learn/tutorials/topics/scripting/coroutines

var uvAnimationTileX = 2; //Here you can place the number of columns of your sheet.
                           //The above sheet has 24

var uvAnimationTileY = 1; //Here you can place the number of rows of your sheet.
                          //The above sheet has 1
var framesPerSecondEyeOpen : float = 4.0f;
var framesPerSecondEyeClosed : float = 0.2f;
var framesPerSecond : float = 5.0f;
var isOpen = true;

function Start () 
{
	framesPerSecond = framesPerSecondEyeOpen;
	isOpen = true;
    MyCoroutine();
}

function MyCoroutine ()
{
    while(true)
    {
        if(isOpen == true){
			framesPerSecond = framesPerSecondEyeOpen;
			isOpen = false;
		}else{
			framesPerSecond = framesPerSecondEyeClosed;
			isOpen = true;
		}
		print(isOpen);
		print("FPS");
		print(framesPerSecond);
		// Calculate index
		var index : int = Time.time * framesPerSecond;
		// repeat when exhausting all frames
		index = index % (uvAnimationTileX * uvAnimationTileY);
		// Size of every tile
		var size = Vector2 (1.0 / uvAnimationTileX, 1.0 / uvAnimationTileY);
		// split into horizontal and vertical index
		var uIndex = index % uvAnimationTileX;
		// build offset
		// v coordinate is the bottom of the image in opengl so we need to invert.
		var offset = Vector2 (uIndex * size.x, 0.0);
		GetComponent.<Renderer>().material.SetTextureOffset ("_MainTex", offset);
        yield WaitForSeconds(framesPerSecond);
    }
    
    print("Reached the target.");
    print("MyCoroutine is now finished.");
}


