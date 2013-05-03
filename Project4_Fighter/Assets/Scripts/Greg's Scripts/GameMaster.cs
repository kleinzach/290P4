using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {	
	
	public float hp1, hp2;
    public Texture2D hpTex;
	public GameObject p1,p2;
	
	/* Prefabs instantiated by different GameMasters */
	public GameObject cometPrefab, bombPrefab, meteorPrefab, driveByPrefab; // Prefabs
	public GameObject LEPUPrefab, bombPUPrefab, increaseSpeedPUPrefab, healPrefab; // Power Up Prefabs
	
	private GameObject meteor, driveBy;

	public virtual void Start () {
		p1 = GameObject.Find("Player1").GetComponent<Player1>().controlledCharacter.gameObject;
		p2 = GameObject.Find("Player2").GetComponent<Player2>().controlledCharacter.gameObject;
 
	}
	
	/* Attempt at health bars */
	void OnGUI() {

		GUI.Box(new Rect(Screen.width/4, 10, hp1, 30), hpTex);
		GUI.Box (new Rect(Screen.width * 3/4, 10, hp2, 30), hpTex);
	
	}
	
	// Update HP
	public virtual void FixedUpdate () {
		if (p1 && p2) { // Temp hack until hp bars are fixed
			hp1 = p1.GetComponent<Character>().life;
			hp2 = p2.GetComponent<Character>().life;
		}
	}	
		
	// Puts a meteor with a random trajectory and position in the scene
	public void launchMeteor () {
		int i = Random.Range(-9,9);
		meteor = (GameObject) Instantiate(meteorPrefab, new Vector3(i, 10, 0), Quaternion.identity);
		meteor.AddComponent("Meteor");
		if (i > 0)
			meteor.GetComponent<Meteor>().meteorVector.x *= -1;
	}
	
	/*public void driveByShooting () {
		int startSide = Random.Range(0, 1);
		if (startSide == 0) {
			driveBy = (GameObject) Instantiate(driveByPrefab, new Vector3(-10, Random.Range(-1, 10), 0), Quaternion.identity);
			driveBy.GetComponent<DriveBy>().strafe = new Vector3(.05f, 0, 0);
		} else {
			driveBy = (GameObject) Instantiate(driveByPrefab, new Vector3(10, Random.Range(-1, 10), 0), Quaternion.identity);
			driveBy.GetComponent<DriveBy>().strafe = new Vector3(-.05f, 0, 0);
		}
	}*/
	
	
	// Makes platforms oscillate
	public void platformsOscillate(bool status) {
		OscillatePlatform[] oscPlatforms = FindObjectsOfType(typeof(OscillatePlatform)) as OscillatePlatform[];
        foreach (OscillatePlatform platform in oscPlatforms)
            platform.activated = status;
		
	}	
	
	
	
	

}
