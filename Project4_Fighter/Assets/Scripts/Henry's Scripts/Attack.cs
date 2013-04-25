using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {
	public Character m_character;
	
	public Vector3 hitboxInitialPosition = new Vector3(1,0,0);
	public Vector3 hitboxSize = new Vector3(1,1,1);
	public float hitboxRotation = 0;
	
	public bool breaks = true;
	
	public Vector3 hitboxVelocity = new Vector3(0,0,0);
	private float currentLife = 0;
	public float hitboxLifetime = 1;
	
	public Vector3 force = new Vector3(0,0,0);
	public float stunTime = 0;
	
	public float downTime = .5f;
	
	public bool parented = false;
	public bool usesGravity = false;
	public Vector3 gravityForce = new Vector3(0,-1,0);
	
	public float minimumComboTime = 0f;
	public float maximumComboTime = 1f;
	public Action comboAction;
	public Direction comboHorizontal;
	public Direction comboVertical;
	public Attack comboMove;
	private bool comboable = true;
	
	public float damage = 1;
	
	public Vector3 playerForce = new Vector3(0,0,0);
	
	public bool defensive = false;
	
	private GameObject hitbox;
	
	private bool alive = true;
	
	public int playerNumber = 1;
	
	// Use this for initialization
	void Start () {
		
	}
	
	public void reset(){
		if(m_character != null){
			Destroy(this.hitbox.gameObject);
			hitbox = GameObject.CreatePrimitive(PrimitiveType.Cube);
			hitbox.AddComponent<Rigidbody>();
			hitbox.rigidbody.useGravity = false;
			if(parented){
				this.hitbox.transform.parent = this.transform;
			}
			
			if(hitbox.GetComponent<Hitbox>() == null)
				hitbox.AddComponent<Hitbox>();
			hitbox.GetComponent<Hitbox>().damage = damage;
			hitbox.GetComponent<Hitbox>().defensive = defensive;
			hitbox.GetComponent<Hitbox>().stunTime = stunTime;
			hitbox.transform.localScale = hitboxSize;
			hitbox.transform.position = hitboxInitialPosition + m_character.transform.position;
			hitbox.transform.rotation = new Quaternion(0,0,hitboxRotation,0);
			hitbox.gameObject.layer = m_character.playerNumber == 1? 9:12;
			if(defensive){
				hitbox.gameObject.layer += 1;	
			}
			hitbox.GetComponent<Hitbox>().a = this;
			comboable = true;
		}
	}
	
	// Fixed Update is called once per physics frame.
	void FixedUpdate () {
		currentLife += Time.fixedDeltaTime;
		if(m_character != null){
			if(comboable){
				executeCombo();
			}
			m_character.rigidbody.AddForce(playerForce);
		}
		if(currentLife >= hitboxLifetime){
			this.alive = false;
		}
		if(hitbox != null){
			hitbox.transform.localPosition += hitboxVelocity * Time.fixedDeltaTime;
			if(usesGravity){
				hitbox.transform.position -= gravityForce;
			}
			
		}
		if(!this.alive){
			Kill();
		}
	}
	
	void executeCombo(){
		Attack comboAttack = null;
		Player p = m_character.controller;
		bool comboDirectionReady = (comboHorizontal == p.currentHorizontalInput) && (comboVertical == p.currentVerticalInput);
		if(currentLife < maximumComboTime && currentLife > minimumComboTime && comboDirectionReady){
			switch(comboAction){
			case Action.Punch:
				if(p.punchActivated){
					comboAttack = this.comboMove;
				}
				break;
			case Action.Kick:
				if(p.kickActivated){
					comboAttack = this.comboMove;
				}
				break;
			case Action.Block:
				if(p.blockActivated){
					comboAttack = this.comboMove;
				}
				break;
			case Action.Jump:
				if(p.jumpActivated){
					comboAttack = this.comboMove;
				}
				break;
				
			}
			if(comboAttack != null){
				m_character.activateAttack((Attack)Instantiate(comboAttack,m_character.transform.position,m_character.transform.rotation));
				comboable = false;
			}
		}	
	}
	
	public void Kill(){
		Destroy(hitbox.gameObject);
		this.hitbox = null;
		Destroy(this.gameObject);
	}
	
	public void Hit(Character c){
		c.damage(this.damage, force, stunTime);
		c.rigidbody.AddForce(this.force);
	}
}
