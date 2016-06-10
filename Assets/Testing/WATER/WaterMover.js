#pragma strict
var scrollSpeed = 0.25;
function FixedUpdate(){
 var offset = Time.time * scrollSpeed;
 GetComponent.<Renderer>().material.mainTextureOffset = Vector2(0,-offset);
 GetComponent.<Renderer>().material.SetTextureOffset("_BumpMap", Vector2(0,-offset));
 }