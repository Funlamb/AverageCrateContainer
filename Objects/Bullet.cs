using UnityEngine;
using System.Collections;

public class Bullet : PauseableObjects {
		public float speed;
		public Vector2 currVolocity;
		public int damagePower;
		public AudioClip audioClip;
		public AudioSource audioSource;
		// Use this for initialization
		new void Start () {
				base.Start ();
				InitDamagePower ();
				InitAudio ();
		}
	
		// Update is called once per frame
		void FixedUpdate () {
				if (isActive) {
						currVolocity.x = speed;
						currVolocity.y = .6f;
						rigidbody2D.velocity = currVolocity;
				}
		}

		void OnCollisionEnter2D (Collision2D coll) {
				if (coll.gameObject.tag == "Wall" || coll.gameObject.tag == "Ground") {
						Destroy (gameObject);
				}
				if (coll.gameObject.tag == "Enemy") {
						coll.gameObject.GetComponent<WalkingEnemy> ().TakeDamage (damagePower);
						Destroy (gameObject);
				}

		}

		void InitDamagePower () {
				damagePower = 1;
		}

		void InitAudio () {
				audioClip = (AudioClip)Resources.Load ("Sounds/Laser_Shoot5");
				audioSource = gameObject.GetComponent<AudioSource> ();
				audioSource.clip = audioClip;
				if (_gameManager._soundManager.playingSound) {
						audioSource.Play (); 
				}
		}
}
