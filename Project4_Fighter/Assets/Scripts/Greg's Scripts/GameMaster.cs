using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {	
	
	public float hp1, hp2;
    public Texture2D hpTex;
	public GameObject p1,p2;
	
	/* Prefabs instantiated by different GameMasters */
	public GameObject cometPrefab, bombPrefab, meteorPrefab, LEPUPrefab;
	
	private GameObject meteor;

	public virtual void Start () {
		p1 = GameObject.Find("Player1").GetComponent<Player1>().controlledCharacter.gameObject;
		p2 = GameObject.Find("Player2").GetComponent<Player2>().controlledCharacter.gameObject;
 
	}
	
	/* Attempt at health bars */
	void OnGUI() {

		GUI.Box(new Rect(Screen.width/4, 10, hp1, 30), hpTex);
		GUI.Box (new Rect(Screen.width * 3/4, 10, hp2, 30), hpTex);
	
	}
	
	public virtual void FixedUpdate () {
		if (p1 && p2) { // Temp hack until hp bars are fixed
			hp1 = p1.GetComponent<Character>().life;
			hp2 = p2.GetComponent<Character>().life;
		}
	}	
	
	public virtual GameObject getLEPU() {
		return LEPUPrefab;	
	}
	
	public void launchMeteor () {
		meteor = (GameObject) Instantiate(meteorPrefab, new Vector3(8, 10, 0), Quaternion.identity);
	}
	
	public void driveByShooting () {
	
	}
	
	public void platformsOscillate() {
		OscillatePlatform[] oscPlatforms = FindObjectsOfType(typeof(OscillatePlatform)) as OscillatePlatform[];
        foreach (OscillatePlatform platform in oscPlatforms)
            platform.activated = true;
	}	
	
	

}
