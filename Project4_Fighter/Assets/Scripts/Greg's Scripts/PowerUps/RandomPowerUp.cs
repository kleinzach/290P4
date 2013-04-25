using UnityEngine;
using System.Collections;

public class RandomPowerUp : PowerUps {
	
	// Use this for initialization
	public override void Start () {
		
	}
	
	// Update is called once per frame
	public override void Update () {
		
	}
	
	void OnTriggerEnter(Collider other) {
		int randomInt = Random.Range(0, 4);
		if (other.tag == "Player") {
			switch(randomInt) {
				case 0:
					base.getRangedWeapon(other.gameObject);
					break;
				case 1: 
					base.getBomb(other.gameObject);
					break;
				case 2:
					base.stageEffect();
					break;
				case 3:
					base.heal(other.gameObject);
					break;
				case 4:
					base.increaseSpeed(other.gameObject);
					break;
			}
			Destroy(gameObject);
		}
	}
	
}
