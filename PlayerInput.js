#pragma strict

function Start () {
	Debug.Log("started");
}

function Update () {
	if(Input.GetKeyDown(KeyCode.R)) {
		Debug.Log("R pressed");
		gameObject.GetComponent.<Renderer>().material.color = Color.red;
	}
	if(Input.GetKeyDown(KeyCode.Y)) {
		Debug.Log("Y pressed");
		gameObject.GetComponent.<Renderer>().material.color = Color.yellow;
	}
	if(Input.GetKeyDown(KeyCode.B)) {
		Debug.Log("B pressed");
		gameObject.GetComponent.<Renderer>().material.color = Color.blue;
	}
}
