using UnityEngine;
using System.Collections;

public class XBoxController : MonoBehaviour {
		/// <summary>
		/// This is a reusably script for getting input from an XBox controller. 
		/// It will take all the buttons. Other scripts will be able to access this information using getters and setters.
		/// It is NOT perfected. 
		/// </summary>	
		public PlayerMovement playerMovement;
		public bool isActive;
		public myComtroller controller;
		private int controllerNumber;
		private bool button0, button1, button2, button3, button4, button5, button6, button7, button8, button9;
		private string joystickButton0, joystickButton1, joystickButton2, joystickButton3, joystickButton4, joystickButton5,
				joystickButton6, joystickButton7, joystickButton8, joystickButton9;
		private KeyCode xBoxButton0, xBoxButton1, xBoxButton2, xBoxButton3, xBoxButton4, xBoxButton5, xBoxButton6, xBoxButton7,
				xBoxButton8, xBoxButton9;
	
		void Awake () {
				SetController (controller); 
		}
		// Use this for initialization
		void Start () {
				isActive = true;
				playerMovement = GetComponent<PlayerMovement> ();
		}
	
		public bool GetButton0 () {
				return button0;
		}

		public bool GetButton1 () {
				return button1;
		}

		public bool GetButton2 () {
				return button2;
		}

		public bool GetButton3 () {
				return button3;
		}

		public bool GetButton4 () {
				return button4;
		}

		public bool GetButton5 () {
				return button5;
		}

		public bool GetButton6 () {
				return button6;
		}

		public bool GetButton7 () {
				return button7;
		}

		public bool GetButton8 () {
				return button8;
		}

		public bool GetButton9 () {
				return button9;
		}

		// Update is called once per frame
		void Update () {
//				if (true) {
				if (Input.GetKey (xBoxButton0)) {
						button0 = true;
				}
				if (Input.GetKeyDown (xBoxButton1)) {
						button1 = true;
				}
				if (Input.GetKeyDown (xBoxButton2)) {
						button2 = true;
				}
				if (Input.GetKeyDown (xBoxButton3)) {
						button3 = true;
				}
				if (Input.GetKeyDown (xBoxButton4)) {
						button4 = true;
				}
				if (Input.GetKeyDown (xBoxButton5)) {
						button5 = true;
				}
				if (Input.GetKeyDown (xBoxButton6)) {
						button6 = true;
				}
				if (Input.GetKeyDown (xBoxButton7)) {
						button7 = true;
				}
				if (Input.GetKeyDown (xBoxButton8)) {
						button8 = true;
				}
				if (Input.GetKeyDown (xBoxButton9)) {
						button9 = true;
				}
		}
//		}

		public void ClearInputs () {
				if (button0) {
						button0 = false;
				}
				if (button1) {
						button1 = false;
				}
				if (button2) {
						button2 = false;
				}
				if (button3) {
						button3 = false;
				}
				if (button4) {
						button4 = false;
				}
				if (button5) {
						button5 = false;
				}
				if (button6) {
						button6 = false;
				}
				if (button7) {
						button7 = false;
				}
				if (button8) {
						button8 = false;
				}
				if (button9) {
						button9 = false;
				}
		}

		void SetController (myComtroller mc) {
				if (mc == myComtroller.one) {
						controllerNumber = 1;
				} else if (mc == myComtroller.two) {
						controllerNumber = 2;
				} else if (mc == myComtroller.three) {
						controllerNumber = 3;
				} else if (mc == myComtroller.four) {
						controllerNumber = 4;
				} else if (mc == myComtroller.all) {
						controllerNumber = 0;
				}
				if (controllerNumber != 0) {
						joystickButton0 = "Joystick" + controllerNumber.ToString () + "Button0";
						joystickButton1 = "Joystick" + controllerNumber.ToString () + "Button1";
						joystickButton2 = "Joystick" + controllerNumber.ToString () + "Button2";
						joystickButton3 = "Joystick" + controllerNumber.ToString () + "Button3";
						joystickButton4 = "Joystick" + controllerNumber.ToString () + "Button4";
						joystickButton5 = "Joystick" + controllerNumber.ToString () + "Button5";
						joystickButton6 = "Joystick" + controllerNumber.ToString () + "Button6";
						joystickButton7 = "Joystick" + controllerNumber.ToString () + "Button7";
						joystickButton8 = "Joystick" + controllerNumber.ToString () + "Button8";
						joystickButton9 = "Joystick" + controllerNumber.ToString () + "Button9";
				} else {
						joystickButton0 = "JoystickButton0";
						joystickButton1 = "JoystickButton1";
						joystickButton2 = "JoystickButton2";
						joystickButton3 = "JoystickButton3";
						joystickButton4 = "JoystickButton4";
						joystickButton5 = "JoystickButton5";
						joystickButton6 = "JoystickButton6";
						joystickButton7 = "JoystickButton7";
						joystickButton8 = "JoystickButton8";
						joystickButton9 = "JoystickButton9";
				}
				xBoxButton0 = (KeyCode)System.Enum.Parse (typeof(KeyCode), joystickButton0);
				xBoxButton1 = (KeyCode)System.Enum.Parse (typeof(KeyCode), joystickButton1);
				xBoxButton2 = (KeyCode)System.Enum.Parse (typeof(KeyCode), joystickButton2);
				xBoxButton3 = (KeyCode)System.Enum.Parse (typeof(KeyCode), joystickButton3);
				xBoxButton4 = (KeyCode)System.Enum.Parse (typeof(KeyCode), joystickButton4);
				xBoxButton5 = (KeyCode)System.Enum.Parse (typeof(KeyCode), joystickButton5);
				xBoxButton6 = (KeyCode)System.Enum.Parse (typeof(KeyCode), joystickButton6);
				xBoxButton7 = (KeyCode)System.Enum.Parse (typeof(KeyCode), joystickButton7);
				xBoxButton8 = (KeyCode)System.Enum.Parse (typeof(KeyCode), joystickButton8);
				xBoxButton9 = (KeyCode)System.Enum.Parse (typeof(KeyCode), joystickButton9);
		}

		public enum myComtroller {
				all,
				one,
				two,
				three,
				four
		}
}
