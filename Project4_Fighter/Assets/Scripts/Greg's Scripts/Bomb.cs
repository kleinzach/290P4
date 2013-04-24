using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {
	
	public GameObject bombExplosion;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnCollisionEnter(Collision collision) {
		GameObject explode = (GameObject) Instantiate(bombExplosion, this.transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
