using UnityEngine;
using System.Collections;

public class HealPowerUp : PowerUps {

	// Use this for initialization
	override public void Start () {
		
	}
	
	// Update is called once per frame
	override public void Update () {
	
	}
	
	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player") {
			base.heal(other.gameObject);
			Destroy(gameObject);
		}
	}
}
