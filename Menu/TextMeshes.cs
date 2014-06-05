using UnityEngine;
using System.Collections;

public class TextMeshes : MonoBehaviour {
		public TextMesh _textMesh;
		// Use this for initialization
		public void ThisStart () {
				_textMesh = gameObject.GetComponent<TextMesh> ();
		}

	public void ChangeText(string toThisString) {
		_textMesh.text = toThisString;
	}
}
