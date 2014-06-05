using UnityEngine;
using System.Collections;

public class ButtonOverlord : MonoBehaviour {
	public int buttonType;// Is this a menu or game button? 
	public int buttonAction;// What does this button point to?
	public int buttonLocation;
	public int menuLocation;
	public string nameButton;
	public bool textOriginalBool;
	public string text;
	public string textOriginal;
	public string textChange;
	public Vector3 locationInGame;
	public SubMenuOverlord _smo;
	public bool isSelectable;
	public int publicID;
	public TextMesh _tm;
	
	// Use this for initialization
	public void Start () {
		textOriginalBool = true;
		_smo = transform.root.GetComponent<SubMenuOverlord>();
		_tm = GetComponent<TextMesh>();
	}
	public void ChangeText (string text){
		nameButton = text;
		_tm.text = nameButton;
	}
	public void ChangeSendToMenuLocation (int sendTolocation) {
		buttonAction = sendTolocation;
	}
	public void ChangeMenuLocation (int ml) {
		menuLocation = ml;	
	}
	public void ChangeLocation (Vector3 location) {
		locationInGame = location;
	}
	public void SetIsSelectable (bool b) {
		isSelectable = b;
	}
	public void SetPublicID (int pubID) {
		publicID = pubID;
	}
	public void ChangeText () {
		textOriginalBool = !textOriginalBool;
		if (textOriginalBool) {
			text = textOriginal;
		} else {
			text = textChange;
		}
		ChangeText(text);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	private void OnMouseDown () {
		if (isSelectable) {
		_smo.ButtonClicked(buttonAction, publicID);
		}
	}	
	private void  OnMouseEnter () {
		if (isSelectable) {
		 	_smo.ChangeSelectionWithMouse(menuLocation-1);
	 		Select ();
		}
	}
	private void OnMouseExit () {
		if (isSelectable) {
			Deselect ();
		}
	}
	public void ChangeIsSelectableState (bool selectableState) {
		isSelectable = selectableState;
	}
	public void Select () {
		renderer.material.color = Color.red; //change the color of the text
	}
	public void Deselect () {
		renderer.material.color = Color.white; //change the color of the text
	}
}
