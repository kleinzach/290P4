using UnityEngine;
using System.Collections;

public class Barrier : MonoBehaviour {
	
	public float bounceFactor;
	public bool horizontal;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter (Collision collider) {
		if (horizontal)
			collider.rigidbody.AddForce(new Vector3(0, bounceFactor, 0));
		else
			collider.rigidbody.AddForce(new Vector3(bounceFactor, 0, 0));
	}
}
