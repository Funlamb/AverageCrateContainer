using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
		public bool shootingRight;
		public PlayerMovement _playerMovement;
		public GameObject _gun;
		public GameObject _bullet;


		// Use this for initialization
		void Start () {
				shootingRight = true;
				_gun = GameObject.Find ("Gun");
				_playerMovement = GetComponent<PlayerMovement> ();
				_bullet = (GameObject)Resources.Load ("Prefabs/Bullet", typeof(GameObject));
		}

		public void Flip () {
				shootingRight = !shootingRight;
		}

		public void shoot () {
				//Make the bullet here.
				GameObject go = (GameObject)Instantiate (_bullet, _gun.transform.position, Quaternion.identity);
				Bullet comp = go.GetComponent<Bullet> ();
				if (shootingRight) {
						comp.speed *= 1;
				} else if (!shootingRight) {
						comp.speed *= -1;
				}
				comp.currVolocity.x = 1;
		}
	
		// Update is called once per frame
		void Update () {
	
		}

}
