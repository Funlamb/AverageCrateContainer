using UnityEngine;
using System.Collections;

public class MenuSoundManager : MonoBehaviour {
		private AudioClip selectButtonAudioClip;
		private AudioClip moveAudioClip;
		private AudioSource audioSource;

		// Use this for initialization
		void Start () {
				selectButtonAudioClip = (AudioClip)Resources.Load ("Sounds/ButtonSelect");
				moveAudioClip = (AudioClip)Resources.Load ("Sounds/ButtonMove");
				audioSource = gameObject.GetComponent<AudioSource> ();
		}

		public void PlayMenuSelectSound () {
				audioSource.PlayOneShot (selectButtonAudioClip);
		}

		public void PlayMenuMoveSound () {
				audioSource.PlayOneShot (moveAudioClip);
		}
}
