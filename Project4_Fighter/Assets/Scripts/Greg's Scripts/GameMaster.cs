using UnityEngine;
using System.Collections;

public abstract class GameMaster : MonoBehaviour {
	
	
	protected float hp1, hp2;
    protected Texture2D hpTex;
	protected GameObject p1,p2;
	
	// Use this for initialization
	public virtual void Start () {
		p1 = GameObject.Find("Player1").GetComponent<Player1>().controlledCharacter.gameObject;
		p2 = GameObject.Find("Player2").GetComponent<Player2>().controlledCharacter.gameObject;
 
	}
	
	/* Attempt at health bars */
	public virtual void OnGUI() {

		GUI.Box(new Rect(Screen.width/4, 10, hp1, 30), hpTex);
		GUI.Box (new Rect(Screen.width * 3/4, 10, hp2, 30), hpTex);
	
	}
	
	public virtual void FixedUpdate () {
		if (p1 && p2) { // Temp hack until hp bars are fixed
			hp1 = p1.GetComponent<Character>().life;
			hp2 = p2.GetComponent<Character>().life;
		}
	}	
	
	public virtual void launchMeteor () {
		
	}
	
	public virtual void driveByShooting () {
	
	}
	
	public virtual void platformsOscillate() {
		OscillatePlatform[] oscPlatforms = FindObjectsOfType(typeof(OscillatePlatform)) as OscillatePlatform[];
        foreach (OscillatePlatform platform in oscPlatforms)
            platform.activated = true;
	}	
	
}
