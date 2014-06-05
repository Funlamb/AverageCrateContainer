using UnityEngine;
using System.Collections;

public class PauseMenu : SubMenuOverlord {
		string name = "02_PauseMenu";
		// Use this for initialization
		void Awake () {
				subMenuIdentifier = MenuID.PAUSE_MENU;
				subMenuHolder = new GameObject (name);
				base.Start ();
				InitializeButtons ();
				base.PopulateWords ();
				Vector3 pos = new Vector3 (0f, 1.5f, -1.2f);
				subMenuHolder.transform.position = pos;
		}

		void InitializeButtons () {
				PauseTextCreator ();
				UnpauseButtonCreator ();
				BackToMainMenuCreator ();
		}

		void PauseTextCreator () {
				string buttonName = "Game Paused";
				GameObject statsButton = AddTextOnly ();
				TextMeshes ttm = statsButton.GetComponent<TextMeshes> ();
				statsButton.name = buttonName;		
				ttm.ThisStart ();
				ttm.ChangeText (buttonName);
				statsButton.transform.parent = subMenuHolder.transform;
				statsButton.transform.localPosition = new Vector3 (0, 1f, 0);

		}

		void UnpauseButtonCreator () {
				string buttonName = "Unpause";
				GameObject statsButton = AddButtonOnly ();
				ButtonOverlord bo = statsButton.GetComponent<ButtonOverlord> ();
				bo.buttonType = MenuID.MENU_BUTTON;
				bo.buttonAction = MenuID.PAUSE_UNPAUSE;
				bo.buttonLocation = MenuID.PAUSE_BUTTON;
				bo.SetIsSelectable (true);
				bo.Start ();
				bo.ChangeText (buttonName);
				bo.transform.parent = subMenuHolder.transform;
				bo.transform.localPosition = new Vector3 (0, -1f, 0);
				bo.name = buttonName;
				statsButton.AddComponent ("BoxCollider");
		}

		void BackToMainMenuCreator () {
				string buttonName = "Bact to Main Menu";
				GameObject statsButton = AddButtonOnly ();
				ButtonOverlord bo = statsButton.GetComponent<ButtonOverlord> ();
				bo.buttonType = MenuID.MENU_BUTTON;
				bo.buttonAction = MenuID.PAUSE_EXIT;		
				bo.buttonLocation = MenuID.PAUSE_BUTTON;
				bo.SetIsSelectable (true);
				bo.Start ();
				bo.ChangeText (buttonName);
				bo.transform.parent = subMenuHolder.transform;
				bo.transform.localPosition = new Vector3 (0, -3f, 0);
				bo.name = buttonName;
				statsButton.AddComponent ("BoxCollider");
		}
}
