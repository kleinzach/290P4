using UnityEngine;
using System.Collections;

public class Meteor : MonoBehaviour {

	private Vector3 meteorVector = new Vector3 (-1, -1, 0);
	public float speed = 1;
	public GameObject meteorExplosion;
	
	// Use this for initialization
	void Start () {
		
	}
	
	void Update () 
	{	
		transform.Translate(speed * meteorVector * Time.deltaTime);
		
	}

	void OnCollisionEnter (Collision other) {
		
		Destroy(other.collider.gameObject);
		Destroy(gameObject);
		GameObject explosion = (GameObject) Instantiate(meteorExplosion, this.transform.position, Quaternion.identity);
		
	}
}
