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
	
	public Attack punch;
	public Attack duckPunch;
	public Attack jumpPunch;
	
	public Attack kick;
	public Attack duckKick;
	public Attack jumpKick;
	
	public Attack block;
	
	public Attack currentAction;
	
	public int playerNumber = 1;
	
	void Start () {	
		
	}
	
	// Fixed Update is called once per physics frame
	void FixedUpdate () {
		downTime -= Time.fixedDeltaTime;
		move();
		if(downTime <= 0){
			performAction();
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
			if(onGround && !ducking){
				newAttack = (Attack)Instantiate(punch,transform.position,transform.rotation);
			}
			else if(onGround && ducking){
				newAttack = (Attack)Instantiate(duckPunch,transform.position,transform.rotation);
			}
			else{
				newAttack = (Attack)Instantiate(jumpPunch,transform.position,transform.rotation);
			}
		}
		if(controller.kickActivated){
			if(onGround && !ducking){
				newAttack = (Attack)Instantiate(kick,transform.position,transform.rotation);
			}
			else if(onGround && ducking){
				newAttack = (Attack)Instantiate(duckKick,transform.position,transform.rotation);
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
	
	public void damage(float damage, Vector3 force){
		this.life -= damage;
		this.rigidbody.AddForce(force);
		this.renderer.material.color = Color.red;
		if(this.life <= 0){
			Destroy(this.gameObject);	
		}
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
