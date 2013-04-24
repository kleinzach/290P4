using UnityEngine;
using System.Collections;

public class Lvl2GM : GameMaster {
	
	public float gravityVal = 4.0F; 
	public GameObject cometPrefab;
	private GameObject comet = null;
	private int numComets;
	public int MAX_COMETS = 1;
	
	
	// Use this for initialization
	override public void Start () {
		base.Start();
		Physics.gravity = new Vector3(0, -gravityVal, 0);
		
	}
	
	// Update is called once per frame
	override public void FixedUpdate () {
		base.FixedUpdate();
		if (comet == null && numComets < MAX_COMETS) {
			StartCoroutine (spawnDelay());
			numComets++;
		}
	}
	
	override public void OnGUI () {
		base.OnGUI();	
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
