#pragma strict
var Started : boolean = false;

var Floor_Prefab : GameObject;
var Floor_New : GameObject;
var Quantity : int = 1;
var X : int = -10; 

var Intro_Text : GameObject;
var CurrentTime : UnityEngine.UI.Text;
var HighTime : UnityEngine.UI.Text;
var Time_Elapsed : int;

var Player : GameObject;
var Cameras : GameObject; // For location
var The_Camera : Rigidbody;
var Speed : float = 3;

function Start () {
	while (Quantity < 30) {
		Floor_New = Instantiate(Floor_Prefab, new Vector3 (X, 0, 0),  Quaternion.identity);
    	PlayerPrefs.SetInt("Block Total", PlayerPrefs.GetInt("Block Total") + 1);
    	Quantity++;
    	X++;
    	Floor_New.name = "Floor #" + Quantity;
    }

    if (Application.loadedLevelName == "MainMenu2") {
    	Started = true;
		Creation();
		TimeAdder();
    } 
}

function Update () {
	if (Input.GetMouseButtonDown(0) && Started == false && Time_Elapsed <= 0) {
		Started = true;
		Creation();
		TimeAdder();
	}else if (Input.GetMouseButtonDown(0) && Started == false) {
		Application.LoadLevel("MainMenu2");
	}

	if (Player.transform.position.y < -5) {
		Started = false;
	}

	if (Started == true) {
		Intro_Text.SetActive(false);
		Player.transform.Translate(Vector3.right * Speed * Time.deltaTime);
		The_Camera.velocity.x = Speed;
		Speed = Speed * 1.0001;
	}else {
		Intro_Text.SetActive(true);
		The_Camera.velocity.x = 0;
	}

	CurrentTime.text = "Time Survived: " + Time_Elapsed + " Seconds";
	if (Time_Elapsed > PlayerPrefs.GetInt("HighTime")) {
		PlayerPrefs.SetInt("HighTime", Time_Elapsed);
	}
	HighTime.text = "Longest Time: " + PlayerPrefs.GetInt("HighTime") + " Seconds";
}

function Creation () {
	while (Started == true) {
    	var Gap_Next : int = Random.Range(1, 10);
    	while (Gap_Next > 0) {
    		Floor_New = Instantiate(Floor_Prefab, new Vector3 (X, 0, 0),  Quaternion.identity);
    		Quantity++;
    		X++;
    		Gap_Next--;
    		if (Started == true) {
    			Destroy (Floor_New, 120);
    		}
    		Floor_New.name = "Floor #" + Quantity;
    		yield WaitForSeconds (.2); 
    	}
    	X = X + Random.Range(2, 4);
    }
}

function TimeAdder () {
	while (Started == true) {
		yield WaitForSeconds (1); 
		Time_Elapsed++;
	}
}