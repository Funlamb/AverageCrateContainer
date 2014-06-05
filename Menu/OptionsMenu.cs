using UnityEngine;
using System.Collections;

public class OptionsMenu : SubMenuOverlord {
		string name = "03_OptionsMenu";
		// Use this for initialization
		void Awake () {
				subMenuIdentifier = MenuID.OPTIONS_MENU;
				subMenuHolder = new GameObject (name);
				base.Start ();
				InitializeButtons ();
				base.PopulateButtons ();
				Vector3 pos = new Vector3 (0f, -.75f, -1.2f);
				subMenuHolder.transform.position = pos;
		}

		void InitializeButtons () {
//		ButtonsButtonCreator();//Never ended up using this because I don't know how to map buttons. 
				SoundButtonCreator ();
				MusicButtonCreator ();
				ExitButtonCreator ();
		}

		void SoundButtonCreator () {
				string buttonName = "Sound";
				GameObject soundButton = AddButtonOnly ();
				ButtonOverlord bo = soundButton.GetComponent<ButtonOverlord> ();
				bo.text = buttonName + ": On";
				bo.textOriginal = buttonName + ": On";
				bo.textChange = buttonName + ": Off";
				bo.buttonType = MenuID.MENU_BUTTON;
				bo.buttonAction = MenuID.OPTIONS_SOUND;
				bo.buttonLocation = MenuID.OPTIONS_BUTTON;
				bo.SetIsSelectable (true);
				bo.Start ();
				bo.ChangeText (bo.text);
				bo.transform.parent = subMenuHolder.transform;
				bo.transform.localPosition = new Vector3 (0, 3f, 0);
				bo.name = buttonName;
				soundButton.AddComponent ("BoxCollider");
		}

		void MusicButtonCreator () {
				string buttonName = "Music";
				GameObject musicButton = AddButtonOnly ();
				ButtonOverlord bo = musicButton.GetComponent<ButtonOverlord> ();
				bo.text = buttonName + ": On";
				bo.textOriginal = buttonName + ": On";
				bo.textChange = buttonName + ": Off";
				bo.buttonType = MenuID.MENU_BUTTON;
				bo.buttonAction = MenuID.OPTIONS_MUSIC;
				bo.buttonLocation = MenuID.OPTIONS_BUTTON;
				bo.SetIsSelectable (true);
				bo.Start ();
				bo.ChangeText (bo.text);
				bo.transform.parent = subMenuHolder.transform;
				bo.transform.localPosition = new Vector3 (0, 1f, 0);
				bo.name = buttonName;
				musicButton.AddComponent ("BoxCollider");
		}

		void ButtonsButtonCreator () {
				string buttonName = "Buttons";
				GameObject musicButton = AddButtonOnly ();
				ButtonOverlord bo = musicButton.GetComponent<ButtonOverlord> ();
				bo.text = buttonName + ": A/B";
				bo.textOriginal = buttonName + ": A/B";
				bo.textChange = buttonName + ": B/A";
				bo.buttonType = MenuID.MENU_BUTTON;
				bo.buttonAction = MenuID.OPTIONS_BUTTON;
				bo.buttonLocation = MenuID.OPTIONS_BUTTON;
				bo.SetIsSelectable (true);
				bo.Start ();
				bo.ChangeText (bo.text);
				bo.transform.parent = subMenuHolder.transform;
				bo.transform.localPosition = new Vector3 (0, -1f, 0);
				bo.name = buttonName;
				musicButton.AddComponent ("BoxCollider");
		}

		void ExitButtonCreator () {
				string name = "Exit";
				GameObject exitButton = AddButtonOnly ();
				ButtonOverlord bo = exitButton.GetComponent<ButtonOverlord> ();
				bo.buttonType = MenuID.MENU_BUTTON;
				bo.buttonAction = MenuID.OPTIONS_EXIT;
				bo.buttonLocation = MenuID.OPTIONS_BUTTON;
				bo.SetIsSelectable (true);
				bo.Start ();
				bo.ChangeText (name);
				bo.transform.parent = subMenuHolder.transform;
				bo.transform.localPosition = new Vector3 (0, -1f, 0);
				bo.name = name;
				exitButton.AddComponent ("BoxCollider");
		}

}
