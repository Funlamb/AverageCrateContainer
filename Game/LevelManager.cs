using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
		public PlayerMovement _playerMovement;
		public Box _box;
		public GameObject _walkingEnemy;
		public Transform _spawnLeft;
		public Transform _spawnRight;
		public float timer;
		public float spawnTimer;
		public int spawnTimerRandomSmall;
		public int spawnTimerRandomLarge;
		public int spawnRandomLocation;
		public int spawnRandomLocationSmall;
		public int spawnRandomLocationLarge;
		public Transform spawnLocation;
		public int score;
		public bool testingWithoutEnemies;
		public XBoxController _xBoxController;
		public bool isPlaying;
		public MenuOverlord _menuOverlord;
		private AudioClip audioClip;
		private AudioSource audioSource;

		// Use this for initialization
		void Start () {
				InitMenuManager ();
				InitMusic ();
				isPlaying = true;
				InitController ();
				InitEnemySpawner ();
				InitEnemy ();
				InitBox ();
				InitPlayer ();
				SpawnLocationRandomizer ();
		}

		void InitMusic () {
				audioClip = (AudioClip)Resources.Load ("Sounds/DST-2ndBallad");
				audioSource = gameObject.GetComponent<AudioSource> ();
				audioSource.clip = audioClip;
				if (_menuOverlord._gameManager._soundManager.playingMusic) {
						audioSource.Play ();
				}
		}

		void InitMenuManager () {
				_menuOverlord = GameObject.Find ("MainMenu").GetComponent<MenuOverlord> ();
				_menuOverlord.GetLevelManager ();
		}

		void InitController () {
				_xBoxController = GetComponent<XBoxController> ();
		}

		void InitEnemySpawner () {
				spawnRandomLocationSmall = 1;
				spawnRandomLocationLarge = 3;
				spawnTimerRandomSmall = 1;
				spawnTimerRandomLarge = 4;
				SpawnTimerRandimizer ();
				timer = 0;
				_spawnLeft = GameObject.Find ("SpawnLeft").transform;
				_spawnRight = GameObject.Find ("SpawnRight").transform;
		}

		void InitEnemy () {
				_walkingEnemy = (GameObject)Resources.Load ("Prefabs/WalkingEnemy", typeof(GameObject));
		}

		void InitBox () {
				_box = GameObject.Find ("Box").GetComponent<Box> ();
		}

		void InitPlayer () {
				_playerMovement = GameObject.Find ("GreenGuy").GetComponent<PlayerMovement> ();
		}

		public void AddToScore () {
				score ++;
		}

		void OnGUI () {
				GUI.Label (new Rect (25, 25, 100, 30), score.ToString ());
		}

		void SpawnLocationRandomizer () {
				spawnRandomLocation = Random.Range (spawnRandomLocationSmall, spawnRandomLocationLarge);
				if (spawnRandomLocation == spawnRandomLocationSmall) {
						spawnLocation = _spawnLeft;
				} else if (spawnRandomLocation == spawnRandomLocationLarge - 1) {
						spawnLocation = _spawnRight;
				}
		}

		void SpawnTimerRandimizer () {
				spawnTimer = Random.Range (spawnTimerRandomSmall, spawnTimerRandomLarge);
		}

		void SpawnWalkingEnemy () {
				if (timer > spawnTimer && !testingWithoutEnemies) {
						SpawnTimerRandimizer ();
						SpawnLocationRandomizer ();
						Instantiate (_walkingEnemy, spawnLocation.position, Quaternion.identity);
						timer = 0;
				}
		}
	
		// Update is called once per frame
		void Update () {
				if (isPlaying) {
						timer += Time.deltaTime;
						SpawnWalkingEnemy ();
				}
		}

		public void ChangePausedState () {
				isPlaying = !isPlaying;
				Object[] objects = FindObjectsOfType (typeof(GameObject));
				if (!isPlaying) {
						foreach (GameObject go in objects) {
								go.SendMessage ("OnPauseGame", SendMessageOptions.DontRequireReceiver);
						}
				}
				if (isPlaying) {
						foreach (GameObject go in objects) {
								go.SendMessage ("OnResumeGame", SendMessageOptions.DontRequireReceiver);
						}
				}
		}
}
