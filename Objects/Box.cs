using UnityEngine;
using System.Collections;

public class Box : PauseableObjects {
		private int xRandomSmall;
		private int xRandomLarge;
		private int yRandomSmall;
		private int yRandomLarge;
		private bool moveTrue;
		private Transform groundCheck;
		private bool isThereGround;
		private AudioClip audioClip;
		private AudioSource audioSource;

		// Use this for initialization
		new void Start () {
				base.Start ();
				InitBoxesRandomSpawnRange ();
				InitGroundCheck ();
				InitAudio ();
		}
	
		// Update is called once per frame
		void Update () {
				Debug.DrawLine (transform.position, groundCheck.position);
				if (moveTrue) {
						MoveBox ();
						moveTrue = false;
				}
		}

		void MoveBox () {
				int x = Random.Range (xRandomSmall, xRandomLarge);
				int y = Random.Range (yRandomSmall, yRandomLarge);	
				transform.rigidbody2D.velocity = new Vector2 (0, 0);
				gameObject.transform.position = new Vector2 (x, y);
				isThereGround = Physics2D.OverlapCircle (groundCheck.position, 0.1f, 1 << LayerMask.NameToLayer ("Ground")); 
				if (isThereGround == false) {
						MoveBox ();
				} else {
						if (_gameManager._soundManager.playingSound) {
								audioSource.Play (); 
						}
						isThereGround = false;
						return;
				}
		}

		void OnTriggerEnter2D (Collider2D other) {
				if (other.tag == "Player") {
						other.gameObject.GetComponent<PlayerMovement> ().ChangeScore (1);//This is probably taking up a lot of resources. 
						MoveBox ();
				} else if (other.tag == "KillZone") {
						MoveBox ();
				}
		}

	void InitBoxesRandomSpawnRange () {
		xRandomSmall = -6;
		xRandomLarge = 6;
		yRandomSmall = -6;
		yRandomLarge = 6;
	}

	void InitGroundCheck () {
		groundCheck = transform.Find ("GroundCheck");
		isThereGround = false;
	}

	void InitAudio () {
		audioClip = (AudioClip)Resources.Load ("Sounds/Powerup13");
		audioSource = gameObject.GetComponent<AudioSource> ();
		audioSource.clip = audioClip;
	}
}
