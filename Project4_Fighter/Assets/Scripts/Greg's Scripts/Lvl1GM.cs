using UnityEngine;
using System.Collections;

public class Lvl1GM : GameMaster {

	public GameObject bombPrefab, LEPowerUpPrefab;
	private GameObject bomb, LEPowerUp;
	
	override public void Start () {
		base.Start();
		LEPowerUp = (GameObject) Instantiate(LEPowerUpPrefab, new Vector3(0, 8, 0), Quaternion.identity);
	}
	
	/*
	// Update is called once per frame
	void FixedUpdate () {
	
	}
	
	void OnGUI() {
	
	}
	*/
	
}
