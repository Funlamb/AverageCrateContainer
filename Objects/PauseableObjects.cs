using UnityEngine;
using System.Collections;

public class PauseableObjects : MonoBehaviour {
		public LevelManager _levelManager;
		public GameManager _gameManager;
		public bool isActive;
		// Use this for initialization
		protected void Start () {
				InitManagers ();
				InitActiveState ();
		}

		void OnPauseGame () {
				isActive = false;
				rigidbody2D.isKinematic = true;
		}
	
		void OnResumeGame () {
				isActive = true;
				rigidbody2D.isKinematic = false;
		}

	void InitManagers () {
		_levelManager = GameObject.FindGameObjectWithTag ("LevelOverlord").GetComponent<LevelManager> ();
		_gameManager = GameObject.FindGameObjectWithTag ("GameOverlord").GetComponent<GameManager> ();
	}

	void InitActiveState () {
		if (_levelManager.isPlaying == true) {
			isActive = true;
		}
		else {
			isActive = false;
		}
	}
}
