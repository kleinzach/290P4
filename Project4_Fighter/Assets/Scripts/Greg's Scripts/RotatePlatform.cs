using UnityEngine;
using System.Collections;

public class RotatePlatform : MonoBehaviour {
	
	public float speed = 4F;
	public bool direction;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Rotates platform
	void Update () {
		if (direction)
			transform.Rotate(speed * Vector3.forward * Time.deltaTime);
		else
			transform.Rotate(speed * Vector3.forward * Time.deltaTime * -1);
	}
}
