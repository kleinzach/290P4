using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	
	public Player controller;
	
	public float moveSpeed = 1;
	
	public float life = 10;
	
	public float jumpForce = 5;
	public float maxJumpTime = 1;
	
	private float downTime = 0;
	private float jumpTime = 0;
	private bool onGround = true;
	private bool ducking = false;
	private bool lookingUp = false;
	
	public Attack punch;
	public Attack upPunch;
	public Attack duckPunch;
	public Attack jumpPunch;
	
	public Attack kick;
	public Attack upKick;
	public Attack duckKick;
	public Attack jumpKick;
	
	public Attack block;
	
	public Attack currentAction;
	
	public int playerNumber = 1;
	
	private float stunned = 0;
	private float hurt = 0;
	
	void Start () {	
	}
	
	// Fixed Update is called once per physics frame
	void FixedUpdate () {
		downTime -= Time.fixedDeltaTime;
		if(stunned >= 0){
			stunned -= Time.fixedDeltaTime;
			return;
		}
		move();
		if(downTime <= 0){
			performAction();
		}
		if(hurt >= 0){
			this.renderer.material.color = Color.red;
			hurt -= Time.fixedDeltaTime;
		}
		else{
			this.renderer.material.color = Color.white;	
		}
		var screenpos = Camera.main.WorldToViewportPoint(this.transform.position);
		if (screenpos.x < 0 || screenpos.x > 1 || screenpos.y < 0) {
			Destroy (gameObject);
		}
		
	}
	
	/// <summary>
	/// Move this Character.
	/// </summary>
	void move(){
		
		Vector3 moveDirection = Vector3.zero;
		if(controller.currentHorizontalInput == Direction.Positive){
			moveDirection.x += 1;
			controller.currentDirection = Direction.Positive;
		}
		else if(controller.currentHorizontalInput == Direction.Negative){
			moveDirection.x -= 1;
			controller.currentDirection = Direction.Negative;
		}
		else{
			moveDirection.x = 0;	
		}
		this.ducking = onGround && (controller.currentVerticalInput == Direction.Negative);
		this.lookingUp = onGround && (controller.currentVerticalInput == Direction.Positive);
		this.transform.position  += moveDirection * moveSpeed * Time.fixedDeltaTime;
	}
	
	/// <summary>
	/// Performs actions based on the.
	/// </summary>
	void performAction(){
		if(controller.jumpActivated && jumpTime < maxJumpTime){
			jumpTime += Time.fixedDeltaTime;
			this.rigidbody.AddForce(new Vector3(0,jumpForce,0));
		}
		else {
			if(onGround){
				jumpTime = 0;
			}
			else{
				jumpTime += Time.fixedDeltaTime;	
			}
		}
		
		Attack newAttack = null;
		
		if(controller.punchActivated){
			if(onGround && !ducking && !lookingUp){
				newAttack = (Attack)Instantiate(punch,transform.position,transform.rotation);
			}
			else if(onGround && ducking){
				newAttack = (Attack)Instantiate(duckPunch,transform.position,transform.rotation);
			}
			else if(onGround && lookingUp){
				newAttack = (Attack)Instantiate(upPunch,transform.position,transform.rotation);
			}
			else{
				newAttack = (Attack)Instantiate(jumpPunch,transform.position,transform.rotation);
			}
		}
		if(controller.kickActivated){
			if(onGround && !ducking && !lookingUp){
				newAttack = (Attack)Instantiate(kick,transform.position,transform.rotation);
			}
			else if(onGround && ducking){
				newAttack = (Attack)Instantiate(duckKick,transform.position,transform.rotation);
			}
			else if(onGround && lookingUp){
				newAttack = (Attack)Instantiate(upKick,transform.position,transform.rotation);
			}
			else{
				newAttack = (Attack)Instantiate(jumpKick,transform.position,transform.rotation);
			}
		}
		if(controller.blockActivated){
			newAttack = (Attack)Instantiate(block,transform.position,transform.rotation);
		}
		
		if(newAttack != null){
			activateAttack(newAttack);
		}
	}
	
	public void damage(float damage, Vector3 force, float stunTime){
		this.life -= damage;
		this.rigidbody.AddForce(force);
		this.hurt = .25f;
		this.renderer.material.color = Color.red;
		this.stunned = stunTime;
		if(this.life <= 0){
			Destroy (this.gameObject);
		}
	}
	
	void OnDestroy() {
		Application.LoadLevel (0);
		StartScript.setMessage("Player " + playerNumber.ToString() + " has fainted!");
	}
	
	
	public void activateAttack(Attack a){
		this.currentAction = (Attack)Instantiate(a,this.transform.position,this.transform.rotation);
		if(this.controller.currentDirection == Direction.Negative){
			currentAction.hitboxInitialPosition.x *= -1;
			currentAction.hitboxVelocity.x *= -1;
			currentAction.playerForce.x *= -1;
			currentAction.force.x *= -1;
		}
		this.currentAction.gameObject.layer = this.gameObject.layer;
		this.downTime = a.downTime;
		this.currentAction.m_character = this;
		this.currentAction.reset();
		this.currentAction.playerNumber = this.playerNumber;
		
	}
	
	/// <summary>
	/// Raises the collision stay event.
	/// </summary>
	/// <param name='other'>
	/// Other.
	/// </param>
	void OnCollisionStay(Collision other){
		if(other.gameObject.transform.position.y < this.transform.position.y){
			this.onGround = true;
		}
	}
	/// <summary>
	/// Raises the collision exit event.
	/// </summary>
	/// <param name='other'>
	/// Other.
	/// </param>
	void OnCollisionExit(Collision other){
		this.onGround = false;	
	}
}
