using UnityEngine;
using System.Collections;

public class DriveBy : MonoBehaviour {
	
	public float spawnRate = 1.5f;
	private FireBall[] fireballs;
	public GameObject fireballPrefab;
	public Vector3 strafe;
	
	// Use this for initialization
	void Start () {
		fireballs = new FireBall[10];
		StartCoroutine(emitDeath());
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(strafe);
	}
	
	IEnumerator emitDeath() {
		
		float tiltAngle = 360f / 8f;
        for (int i = 0; i < 8; i++) {
            transform.Rotate(Vector3.up * tiltAngle);
            GameObject shot = Instantiate(fireballPrefab, transform.position, transform.rotation) as GameObject;
        }
		yield return new WaitForSeconds(spawnRate);
		StartCoroutine(emitDeath());
	}
}
