using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {
	
	public float gravityVal = 4.0F; 
	public GameObject cometPrefab;
	private GameObject comet = null;
	private int numComets;
	public int MAX_COMETS = 1;
	
	
	public float hp1, hp2;
    public Texture2D hpTex;
	private GameObject p1,p2;
	
	// Use this for initialization
	void Start () {
		Physics.gravity = new Vector3(0, -gravityVal, 0);
		p1 = GameObject.Find("Player1").GetComponent<Player1>().controlledCharacter.gameObject;
		p2 = GameObject.Find("Player2").GetComponent<Player2>().controlledCharacter.gameObject;
 
	}
	
	/* Attempt at health bars */
	void OnGUI() {

		GUI.Box(new Rect(Screen.width/4, 10, hp1, 30), hpTex);
		GUI.Box (new Rect(Screen.width * 3/4, 10, hp2, 30), hpTex);
	
	}
	
	void FixedUpdate () {
		if (comet == null && numComets < MAX_COMETS) {
			StartCoroutine (spawnDelay());
			numComets++;
		}
		if (p1 && p2) { // Temp hack until hp bars are fixed
			hp1 = p1.GetComponent<Character>().life;
			hp2 = p2.GetComponent<Character>().life;
		}
	}
	
	void spawnComet() {
		comet = (GameObject) Instantiate(cometPrefab, new Vector3(-17, Random.Range(-9, 9), 0), Quaternion.identity);
	}
	
	/* Delay for spawning objects (currently just a comet) */
	IEnumerator spawnDelay () {
		
		yield return new WaitForSeconds(1f);
		spawnComet(); 
		
	}
	
	void cometDestroyed () {
		numComets--;
	}
}
