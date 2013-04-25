using UnityEngine;
using System.Collections;

public class Meteor : MonoBehaviour {

	public Vector3 meteorVector = new Vector3 (-1, -1, 0);
	public float speed = 1;
	public GameObject meteorExplosion;
	private GameObject explosion;
	
	// Use this for initialization
	void Start () {
		
	}
	
	void Update () 
	{	
		transform.Translate(speed * meteorVector * Time.deltaTime);
		
	}

	void OnCollisionEnter (Collision other) {
		
		if (meteorExplosion != null)
			explosion = Instantiate(meteorExplosion, this.transform.position, Quaternion.identity) as GameObject;
		
		Destroy(other.collider.gameObject);
		Destroy(gameObject);
		
		
	}
}
