using UnityEngine;
using System.Collections;

public class CreditsMenu : SubMenuOverlord {
		string name = "04_Credits";
		// Use this for initialization
		void Awake () {
				subMenuIdentifier = MenuID.CREDIT_MENU;
				subMenuHolder = new GameObject (name);
				base.Start ();
				InitializeButtons ();
				base.PopulateWords ();
				Vector3 pos = new Vector3 (0f, 0.9f, -1.2f);
				subMenuHolder.transform.position = pos;
		}

		void InitializeButtons () {
				PauseTextCreator ();
				CreditCodeAndDesign ();
				CreditCodeAndDesignName ();
				CreditArt ();
				CreditArtName ();
				CreditSound ();
				CreditSoundName ();
				CreditExit ();
		}

		void PauseTextCreator () {
				string buttonName = "Credits";
				GameObject creditsText = AddTextOnly ();
				TextMeshes ttm = creditsText.GetComponent<TextMeshes> ();
				creditsText.name = buttonName;		
				ttm.ThisStart ();
				ttm.ChangeText (buttonName);
				creditsText.transform.parent = subMenuHolder.transform;
				creditsText.transform.localPosition = new Vector3 (0, 3f, 0);
		}

		void CreditCodeAndDesign () {
				string buttonName = "Code / Game Design:";
				GameObject creditsText = AddTextOnly ();
				TextMeshes ttm = creditsText.GetComponent<TextMeshes> ();
				creditsText.name = buttonName;		
				ttm.ThisStart ();
				ttm.ChangeText (buttonName);
				creditsText.transform.parent = subMenuHolder.transform;
				creditsText.transform.localPosition = new Vector3 (0, 2f, 0);
		
		}

		void CreditCodeAndDesignName () {
				string buttonName = "Michael Roy";
				GameObject creditsText = AddTextOnly ();
				TextMeshes ttm = creditsText.GetComponent<TextMeshes> ();
				creditsText.name = buttonName;		
				ttm.ThisStart ();
				ttm.ChangeText (buttonName);
				creditsText.transform.parent = subMenuHolder.transform;
				creditsText.transform.localPosition = new Vector3 (0, 1f, 0);
		}

		void CreditArt () {
				string buttonName = "Art:";
				GameObject creditsText = AddTextOnly ();
				TextMeshes ttm = creditsText.GetComponent<TextMeshes> ();
				creditsText.name = buttonName;		
				ttm.ThisStart ();
				ttm.ChangeText (buttonName);
				creditsText.transform.parent = subMenuHolder.transform;
				creditsText.transform.localPosition = new Vector3 (0, 0f, 0);
		
		}

		void CreditArtName () {
				string buttonName = "opengameart.org/users/kenney";
				GameObject creditsText = AddTextOnly ();
				TextMeshes ttm = creditsText.GetComponent<TextMeshes> ();
				creditsText.name = buttonName;		
				ttm.ThisStart ();
				ttm.ChangeText (buttonName);
				creditsText.transform.parent = subMenuHolder.transform;
				creditsText.transform.localPosition = new Vector3 (0, -1f, 0);
		
		}

		void CreditSound () {
				string buttonName = "Sound:";
				GameObject creditsText = AddTextOnly ();
				TextMeshes ttm = creditsText.GetComponent<TextMeshes> ();
				creditsText.name = buttonName;		
				ttm.ThisStart ();
				ttm.ChangeText (buttonName);
				creditsText.transform.parent = subMenuHolder.transform;
				creditsText.transform.localPosition = new Vector3 (0, -2f, 0);
		
		}
	
		void CreditSoundName () {
				string buttonName = "www.bfxr.net/";
				GameObject creditsText = AddTextOnly ();
				TextMeshes ttm = creditsText.GetComponent<TextMeshes> ();
				creditsText.name = buttonName;		
				ttm.ThisStart ();
				ttm.ChangeText (buttonName);
				creditsText.transform.parent = subMenuHolder.transform;
				creditsText.transform.localPosition = new Vector3 (0, -3f, 0);
		
		}
	
		void CreditExit () {
				string buttonName = "Exit";
				GameObject statsButton = AddButtonOnly ();
				ButtonOverlord bo = statsButton.GetComponent<ButtonOverlord> ();
				bo.buttonType = MenuID.MENU_BUTTON;
				bo.buttonAction = MenuID.CREDITS_EXIT;
				bo.buttonLocation = MenuID.CREDITS_MENU_BUTTON;
				bo.SetIsSelectable (true);
				bo.Start ();
				bo.ChangeText (buttonName);
				bo.transform.parent = subMenuHolder.transform;
				bo.transform.localPosition = new Vector3 (0, -4f, 0);
				bo.name = buttonName;
				statsButton.AddComponent ("BoxCollider");
		}
}
