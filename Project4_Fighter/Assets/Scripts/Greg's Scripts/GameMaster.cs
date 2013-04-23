using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {
	
	public float gravityVal = 4.0F; 
	
	// Use this for initialization
	void Start () {
		Physics.gravity = new Vector3(0, -gravityVal, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
