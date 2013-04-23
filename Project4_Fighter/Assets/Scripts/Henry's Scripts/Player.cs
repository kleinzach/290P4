using UnityEngine;
using System.Collections;

public abstract class Player : MonoBehaviour {
	
	public Direction currentDirection = Direction.Positive;
	public Direction currentVerticalInput = Direction.None;
	public Direction currentHorizontalInput = Direction.None;
	public bool jumpActivated = false;
	public bool punchActivated = false;
	protected bool punchReset = false;
	public bool kickActivated = false;
	protected bool kickReset = false;
	public bool blockActivated = false;
	protected bool blockReset = false;
	
	public Character controlledCharacter;
	
	// Use this for initialization
	void Start () {
		controlledCharacter = (Character)Instantiate(controlledCharacter,Vector3.zero,Quaternion.identity);
		controlledCharacter.controller = this;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		getInputs();
	}
	
	public abstract void getInputs();
}
