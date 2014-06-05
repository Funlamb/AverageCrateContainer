using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {
		private Vector2 fallingSpeed;
		private float timer;
		private float textFallingStartTime;
		private float textFallingStopTime;
		private bool textFalling;
		//
		private GameObject floor;
		private float floorJumpStartTime;
		private float floorJumpStopTime;
		private bool floorJumpBool;
		private Vector2 OriginalFloorPos;
		//
		private GameObject camera;
		private float cameraShakeStartTime;
		private float cameraShakeStopTime;
		private bool cameraShakeBool;
		private Vector3 originalCamerPos;
		private Vector2 cameraShakeRange;
		private Vector3 tempCameraPos;
		//
		private TextMesh[] allTexts;
		private Color textColor;
		private int RGBcolor;

		// Use this for initialization
		void Start () {
				InitText ();
				InitFloor ();
				InitCamera ();
		}

		void InitText () {
				allTexts = GetComponentsInChildren<TextMesh> ();
				textFallingStartTime = 1.25f;
				textFallingStopTime = 1.5f;
				textFalling = true;
				RGBcolor = 255;
				textColor.r = RGBcolor;
				textColor.b = RGBcolor;
				textColor.g = RGBcolor;
		}

		void InitFloor () {
				floor = GameObject.FindGameObjectWithTag ("SplashGround");
				floorJumpStartTime = 1.5f;
				floorJumpStopTime = 1.6f;
				floorJumpBool = true;
				OriginalFloorPos = floor.transform.position;
		}

		void InitCamera () {
				camera = GameObject.Find ("Main Camera");
				cameraShakeStartTime = 1.6f;
				cameraShakeStopTime = 3.0f;
				cameraShakeRange = new Vector2 (-0.3f, 0.3f);
				cameraShakeBool = true;
				originalCamerPos = camera.transform.position;
		}

	
		// Update is called once per frame
		void FixedUpdate () {
				timer += Time.deltaTime;
				rigidbody2D.velocity = fallingSpeed;
				if (textFalling && timer > textFallingStartTime) {
						StartFalling ();
				}
				if (timer > textFallingStopTime) {
						textFalling = false;
						StopFalling ();
				}

				if (floorJumpBool && timer > floorJumpStartTime) {
						JitterFloor ();
				}
				if (timer > floorJumpStopTime) {
						floorJumpBool = false;
						SetFloorBackToOriginalPos ();
				}
				if (cameraShakeBool && timer > cameraShakeStartTime) {
						ShakeCamera ();
						CameraShakeSlower ();
				}
				if (timer > cameraShakeStopTime) {
						cameraShakeBool = false;
						camera.transform.position = originalCamerPos;
				}
				if (timer > textFallingStopTime + 1.5) {
						Fade ();
				}
		}

		void CameraShakeSlower () {
				cameraShakeRange.x += 0.004f;
				cameraShakeRange.y -= 0.004f;
		}

		void ShakeCamera () {
				tempCameraPos.x = Random.Range (cameraShakeRange.x, cameraShakeRange.y); 
				tempCameraPos.y = Random.Range (cameraShakeRange.x, cameraShakeRange.y);
				tempCameraPos.z = -10;
				camera.transform.position = tempCameraPos;
		}

		void JitterFloor () {
				floor.transform.rigidbody2D.velocity = new Vector2 (0, 20);
		}

		void SetFloorBackToOriginalPos () {
				floor.transform.rigidbody2D.velocity = new Vector2 (0, 0);
				floor.transform.position = OriginalFloorPos;
		}

		void StartFalling () {
				fallingSpeed = new Vector2 (0, -100);
		}

		void StopFalling () {
				fallingSpeed = new Vector2 (0, 0);
		}

		void Fade () {
				textColor.a = Mathf.Abs (Mathf.Sin (2 * Time.time));//This sets the alpha chanel of the color using sin * Time.time
				foreach (TextMesh tm in allTexts) {
						tm.color = textColor;
				}
		}

}
