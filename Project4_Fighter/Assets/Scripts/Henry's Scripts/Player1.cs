using UnityEngine;
using System.Collections;

public class Player1 : Player {

	// Use this for initialization
	void Start () {
		controlledCharacter = (Character)Instantiate(controlledCharacter,Vector3.zero,Quaternion.identity);
		controlledCharacter.controller = this;
		controlledCharacter.playerNumber = 1;
		controlledCharacter.gameObject.layer = 8;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		getInputs();
	}
	
	//Gets inputs specific to player one, and stores the results in the fields.
	public override void getInputs(){
		float verticalInput = Input.GetAxis("Vertical");
		float horizontalInput = Input.GetAxis("Horizontal");
		float jumpInput = Input.GetAxis("Jump");
		float punchInput = Input.GetAxis ("Punch");
		float kickInput = Input.GetAxis("Kick");
		float blockInput = Input.GetAxis("Block");
		
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

