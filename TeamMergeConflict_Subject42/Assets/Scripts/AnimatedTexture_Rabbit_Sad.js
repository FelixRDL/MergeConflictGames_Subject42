//	Code used from http://wiki.unity3d.com/index.php?title=Animating_Tiled_texture", Courtesy to Joachim Ante (16.2.18)

var uvAnimationTileX = 2; //Here you can place the number of columns of your sheet.
                           //The above sheet has 24

var uvAnimationTileY = 1; //Here you can place the number of rows of your sheet.
                          //The above sheet has 1
var framesPerSecondEyeOpen : float = 4.0f;
var framesPerSecondEyeClosed : float = 0.2f;
var speed : float = 4.0f;
var isOpen = true;
var index = 0;
var passedTime = 0.0f;
var openOffset = Vector2 (0.0, 0.0);
var closeOffset = Vector2 (0.5, 0.0);

function Start () 
{
	speed = framesPerSecondEyeOpen;
	isOpen = true;
    //MyCoroutine();
    var size = Vector2 (1.0 / uvAnimationTileX, 1.0 / uvAnimationTileY);
}


function Update(){
	passedTime += Time.deltaTime;
		if(isOpen == true){
			speed = framesPerSecondEyeOpen;
			if (passedTime >= framesPerSecondEyeOpen) {
				// reset passedTime
				passedTime = passedTime % framesPerSecondEyeOpen;
				closeEye ();
			}
		}else{
			speed = framesPerSecondEyeClosed;
			print("else");
			if (passedTime >= framesPerSecondEyeClosed) {
				passedTime = passedTime % framesPerSecondEyeClosed;
				openEye ();
			}
		}
}


function closeEye(){
	GetComponent.<Renderer>().material.SetTextureOffset ("_MainTex", closeOffset);
	isOpen = false;
}

function openEye(){
// Calculate index
	GetComponent.<Renderer>().material.SetTextureOffset ("_MainTex", openOffset);
	isOpen = true;
}
