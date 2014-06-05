using UnityEngine;
using System.Collections;

public class SubMenuOverlord : MonoBehaviour {
		public bool isActive;
		public MenuOverlord _mo;
		public GameObject subMenuHolder;
		public int subMenuIdentifier;
		public ButtonOverlord[] buttons;
		public TextMeshes[] textMeshs;
		public int buttonSelected;
		public int buttonsStart;
		public int buttonsEnd;
		public GameObject buttonPrefab;
		public GameObject textPrefab;
		// Use this for initialization
		public void Start () {
				_mo = gameObject.GetComponent<MenuOverlord> ();
				textPrefab = (GameObject)Resources.Load ("Text/TextBlock");
				buttonPrefab = (GameObject)Resources.Load ("Text/ButtonBlock");
				subMenuHolder.transform.parent = transform;
		}

		protected void PopulateWords () {
				PopulateButtons ();
				PopulateTextMeshes ();
		}

		public void ChangeState (bool theBool) {
				if (theBool) {
						foreach (ButtonOverlord b in buttons) {
								b.transform.gameObject.SetActive (true);
						}
						foreach (TextMeshes t in textMeshs) {
								t.transform.gameObject.SetActive (true);
						}
						isActive = true;
				} else {
						foreach (ButtonOverlord b in buttons) {
								b.transform.gameObject.SetActive (false);
						}
						foreach (TextMeshes t in textMeshs) {
								t.transform.gameObject.SetActive (false);
						}
						isActive = false;
				}
		}

		public void PopulateButtons () {
				buttons = subMenuHolder.GetComponentsInChildren<ButtonOverlord> ();
				buttonsEnd = buttons.Length - 1;
		}

		public void PopulateTextMeshes () {
				textMeshs = subMenuHolder.GetComponentsInChildren<TextMeshes> ();
		}

		public void ChangeSelectionWithMouse (object par) {
		}

		public void ButtonClicked (object sendToMenuLocation, object publicID) {
		}

		protected GameObject AddButtonOnly () {
				GameObject button = (GameObject)Instantiate (buttonPrefab);
				return button;
		}

		protected GameObject AddTextOnly () {
				GameObject text = (GameObject)Instantiate (textPrefab);
				return text;
		}
}
