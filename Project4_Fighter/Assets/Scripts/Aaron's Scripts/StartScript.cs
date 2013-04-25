using UnityEngine;
using System.Collections;

public class StartScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI() {
		if (GUI.Button (new Rect(400,400,90,50), "Level 1")) {
			Application.LoadLevel (1);
		} else if (GUI.Button (new Rect(500,400,90,50), "Level 2")) {
			Application.LoadLevel (2);
		} else if (GUI.Button (new Rect(600,400,90,50), "Level 3")) {
			Application.LoadLevel (3);
		}
	}
}
