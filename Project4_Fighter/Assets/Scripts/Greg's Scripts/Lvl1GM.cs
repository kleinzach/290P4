using UnityEngine;
using System.Collections;

public class Lvl1GM : GameMaster {

	private GameObject bomb, LEPowerUp;
	
	override public void Start () {
		base.Start();
		LEPowerUp = Instantiate(LEPUPrefab, new Vector3(0, 8, 0), Quaternion.identity) as GameObject;
		
	}
	
	/*
	// Update is called once per frame
	void FixedUpdate () {
	
	}
	
	void OnGUI() {
	
	}
	*/
	
}
