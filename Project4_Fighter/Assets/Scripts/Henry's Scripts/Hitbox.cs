using UnityEngine;
using System.Collections;

public class Hitbox : MonoBehaviour {
	
	public Attack a;
	
	public bool defensive = false;
	
	public float damage = 1f;
	
	public float stunTime = 0f;
	

	// Use this for initialization
	void Start () {
		this.gameObject.AddComponent<Rigidbody>();
		this.rigidbody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
		this.rigidbody.isKinematic = true;
		this.rigidbody.mass = .000000001f;
	}
	
	
	// Fixed Update is called once per physics frame
	void FixedUpdate () {
	
	}
	
	void OnCollisionStay(Collision other){
		Debug.Log("a hit");
		if(defensive){
			Destroy(other.gameObject);	
		}
		else if(other.gameObject.layer == 8 || other.gameObject.layer == 11){
			(other.gameObject.GetComponent<Character>()).damage(damage,a.force,stunTime);
		}
		if(a.breaks){
			Destroy(this.gameObject);
		}
	}
}
