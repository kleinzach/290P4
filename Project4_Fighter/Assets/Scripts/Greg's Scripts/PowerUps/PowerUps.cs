using UnityEngine;
using System.Collections;

public abstract class PowerUps : MonoBehaviour {
	protected GameObject gm;
	protected GameMaster gmScript;
	
	// Use this for initialization
	public abstract void Start();
	
	// Update is called once per frame
	public abstract void Update();
	
	protected void getRangedWeapon(GameObject player) {
		Debug.Log("Player given weapon");
		//player.SendMessage("equipWeapon");
	}
	
	protected void getBomb(GameObject player) {
		Debug.Log("Player given bomb");
		//player.SendMessage("giveBomb");	
	}
	
	protected void stageEffect() {
		
		gm = GameObject.Find("GameMaster");
		gmScript = gm.GetComponent<GameMaster>();
		int randomInt = Random.Range(0,2);
		switch(randomInt) {
			case 0:
				gmScript.SendMessage("launchMeteor");
				break;
			//case 2: 
			//	gmScript.SendMessage("driveByShooting");
			//	break;
			case 1:
				gmScript.SendMessage("platformsOscillate", true);
				StartCoroutine(turnOffEffect(8f));
				break;
		}
	}
	
	protected void heal(GameObject player) {
		player.GetComponent<Character>().life *= 1.1f;
	}
	
	protected void increaseSpeed(GameObject player) {
		player.GetComponent<Character>().moveSpeed *= 1.1f;
	}
	
	IEnumerator turnOffEffect (float lifespan) {
		yield return new WaitForSeconds(lifespan);
		gmScript.SendMessage("platformsOscillate", false);
	}
}
