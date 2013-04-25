using UnityEngine;
using System.Collections;

public class StartScript : MonoBehaviour {
	
	static string message;
	static bool displayMessage = false;
	
	public static void setMessage(string msg) {
		message = msg;
		displayMessage = true;
	}
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI() {
		if (displayMessage) {
			GUI.Label (new Rect(500, 200, 100, 50), message);
		}
		if (GUI.Button (new Rect(400,400,90,50), "Level 1")) {
			Application.LoadLevel (1);
			displayMessage = false;
		} else if (GUI.Button (new Rect(500,400,90,50), "Level 2")) {
			Application.LoadLevel (2);
			displayMessage = false;
		} else if (GUI.Button (new Rect(600,400,90,50), "Level 3")) {
			Application.LoadLevel (3);
			displayMessage = false;
		}
	}
}
