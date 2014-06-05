using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
		public int gameState;
		public bool controlsSchemeAB; // scheme
		public float timeGame;
		public float timeLevel;
		private float splashScreenDuration;
		public Object[] objects;
		private bool inSplashScreen;
		public MenuOverlord _menuOverlord;
		public SoundManager _soundManager;
		public TimePlayed _timePlayed;
	
		// Use this for initialization
		void Start () {
				DontDestroyOnLoad (transform.gameObject);
				InitSoundManager ();
				InitMenuManager ();
				InitTimeManager ();	
				splashScreenDuration = 5f;
				gameState = GameState.SPLASH_SCREEN;
				controlsSchemeAB = true;//I don't know how to change player controls yet. This never got put in the game.
		}

		void InitTimeManager () {
				_timePlayed = gameObject.GetComponent<TimePlayed> ();
		}

		void InitMenuManager () {
				_menuOverlord = GameObject.Find ("MainMenu").GetComponent<MenuOverlord> ();
		}

		void InitSoundManager () {
				_soundManager = gameObject.GetComponent<SoundManager> ();
		}

		public void ChangeGameState (int changeToState) {
				gameState = changeToState;
		}

		// Update is called once per frame
		void Update () {
				CheckInputs ();
				UpdateGame ();
		}

		private void UpdateGame () {
				switch (gameState) {
				case GameState.ACTIVE: 
						UpdateClock ();
						break;
				case GameState.PAUSED:
						break;
				case GameState.SPLASH_SCREEN:
						SplashScreen ();
						break;
				case GameState.INFO_FLASH:
						break;
				case GameState.MENU:
						break;
				}
		}

		public void SetGameState (int _gameState) {
				gameState = _gameState;
		}

		public int GetGameState () {
				return gameState;
		}

		private void UpdateClock () {
				timeGame += Time.deltaTime;
		}

		private void SplashScreen () {
				timeGame += Time.deltaTime;
				if (gameState == GameState.SPLASH_SCREEN && (timeGame >= splashScreenDuration || CheckSkipButton ())) {
						_menuOverlord.StartTheMenu ();
						gameState = GameState.MENU;
						Application.LoadLevel (PublicID.LEVEL_MAIN_MENU);
				}
		}

		private bool CheckSkipButton () {
				if (Input.GetKeyDown (KeyCode.JoystickButton7) || Input.GetKeyDown (KeyCode.Space)) {
						return true;	
				} else {
						return false;
				}
		}

		private void CheckInputs () {
				if (Input.GetKeyDown (KeyCode.JoystickButton7) || Input.GetKeyDown (KeyCode.P)) {
						if (gameState == GameState.PAUSED) {
						} else if (gameState == GameState.ACTIVE) {
						} else if (gameState == GameState.INFO_FLASH) {
						}
				}
		}

		public void SaveGameAndQuit () {
				Debug.Log ("Save the Game");// I don't know how to save games yet. 
		}
}