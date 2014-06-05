using UnityEngine;
using System.Collections;
using System;

public class PlayerMovement : PauseableObjects {
	#region Movement Primitives
		public Animator anim;
		public XBoxController xBoxController;
		public Weapon _weapon;
		public Vector2 currVolocity = new Vector2 (0.0f, 0.0f);
		public float terminalVelocity = 4.0f;
		public float moveSpeed = 400.0f;
		private float inputX = 0.0f;
	#endregion
	#region Jumping Primitives
		public float jumpStrength = 4.0f;
		public float jumpTime = 52.0f;
		public float jumpTimeOriginal;
		public bool isJumping = false;
		public bool isGrounded = false;
		public bool didJumprelease = false;
		public Transform groundCheckTwo;
		public Transform groundCheckOne;
		public bool didHitHead = false;
		public Transform headCheck;
	#endregion
	#region animation
		public bool isFacingRight = true;
		public Transform sprite;
	#endregion
		public int points;

		public new void Start () {
				InitAnimator ();
				base.Start ();
				InitController ();
				InitWeapon ();
				InitCollisionDetectors ();
				InitSprite ();
				InitJumpTime ();
		}

		void InitAnimator () {
				anim = GetComponentInChildren<Animator> ();
		}

		void InitController () {
				xBoxController = GetComponent<XBoxController> ();
		}

		void InitWeapon () {
				_weapon = GetComponent<Weapon> ();
		}

		void InitCollisionDetectors () {
				groundCheckTwo = transform.Find ("groundCheckTwo");
				groundCheckOne = transform.Find ("groundCheckOne");
				headCheck = transform.Find ("headCheck");
		}

		void InitSprite () {
				sprite = transform.Find ("Sprite");
		}

		void InitJumpTime () {
				jumpTimeOriginal = jumpTime;
		}

		// Update is called once per frame
		void Update () {
				if (isActive) {
						Debug.DrawLine (groundCheckTwo.position, groundCheckOne.position, Color.red);
						isGrounded = Physics2D.Linecast (groundCheckOne.position, groundCheckTwo.position, 1 << LayerMask.NameToLayer ("Ground"));  
						didHitHead = Physics2D.Linecast (transform.position, headCheck.position, 1 << LayerMask.NameToLayer ("Ground")); 
						HandleJumping ();
				}
		}

		void HandleJumping () {
				if (jumpTime <= 0) {
						currVolocity.y = -currVolocity.y;
				}

				if ((Input.GetKeyDown (KeyCode.JoystickButton0) || Input.GetKeyDown (KeyCode.UpArrow)) && isGrounded) {
						isJumping = true;
				}
				if ((Input.GetKeyUp (KeyCode.JoystickButton0) || Input.GetKeyUp (KeyCode.UpArrow) || didHitHead) && isJumping) {
						didJumprelease = true;
						isJumping = false;
						didHitHead = false;
				}
				HandleXMovement ();
		}

		void FixedUpdate () {
				if (isActive) {		
						currVolocity = rigidbody2D.velocity;
						HandleJumpTakeOff ();
						HandleJumpFall ();
						HandleJumpReset ();
						HandleButtonInputs ();
						if (inputX > 0 && !isFacingRight) {
								Flip ();
						} else if (inputX < 0 && isFacingRight) {
								Flip ();
						}
						currVolocity.x = inputX * moveSpeed;
						TeminalVelocity ();
						rigidbody2D.velocity = currVolocity;
				}
				xBoxController.ClearInputs ();
		}

		void OnTriggerEnter2D (Collider2D coll) {
				if (coll.tag == "KillZone") {
						Application.LoadLevel (PublicID.FIRST_LEVEL);
				}
		}

		void OnCollisionEnter2D (Collision2D coll) {
				if (coll.gameObject.tag == "Enemy") {
						Application.LoadLevel (PublicID.FIRST_LEVEL);
				}
				if (coll.gameObject.tag == "Box") {
						points ++;
				}
		}

		public void ChangeScore (int pointsToAdd) {
				points += pointsToAdd;
				_levelManager.AddToScore ();
		}

		void Flip () {
				isFacingRight = !isFacingRight;
				Vector3 theScale = sprite.localScale;
				theScale.x *= -1;
				sprite.localScale = theScale;
				_weapon.Flip ();
		}

		void HandleJumpReset () {
				if (isGrounded && jumpTime != jumpTimeOriginal) {
						jumpTime = jumpTimeOriginal;
				}
		}

		void HandleJumpFall () {
				if (didJumprelease) {
						currVolocity.y = 0.0f;
						didJumprelease = false;
				}
		}

		void HandleJumpTakeOff () {
				if (isJumping && jumpTime > 0) {
						jumpTime--;
						currVolocity.y = jumpStrength;
				}
				if (jumpTime == 0) {
						isJumping = false;
				}
		}

		void HandleXMovement () {
				if (Mathf.Abs (Input.GetAxis ("Horizontal")) >= 0.1f) {
						anim.SetBool ("isWalking", true);
						inputX = Input.GetAxis ("Horizontal");
				} else {
						anim.SetBool ("isWalking", false);
						inputX = 0.0f;
				}
		}

		void HandleButtonInputs () {
				if (xBoxController.GetButton0 ()) {
				}
				if (xBoxController.GetButton1 ()) {

				}
				if (xBoxController.GetButton5 () || Input.GetKeyDown (KeyCode.Space)) {
						if (isActive) {			
								_weapon.shoot ();
						}
				}
		}

		void TeminalVelocity () {
				if (currVolocity.y <= -terminalVelocity) {
						currVolocity.y = -terminalVelocity;
				}
				if (currVolocity.y >= jumpStrength) {
						currVolocity.y = jumpStrength;
				}
		}

		public bool GetIsActive () {
				return isActive;
		}
	
		void OnPauseGame () {
				xBoxController.isActive = false;
				anim.SetBool ("isPaused", true);
				isActive = false;
				rigidbody2D.isKinematic = true;
		}
	
		void OnResumeGame () {
				xBoxController.isActive = true;
				anim.SetBool ("isPaused", false);
				isActive = true;
				rigidbody2D.isKinematic = false;
		}
	
}