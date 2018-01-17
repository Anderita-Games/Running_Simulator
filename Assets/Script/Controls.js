#pragma strict
var IsGrounded : boolean;

function Start () {
	
}

function Update () {
	if ((Input.GetKey (KeyCode.UpArrow) || Input.GetMouseButtonDown(0)) && IsGrounded == true) {
		GetComponent.<Rigidbody>().velocity.y = 6;
	}
}

function OnCollisionStay (col : Collision) {
	IsGrounded = true;
}

function OnCollisionExit (col : Collision) {
	IsGrounded = false;
}