using UnityEngine;
using System.Collections;

public class IncreaseSpeedPowerUp : PowerUps {

	// Use this for initialization
	override public void Start () {
		
	}
	
	// Update is called once per frame
	override public void Update () {
	
	}
	
	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player") {
			base.increaseSpeed(other.gameObject);
			Destroy(gameObject);
		}
	}
}
