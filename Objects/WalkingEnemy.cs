using UnityEngine;
using System.Collections;

public class WalkingEnemy : PauseableObjects {
		public int health;
		public Animator anim;
		public float moveSpeed = 5;
		public Vector2 currVelocity;
		public bool moveRight = true;
		public Transform sprite;
		private AudioClip audioClip;
		private AudioSource audioSource;
		
		// Use this for initialization
		new void Start () {
				base.Start ();
				InitAudio ();
				InitAnimator ();
				InitHealth ();
				InitSprite ();
		}

		public void TakeDamage (int damage) {
				health -= damage;
				if (_gameManager._soundManager.playingSound) {
						audioSource.Play (); 
				}
				if (health <= 0) {
						Destroy (gameObject);
				}
		}

		void OnPauseGame () {
				anim.SetBool ("isPaused", true);
				isActive = false;
				rigidbody2D.isKinematic = true;
		}
	
		void OnResumeGame () {
				anim.SetBool ("isPaused", false);
				isActive = true;
				rigidbody2D.isKinematic = false;
		}

		// Update is called once per frame
		void FixedUpdate () {
				if (isActive) {
						if (moveRight) {
								currVelocity.x = moveSpeed;
						} else if (!moveRight) {
								currVelocity.x = -moveSpeed;
						}
						currVelocity.y = rigidbody2D.velocity.y;
						rigidbody2D.velocity = currVelocity;
				}
		}

		void OnCollisionEnter2D (Collision2D collision) {
				if (collision.gameObject.tag == "Wall") {	
						moveRight = !moveRight;
						Flip ();
				}
		}

		void OnTriggerEnter2D (Collider2D other) {	
				if (other.gameObject.tag == "KillZone") {
						Destroy (gameObject);
				}
		}

		public void Die () {
				Destroy (gameObject);
		}
	
		void Flip () {
				Vector3 theScale = sprite.localScale;
				theScale.x *= -1;
				sprite.localScale = theScale;
		}

	void InitAudio () {
		audioClip = (AudioClip)Resources.Load ("Sounds/Hit_Hurt5");
		audioSource = gameObject.GetComponent<AudioSource> ();
		audioSource.clip = audioClip;
		audioSource.volume = 0.1f;
	}

	void InitAnimator () {
		anim = GetComponentInChildren<Animator> ();
	}

	void InitHealth () {
		health = 2;
	}

	void InitSprite () {
		sprite = transform.Find ("Sprite");
	}
}
