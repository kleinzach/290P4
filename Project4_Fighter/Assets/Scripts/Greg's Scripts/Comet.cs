using UnityEngine;
using System.Collections;

public class Comet : MonoBehaviour {
	
	public Vector3 cometVector;

    private Camera cam;
    private Plane[] planes;
	public GameObject cometExplosion;
	
	// Use this for initialization
	void Start () {
		
		cam = Camera.main;
        planes = GeometryUtility.CalculateFrustumPlanes(cam);
		
	}
	
	void FixedUpdate () 
	{
		if (GeometryUtility.TestPlanesAABB(planes, this.collider.bounds))
			transform.Translate(cometVector);
		else 
			Destroy(gameObject);
		
	}

	void OnDestroy() {
		GameObject.Find("GameMaster").SendMessage("cometDestroyed");
	}
	
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player") {
			Destroy(other.gameObject);
			Destroy(gameObject);
			GameObject explosion = (GameObject) Instantiate(cometExplosion, this.transform.position, Quaternion.identity);
		}
	}
}
