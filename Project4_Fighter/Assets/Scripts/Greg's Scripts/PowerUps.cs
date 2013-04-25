using UnityEngine;
using System.Collections;

public abstract class PowerUps : MonoBehaviour {
	private GameObject gm;
	private GameMaster gmScript;
	
	// Use this for initialization
	public abstract void Start();
	
	// Update is called once per frame
	public abstract void Update();
	
	protected void getRangedWeapon(GameObject player) {
		player.SendMessage("equipWeapon");
	}
	
	protected void getBomb(GameObject player) {
		player.SendMessage("giveBomb");	
	}
	
	protected void stageEffect() {
		
		gm = GameObject.Find("GameMaster");
		gmScript = gm.GetComponent<GameMaster>();
		int randomInt = Random.Range(0,2);
		randomInt = 0; // launchMeteor and driveByShooting are not finished
		switch(randomInt) {
			case 0:
				gmScript.SendMessage("launchMeteor");
				break;
			case 1: 
				gmScript.SendMessage("driveByShooting");
				break;
			case 2:
				gmScript.SendMessage("platformsOscillate");
				break;
		}
	}
	
	protected void heal() {
	
	}
	
	protected void increaseSpeed() {
	
	}
}
