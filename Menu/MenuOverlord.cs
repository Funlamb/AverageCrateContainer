using UnityEngine;
using System.Collections;

public class MenuOverlord : MonoBehaviour {
		/// <summary>
		/// This is class will hold on the funtions of our menu. Anything from selecting
		/// buttons to pushing out numbers to the 
		/// GameManager class which will handle what to do with them.
		/// </summary>
		public StartMenu _startMenu;
		public StatsMenu _statsMenu;
		public PauseMenu _pauseMenu;
		public OptionsMenu _optionsMenu;
		public CreditsMenu _creditMenu;
		public ButtonOverlord[] currentButtons;
		public int buttonSelected;
		public int buttonsAmountOf;
		public int buttonsStart;
		public int buttonsEnd;
		private float inputYaxis;
		private float timerButtonPressed;
		private float timerButtonWaitLength;
		public bool isActive;
		public GameManager _gameManager;
		public LevelManager _levelManager;
		public MenuSoundManager _menuSoundManager;
		public GameObject backGroundPlane;

		public void StartTheMenu () {
				isActive = true;
				ChangeActiveMenu (MenuID.START_MENU);
		}
		// Use this for initialization
		protected void Start () {
				DontDestroyOnLoad (transform.gameObject);
				InitBackGround ();
				InitSubMenus ();
				InitGameManager ();
				InitSoundManager ();
				isActive = false;
				InitializeButtonTimer ();
				transform.position = new Vector3 (0, 0, -2f);
				GetButtonList ();
				ChangeActiveMenu (MenuID.OFF_MENU);
		}

		void InitSoundManager () {
				_menuSoundManager = gameObject.GetComponent<MenuSoundManager> ();
		}

		void InitGameManager () {
				_gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
				_gameManager.ChangeGameState (GameState.MENU);
		}

		void InitBackGround () {
				backGroundPlane = transform.Find ("MenuBackground").gameObject;
				Color backGroundColor = new Color (1f, 1f, 1f, 0.90f);
				// this sets my color. I'm tring to change the alpha.
				backGroundPlane.renderer.material.color = backGroundColor;
		}

		void InitSubMenus () {
				_startMenu = gameObject.GetComponent<StartMenu> ();
				_pauseMenu = gameObject.GetComponent<PauseMenu> ();
				_optionsMenu = gameObject.GetComponent<OptionsMenu> ();
				_statsMenu = gameObject.GetComponent<StatsMenu> ();
				_creditMenu = gameObject.GetComponent<CreditsMenu> ();
		}

		public void GetLevelManager () {
				_levelManager = GameObject.Find ("LevelManager").GetComponent<LevelManager> ();//Get the level manager when we eneter the game. 		
		}
	
		// Update is called once per frame
		protected void Update () {
				if (isActive) {
						CheckInputs ();
				}
				if (_gameManager.gameState == GameState.ACTIVE && (Input.GetKeyDown (KeyCode.P) || Input.GetKeyDown (KeyCode.JoystickButton7))) {
						PauseGame (); 
				} else if (_gameManager.gameState == GameState.PAUSED && (Input.GetKeyDown (KeyCode.P) || Input.GetKeyDown (KeyCode.JoystickButton7))) {
						UnpauseGame ();
				}
		}

		void PauseGame () {
				isActive = true;
				ChangeActiveMenu (MenuID.PAUSE_MENU);
				_gameManager.gameState = GameState.PAUSED;
				_levelManager.ChangePausedState ();
		}

		void UnpauseGame () {
				isActive = false;
				ChangeActiveMenu (MenuID.OFF_MENU);
				_gameManager.gameState = GameState.ACTIVE;
				_levelManager.ChangePausedState ();
		}

		private void CheckInputs () {
				inputYaxis = Input.GetAxis ("Vertical");
				if ((inputYaxis > 0.5 || Input.GetKeyDown (KeyCode.UpArrow)) && ButtonTimer ()) {	
						ChangeSelectionWithController (-1);
						IncreaseButtonPressedTimer ();
						if (_gameManager._soundManager.playingSound) {			
								_menuSoundManager.PlayMenuMoveSound ();
						}
				} else if ((inputYaxis < -0.5 || Input.GetKeyDown (KeyCode.DownArrow)) && ButtonTimer ()) {
						ChangeSelectionWithController (1);
						IncreaseButtonPressedTimer ();
						if (_gameManager._soundManager.playingSound) {			
								_menuSoundManager.PlayMenuMoveSound ();
						}
				} else if (inputYaxis == 0) {
						timerButtonPressed = 0.0f;
				}
				if (timerButtonPressed > 0) {
						timerButtonPressed -= Time.deltaTime;
				}
				if (Input.GetKeyDown (KeyCode.JoystickButton0) || Input.GetKeyDown (KeyCode.Space)) {
						currentButtons [buttonSelected].Deselect ();
						ButtonClicked (currentButtons [buttonSelected].buttonType, currentButtons [buttonSelected].buttonAction, currentButtons [buttonSelected].buttonLocation);
						if (_gameManager._soundManager.playingSound) {			
								_menuSoundManager.PlayMenuSelectSound ();
						}
				}
		}

		public void ButtonClicked (int typeOfButton, int actionOfButton, int locationOfButton) {//There has to be a better way. 
				if (typeOfButton == MenuID.GAME_BUTTON) {
						if (actionOfButton == MenuID.START_PLAY) {
								_gameManager.ChangeGameState (GameState.ACTIVE);
								ChangeActiveMenu (MenuID.OFF_MENU);
								isActive = false;
								Application.LoadLevel (PublicID.FIRST_LEVEL); 
						}
				} else if (typeOfButton == MenuID.MENU_BUTTON) {
						switch (locationOfButton) {
						case MenuID.START_MENU_BUTTON:
								switch (actionOfButton) {
								case MenuID.START_PLAY:
										Debug.Log ("Start Play");
										break;
								case MenuID.START_STATS:
										ChangePlayerTimePlayed ();
										ChangeActiveMenu (MenuID.STATS_MENU);					
										break;
								case MenuID.START_OPTIONS:
										ChangeActiveMenu (MenuID.OPTIONS_MENU);	
										break;
								case MenuID.START_CREDITS:
										ChangeActiveMenu (MenuID.CREDIT_MENU);	
										break;				
								case MenuID.START_EXIT:
										Application.Quit ();
										Debug.Log ("Start Exit");
										break;
								}
								break;
						case MenuID.STATS_BUTTON:
								switch (actionOfButton) {
								case MenuID.STATS_EXIT:
										ChangeActiveMenu (MenuID.START_MENU);
										break;
								}
								break;
						case MenuID.OPTIONS_BUTTON:
								switch (actionOfButton) {
								case MenuID.OPTIONS_SOUND:
										ToggelSoundPlaying ();
										currentButtons [buttonSelected].ChangeText ();
										currentButtons [buttonSelected].Select ();
										break;
								case MenuID.OPTIONS_MUSIC:
										ToggelMusicPlaying ();
										currentButtons [buttonSelected].ChangeText ();
										currentButtons [buttonSelected].Select ();
										break;
								case MenuID.OPTIONS_BUTTON:
										ToggelControlScheme ();
										currentButtons [buttonSelected].ChangeText ();
										currentButtons [buttonSelected].Select ();
										break;
								case MenuID.OPTIONS_EXIT:
										ChangeActiveMenu (MenuID.START_MENU);
										break;
								}
								break;
						case MenuID.CREDITS_MENU_BUTTON:
								switch (actionOfButton) {
								case MenuID.CREDITS_EXIT:
										ChangeActiveMenu (MenuID.START_MENU);
										break;
								}
								break;
						case MenuID.PAUSE_BUTTON:
								switch (actionOfButton) {
								case MenuID.PAUSE_UNPAUSE:
										UnpauseGame ();
										break;
								case MenuID.PAUSE_EXIT:
										ChangeActiveMenu (MenuID.START_MENU);
										Application.LoadLevel (PublicID.LEVEL_MAIN_MENU);
										break;
								}
								break;
						}
				}
		}

		public void ChangePlayerTimePlayed () {
				_statsMenu.ChangeTimePlayerPlayed (_gameManager._timePlayed.TimePlayerPlayed ());
		}

		void ToggelControlScheme () {
				_gameManager.controlsSchemeAB = !_gameManager.controlsSchemeAB;
		}

		void ToggelSoundPlaying () {
				_gameManager._soundManager.playingSound = !_gameManager._soundManager.playingSound;
		}

		void ToggelMusicPlaying () {
				_gameManager._soundManager.playingMusic = !_gameManager._soundManager.playingMusic;
		}

		void ChangeActiveMenu (int whichMenu) {
				switch (whichMenu) {
				case MenuID.START_MENU:
						_startMenu.ChangeState (true);
						_statsMenu.ChangeState (false);
						_pauseMenu.ChangeState (false);
						_optionsMenu.ChangeState (false);
						_creditMenu.ChangeState (false);
						backGroundPlane.gameObject.SetActive (true);
						GetButtonList ();			
						break;
				case MenuID.PAUSE_MENU:
						_startMenu.ChangeState (false);
						_statsMenu.ChangeState (false);
						_pauseMenu.ChangeState (true);
						_optionsMenu.ChangeState (false);
						_creditMenu.ChangeState (false);
						backGroundPlane.gameObject.SetActive (true);
						GetButtonList ();
						break;
				case MenuID.STATS_MENU:
						_startMenu.ChangeState (false);
						_statsMenu.ChangeState (true);
						_pauseMenu.ChangeState (false);
						_optionsMenu.ChangeState (false);
						_creditMenu.ChangeState (false);
						backGroundPlane.gameObject.SetActive (true);
						GetButtonList ();
						break;
				case MenuID.OPTIONS_MENU:
						_startMenu.ChangeState (false);
						_statsMenu.ChangeState (false);
						_pauseMenu.ChangeState (false);
						_optionsMenu.ChangeState (true);
						_creditMenu.ChangeState (false);
						backGroundPlane.gameObject.SetActive (true);
						GetButtonList ();
						break;
				case MenuID.CREDIT_MENU:
						_startMenu.ChangeState (false);
						_statsMenu.ChangeState (false);
						_pauseMenu.ChangeState (false);
						_optionsMenu.ChangeState (false);
						_creditMenu.ChangeState (true);
						backGroundPlane.gameObject.SetActive (true);
						GetButtonList ();
						break;
				case MenuID.OFF_MENU:
						_startMenu.ChangeState (false);
						_statsMenu.ChangeState (false);
						_pauseMenu.ChangeState (false);
						_optionsMenu.ChangeState (false);
						_creditMenu.ChangeState (false);
						backGroundPlane.gameObject.SetActive (false);
						break;
				}
		}

		protected void ChangeSelectionWithController (int change) {
				currentButtons [buttonSelected].Deselect ();
				buttonSelected += change;
				if (buttonSelected < buttonsStart) {
						buttonSelected = buttonsEnd;
				} else if (buttonSelected > buttonsEnd) { 
						buttonSelected = buttonsStart;
				}
				currentButtons [buttonSelected].Select ();
		}

		protected void InitializeSubMenuHelper (GameObject go, Vector3 location) {
				go.transform.parent = transform;
				go.transform.localPosition = location;
				go.AddComponent<SubMenuOverlord> ();
		}

		protected void GetButtonList () {
				currentButtons = GetComponentsInChildren<ButtonOverlord> ();
				currentButtons [0].Select ();
				buttonSelected = 0;
				buttonsEnd = currentButtons.Length - 1;
		}

		private void InitializeButtonTimer () {
				timerButtonPressed = 0.0f;
				timerButtonWaitLength = 1.0f;
		}

		private void IncreaseButtonPressedTimer () {
				timerButtonPressed = timerButtonWaitLength;	
		}

		private bool ButtonTimer () {
				if (timerButtonPressed <= 0) {
						return true;	
				} else {
						return false;	
				}
		}

		public void ChangeSelectionWithMouse (int integer) {
				currentButtons [buttonSelected].Deselect ();
				currentButtons [integer].Select ();
				buttonSelected = integer;
		}
}