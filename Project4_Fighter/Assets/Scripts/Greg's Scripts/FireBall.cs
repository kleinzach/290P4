using UnityEngine;
using System.Collections;

public class FireBall : MonoBehaviour {

	//public Vector3 fireballVector;

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
			transform.Translate(Vector3.forward * .05f, Space.Self);
		else 
			Destroy(gameObject);
		
	}
	
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player") {
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
	}
}
