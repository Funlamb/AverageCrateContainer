using UnityEngine;
using System.Collections;

public class StatsMenu : SubMenuOverlord {
		private string name = "02_StatsMenu";
		public TimePlayed _timePlayed;
		private string timePlayed;
		private GameObject timePlayerPlayed;

		// Use this for initialization
		private void Awake () {
				_timePlayed = GameObject.Find ("GameManager").GetComponent<TimePlayed> ();
				timePlayed = "";		
				subMenuIdentifier = MenuID.STATS_MENU;
				buttonSelected = 0;
				buttonsStart = 0;
				buttonsEnd = 2;
				subMenuHolder = new GameObject (name);
				base.Start ();
				InitializeButtons ();
				base.PopulateButtons ();
				base.PopulateTextMeshes ();
		}

		private void InitializeButtons () {
				ExitButtonCreator ();
				TimePlayerPlayedCreator ();
				TimeTextCreator ();
		}

		private void TimeTextCreator () {
				string textName = "Time Played:";
				GameObject timeText = AddTextOnly ();
				TextMesh tm = timeText.GetComponent<TextMesh> ();
				tm.name = textName;
				timeText.transform.parent = subMenuHolder.transform;
				timeText.transform.localPosition = new Vector3 (0, 2f, 0);
				tm.text = textName;
		}

		public void ChangeTimePlayerPlayed (string thisString) {
				timePlayed = thisString;
				timePlayerPlayed.GetComponent<TextMeshes> ().ChangeText (timePlayed);
		}

		private void TimePlayerPlayedCreator () {
				string textName = "Time Played";
				timePlayerPlayed = AddTextOnly ();
				TextMesh tm = timePlayerPlayed.GetComponent<TextMesh> ();
				tm.name = textName;
				timePlayerPlayed.transform.parent = subMenuHolder.transform;
				timePlayerPlayed.transform.localPosition = new Vector3 (0, 0, 0);
				tm.text = timePlayed;
				TextMeshes ttm = timePlayerPlayed.GetComponent<TextMeshes> ();
				ttm.ThisStart ();
		}
	
		private void ExitButtonCreator () {
				string buttonName = "Exit";
				GameObject exitButton = AddButtonOnly ();
				ButtonOverlord bo = exitButton.GetComponent<ButtonOverlord> ();
				bo.buttonType = MenuID.MENU_BUTTON;
				bo.buttonAction = MenuID.STATS_EXIT;
				bo.buttonLocation = MenuID.STATS_BUTTON;
				bo.SetIsSelectable (true);
				bo.Start ();
				bo.ChangeText (buttonName);
				bo.transform.parent = subMenuHolder.transform;
				bo.transform.localPosition = new Vector3 (0, -2f, 0);
				bo.name = buttonName;
				exitButton.AddComponent ("BoxCollider");
		}
}
