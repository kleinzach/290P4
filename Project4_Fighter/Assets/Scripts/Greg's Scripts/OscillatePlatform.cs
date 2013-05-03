using UnityEngine;
using System.Collections;

public class OscillatePlatform : MonoBehaviour {
	
	public bool goRight;
	public float speed; 
	public bool activated;
	
	void Start () {
		StartCoroutine(changeDirection());
	}
	
	// Update is called once per frame
	void Update () {
		if (activated)
			movePlatform();
		
	}
	
	// Changes direction after a few seconds
	IEnumerator changeDirection () {
		yield return new WaitForSeconds(3);	
		goRight = !goRight;
		StartCoroutine(changeDirection());
	}
	
	// Moves the platform left and right
	void movePlatform() {
		if (goRight)
			this.transform.Translate(speed * Vector3.right * Time.deltaTime);
		else
			this.transform.Translate(speed * Vector3.left * Time.deltaTime);
	}
	
	public void activate() {
		activated = true;	
	}
	
	public void deactivate() {
		activated = false;	
	}
}
