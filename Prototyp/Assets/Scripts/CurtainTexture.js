//    Code used from http://wiki.unity3d.com/index.php?title=Animating_Tiled_texture“, Courtesy to Joachim Ante (16.2.18)

var speed = 20.0;

var scaleAmplitude = 4;

function Update () {

    // build offset
    // v coordinate is the ind of the image in opengl so we need to invert.
    var offset = Vector2 (-Time.time*speed/4, 0);

    // size offset 
    var size = Vector2(1, scaleAmplitude* Mathf.Sin(-Time.time*speed/8));


    //print(size.toString());

    GetComponent.<Renderer>().material.SetTextureOffset ("_MainTex", offset);
    //GetComponent.<Renderer>().material.SetTextureScale (“_MainTex”, size);
}