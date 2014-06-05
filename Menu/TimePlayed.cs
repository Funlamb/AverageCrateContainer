using UnityEngine;
using System.Collections;

public class TimePlayed : MonoBehaviour {
		public GameManager _gameManager;
		public int seconds;
		public int minutes;
		public int hours;
		string _seconds;
		string _minutes;
		string _hours;

		void Awake () {
				_seconds = "00";
				_minutes = "00";
				_hours = "00";
				_gameManager = gameObject.GetComponent<GameManager> ();
		}
	
		void Update () {
				PlayerTimeTracker ();
		}

		private void PlayerTimeTracker () {
				if (seconds == 60) {
						seconds = 0;
						minutes++;
				}
				if (minutes == 60) {
						minutes = 0;
						hours++;
				}
		}

		IEnumerator Start () {
				while (true) {
						yield return new WaitForSeconds (1.0f);
						if (_gameManager.gameState == GameState.ACTIVE) {
								seconds ++;
						}
				}
		}

		public string TimePlayerPlayed () {
				FormatTime ();
				return _hours + ":" + _minutes + ":" + _seconds;
		}

		void FormatTime () {
				switch (seconds) {
				case 0:
						_seconds = "00";
						break;
				case 1:
						_seconds = "01";
						break;
				case 2:
						_seconds = "02";
						break;
				case 3:
						_seconds = "03";
						break;
				case 4:
						_seconds = "04";
						break;
				case 5:
						_seconds = "05";
						break;
				case 6:
						_seconds = "06";
						break;
				case 7:
						_seconds = "07";
						break;
				case 8:
						_seconds = "08";
						break;
				case 9:
						_seconds = "09";
						break;
				default:
						_seconds = seconds.ToString ();
						break;
				}
				switch (minutes) {
				case 0:
						_minutes = "00";
						break;
				case 1:
						_minutes = "01";
						break;
				case 2:
						_minutes = "02";
						break;
				case 3:
						_minutes = "03";
						break;
				case 4:
						_minutes = "04";
						break;
				case 5:
						_minutes = "05";
						break;
				case 6:
						_minutes = "06";
						break;
				case 7:
						_minutes = "07";
						break;
				case 8:
						_minutes = "08";
						break;
				case 9:
						_minutes = "09";
						break;
				default:
						_minutes = minutes.ToString ();
						break;
				}
				_hours = hours.ToString ();
		}
}
