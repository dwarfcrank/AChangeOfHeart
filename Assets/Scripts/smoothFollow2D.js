
#pragma strict

var target : Transform;
var smoothTime = 0.3;
static var thisTransform : Transform;
private var velocity : Vector2;

function Start()
{
	thisTransform = transform;
}

function Update() 
{
	thisTransform.position.x = Mathf.SmoothDamp( thisTransform.position.x, 
		target.position.x+4.0f, velocity.x, smoothTime);
}