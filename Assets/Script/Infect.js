#pragma strict

function Start () {
	
}

function Update () {
	
}

function OnCollisionEnter (col : Collision) {
	if (col.gameObject.name == "Player") {
		transform.GetComponent.<Renderer>().material.color = Color(.816, .612, .816);
	}
}
