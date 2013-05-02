using UnityEngine;
using System.Collections;

public class Player2 : Player {
	
	// Use this for initialization
	void Start () {
		controlledCharacter = (Character)Instantiate(controlledCharacter,Vector3.zero,Quaternion.identity);
		controlledCharacter.controller = this;
		controlledCharacter.playerNumber = 2;
		controlledCharacter.gameObject.layer = 11;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		getInputs();
	}
	
	//Get inputs specific to player 2, storing the values.
	public override void getInputs(){
		float verticalInput = Input.GetAxis("Vertical2");
		float horizontalInput = Input.GetAxis("Horizontal2");
		float jumpInput = Input.GetAxis("Jump2");
		float punchInput = Input.GetAxis ("Punch2");
		float kickInput = Input.GetAxis("Kick2");
		float blockInput = Input.GetAxis("Block2");
		
		if(verticalInput > .5){
			currentVerticalInput = Direction.Positive;
		}
		else if(verticalInput < -.5){
			currentVerticalInput = Direction.Negative;
		}
		else{
			currentVerticalInput = Direction.None;	
		}
		
		if(horizontalInput > .5){
			currentHorizontalInput = Direction.Positive;
		}
		else if(horizontalInput < -.5){
			currentHorizontalInput = Direction.Negative;	
		}
		else{
			currentHorizontalInput = Direction.None;
		}
		
		jumpActivated = jumpInput > .5;
		if(punchInput > .5){
			punchActivated = punchReset;
			punchReset = false;
		}
		else{
			punchReset = true;	
		}
		if(kickInput > .5){
			kickActivated = kickReset;
			kickReset = false;
		}
		else{
			kickReset = true;	
		}
		if(blockInput > .5){
			blockActivated = blockReset;
			blockReset = false;
		}
		else{
			blockReset = true;	
		}
	}
}

