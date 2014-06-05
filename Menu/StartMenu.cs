using UnityEngine;
using System.Collections;

public class StartMenu : SubMenuOverlord {
		string name = "01_StartMenuHolder";
		// Use this for initialization
		void Awake () {
				subMenuIdentifier = MenuID.START_MENU;
				subMenuHolder = new GameObject (name);
				base.Start ();
				LoadStartMenuButtons ();
				base.PopulateButtons ();
				Vector3 pos = new Vector3 (0f, -.75f, -1.2f);
				subMenuHolder.transform.position = pos;
		}

		private void LoadStartMenuButtons () {
				NewGameButtonCreator ();
				StatsButtonCreator ();
				OptionsButtonCreator ();
				CreditButtonCreator ();
				ExitButtonCreator ();
		}

		void NewGameButtonCreator () {
				string buttonName = "New Game";
				GameObject newGameButton = AddButtonOnly ();
				ButtonOverlord bo = newGameButton.GetComponent<ButtonOverlord> ();
				bo.buttonType = MenuID.GAME_BUTTON;
				bo.buttonAction = MenuID.START_PLAY;
				bo.buttonLocation = MenuID.START_MENU_BUTTON;
				bo.Start ();
				bo.ChangeText (buttonName);
				bo.transform.parent = subMenuHolder.transform;
				bo.transform.localPosition = new Vector3 (0, 4f, 0);
				bo.name = buttonName;
				newGameButton.AddComponent ("BoxCollider");
				bo.SetIsSelectable (true);
		}
	
		void StatsButtonCreator () {
				string buttonName = "Stats";
				GameObject statsButton = AddButtonOnly ();
				ButtonOverlord bo = statsButton.GetComponent<ButtonOverlord> ();
				bo.buttonType = MenuID.MENU_BUTTON;
				bo.buttonAction = MenuID.START_STATS;
				bo.buttonLocation = MenuID.START_MENU_BUTTON;
				bo.Start ();
				bo.ChangeText (buttonName);
				bo.transform.parent = subMenuHolder.transform;
				bo.transform.localPosition = new Vector3 (0, 2.5f, 0);
				bo.name = buttonName;
				statsButton.AddComponent ("BoxCollider");
				bo.SetIsSelectable (true);
		}

		void OptionsButtonCreator () {
				string buttonName = "Options";
				GameObject optionsButton = AddButtonOnly ();
				ButtonOverlord bo = optionsButton.GetComponent<ButtonOverlord> ();
				bo.buttonType = MenuID.MENU_BUTTON;
				bo.buttonAction = MenuID.START_OPTIONS;
				bo.buttonLocation = MenuID.START_MENU_BUTTON;
				bo.Start ();
				bo.ChangeText (buttonName);
				bo.transform.parent = subMenuHolder.transform;
				bo.transform.localPosition = new Vector3 (0, 1f, 0);
				bo.name = buttonName;
				optionsButton.AddComponent ("BoxCollider");
				bo.SetIsSelectable (true);
		}

		void CreditButtonCreator () {
				string buttonName = "Credits";
				GameObject optionsButton = AddButtonOnly ();
				ButtonOverlord bo = optionsButton.GetComponent<ButtonOverlord> ();
				bo.buttonType = MenuID.MENU_BUTTON;
				bo.buttonAction = MenuID.START_CREDITS;
				bo.buttonLocation = MenuID.START_MENU_BUTTON;
				bo.Start ();
				bo.ChangeText (buttonName);
				bo.transform.parent = subMenuHolder.transform;
				bo.transform.localPosition = new Vector3 (0, -0.5f, 0);
				bo.name = buttonName;
				optionsButton.AddComponent ("BoxCollider");
				bo.SetIsSelectable (true);
		}

		void ExitButtonCreator () {
				string buttonName = "Exit";
				GameObject exitButton = AddButtonOnly ();
				ButtonOverlord bo = exitButton.GetComponent<ButtonOverlord> ();
				bo.buttonType = MenuID.MENU_BUTTON;
				bo.buttonAction = MenuID.START_EXIT;
				bo.buttonLocation = MenuID.START_MENU_BUTTON;
				bo.SetIsSelectable (true);
				bo.Start ();
				bo.ChangeText (buttonName);
				bo.transform.parent = subMenuHolder.transform;
				bo.transform.localPosition = new Vector3 (0, -2f, 0);
				bo.name = buttonName;
				exitButton.AddComponent ("BoxCollider");
		}
}
