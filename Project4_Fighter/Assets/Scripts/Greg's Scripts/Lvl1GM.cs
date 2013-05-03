using UnityEngine;
using System.Collections;

// GameMaster for first scene
public class Lvl1GM : GameMaster {

	private GameObject newPowerUp;
	public float spawnRate = 5f;
	
	override public void Start () {
		base.Start();
		
		StartCoroutine(spawnPowerUps(getRandomPowerUp()));
	}
	
	// Spawns powerups in arena
	IEnumerator spawnPowerUps(GameObject powerUp) {
		newPowerUp = Instantiate(powerUp, new Vector3(Random.Range(-7, 7),Random.Range(0, 8), 0), Quaternion.identity) as GameObject;
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
