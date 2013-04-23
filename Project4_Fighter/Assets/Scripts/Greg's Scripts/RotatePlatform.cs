using UnityEngine;
using System.Collections;

public class RotatePlatform : MonoBehaviour {
	
	public float speed = 4F;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(speed * Vector3.forward * Time.deltaTime);
	}
}
