/*
Source file name : HeroController.cs
Author : Eunmi Han(300790610)
Date last Modified : Feb 29, 2016
Program Description : Control Hero moving and collision, paused panel and audio 
Revision History : 1.01 - Initial Setup
                   1.02 - Add control
                   1.03 - Add collision
                   1.04 - Add spwan
                   1.05 - Add paused panel
                   1.06 - Add sound
                   1.07 - Add animation
Last Modified by Eunmi Han
*/


using UnityEngine;
using System.Collections;


//Velocity Range Utility Class
[System.Serializable]
public class VelocityRange{
	// Public Instance Variables
	public float minimum;
	public float maximum;

	// Constructor
	public VelocityRange(float minimum, float maximum){
		this.maximum = maximum;
		this.minimum = minimum;
	}
}

public class HeroController : MonoBehaviour {
	//Public Instance Variables
	public VelocityRange velocityRange;
	public float moveForce;
	public float jumpForce;
	public Transform groundCheck;
	public Transform camera;
	public GameController gameController;
	public GameObject bulletForward;
	public GameObject bulletForwardPosition;
	public GameObject Explosion;

	// PRIVATE  INSTANCE VARIABLES
	private Animator _animator;
	private float _move;
	private float _jump;
	private bool _facingRight;
	private Transform _transform;
	private Rigidbody2D _rigidBody2d;
	private bool _isGrounded;
	private AudioSource[] _audioSources;
	private AudioSource _jumpSound;
	private AudioSource _lightSound;
	private AudioSource _bgm;
	private float _spawnX;
	private float _spawnY;


	// Use this for initialization
	void Start () {
		// Initialize Public Instance Variables
		this.velocityRange = new VelocityRange(300f, 25000f);

		//Initialize Private Instance Variables
		this._transform = gameObject.GetComponent<Transform> ();
		this._animator = gameObject.GetComponent<Animator> ();
		this._rigidBody2d = gameObject.GetComponent<Rigidbody2D> ();
		this._jump = 0f;
		this._move = 0f;
		this._spawnX = -310f;
		this._spawnY = 115f;
		this._facingRight = true;

		// Setup AudioSources
		this._audioSources = gameObject.GetComponents<AudioSource>();
		this._jumpSound = this._audioSources [0];
		this._lightSound = this._audioSources [1];
		this._bgm = this._audioSources [2];

		this._bgm.Play ();
		// place the hero in the starting position
		this._spawn ();
	}

	// Update is called once per frame
	void FixedUpdate () {

		Vector3 currentPosition = new Vector3 (this._transform.position.x, this._transform.position.y, -10f);
		if (currentPosition.x > -330 && currentPosition.y > -250 && currentPosition.y < 190) {
			this.camera.position = currentPosition;
		}
		this._isGrounded = Physics2D.Linecast (this._transform.position, 
			this.groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));
		Debug.DrawLine (this._transform.position, this.groundCheck.position);

		float forceX = 0f;
		float forceY = 0f;

		// get absolute value of velocity for our game object
		float absVelX = Mathf.Abs (this._rigidBody2d.velocity.x);
		float absVelY = Mathf.Abs (this._rigidBody2d.velocity.y);


		//Ensure the player is grounded before any movement checks
		if (this._isGrounded) {
			// gets a number between -1 to 1 for both Horizontal and Vertical axis
			this._move = Input.GetAxis ("Horizontal");
			this._jump = Input.GetAxis ("Vertical");


			if (this._move != 0) {
				if (this._move > 0) {
					//movement force
					if (absVelX < this.velocityRange.maximum) {
						forceX = this.moveForce;
					}
					this._facingRight = true;
					this._flip ();
				}
				if (this._move < 0) {
					//movement force
					if (absVelX < this.velocityRange.maximum) {
						forceX = -this.moveForce;
					}
					this._facingRight = false;
					this._flip ();
				}
				// call the walk clip
				this._animator.SetInteger ("AnimState", 1);
			} else {

				// set default animation state to "idle"
				this._animator.SetInteger ("AnimState", 0);
			}

			if (this._jump > 0) {
				//jump force
				if (absVelY < this.velocityRange.maximum) {
					this._jumpSound.Play ();
					forceY = this.jumpForce;
				}

			}
		} else {
			// call the "jump" clip
			this._animator.SetInteger ("AnimState", 2);
		}

		// Apply the forces to the player
		this._rigidBody2d.AddForce(new Vector2(forceX, forceY));

		//Fire bullets when the spacebar is pressed
		if (Input.GetKeyDown ("space")) {
			if (this.gameController.BulletValue > 0 && this._facingRight) {
				//Instantiate the first bullet
				GameObject _bullet = (GameObject)Instantiate (bulletForward);
				_bullet.transform.position = bulletForwardPosition.transform.position;
			}
		}

	}

	void OnCollisionEnter2D(Collision2D other){

		if(other.gameObject.CompareTag("Light")){
			this._lightSound.Play ();

			Destroy (other.gameObject);
			this.gameController.BulletValue++;
			this.gameController.ScoreValue += 20;
		}

		if(other.gameObject.CompareTag("Death")){
			
			this._spawn ();
			this.gameController.LivesValue--;
		}

		if(other.gameObject.CompareTag("End")){

			this.gameController.GameWin = true;
		}

		if(other.gameObject.CompareTag("Respawn")){

			this._spawnX = 950f;
			this._spawnY = 130f;
			this.gameController.RespwanAlarm ();
			//Destroy (other.gameObject);
		}


		if(other.gameObject.CompareTag("Zombie") || other.gameObject.CompareTag("Bat")){
			PlayExplosion ();
			Destroy (other.gameObject);
			this.gameController.LivesValue--;

		}

	}
	// PRIVATE METHODS
	private void _flip() {
		if (this._facingRight) {
			this._transform.localScale = new Vector2 (1, 1);
		} else {
			this._transform.localScale = new Vector2 (-1, 1);
		}
	}

	private void _spawn(){
		this._transform.position = new Vector3 (this._spawnX, this._spawnY, 0);
	}

	//To instantiate an explosion
	void PlayExplosion(){
		GameObject _explosion = (GameObject)Instantiate (Explosion);

		//set the position of the explosion
		_explosion.transform.position = transform.position;
	}

}