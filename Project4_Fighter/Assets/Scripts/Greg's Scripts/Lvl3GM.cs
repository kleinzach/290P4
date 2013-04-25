using UnityEngine;
using System.Collections;

public class Lvl3GM : GameMaster {

	private GameObject newPowerUp;
	public float spawnRate = 5f;
	
	override public void Start () {
		base.Start();
		
		StartCoroutine(spawnPowerUps(getRandomPowerUp()));
	}
	
	IEnumerator spawnPowerUps(GameObject powerUp) {
		newPowerUp = Instantiate(powerUp, new Vector3(Random.Range(-7, 7),Random.Range(-2, 8), 0), Quaternion.identity) as GameObject;
		yield return new WaitForSeconds(spawnRate);
		StartCoroutine(spawnPowerUps(getRandomPowerUp()));
	}
	
	GameObject getRandomPowerUp() {
		int randomInt = Random.Range(0,4);
		switch(randomInt) {
			case 0:
				return LEPUPrefab; // Random Power Up
				break;
			case 1: 
				return bombPUPrefab; // Bomb Power Up 
				break;
			case 2:
				return healPrefab; // Heal Power Up
				break;
			case 3:
				return increaseSpeedPUPrefab; // Increase Speed 
				break;
		}
		return null;
	}
}
