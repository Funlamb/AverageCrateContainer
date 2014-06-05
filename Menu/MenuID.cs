using UnityEngine;
using System.Collections;

public class MenuID : MonoBehaviour {
	public const int GAME_BUTTON = 0; //interact with GameManager
	public const int MENU_BUTTON = 1; //Handles Menu functions
	
	public const int START_MENU = 0;
	public const int STATS_MENU = 1;
	public const int PAUSE_MENU = 2;
	public const int OPTIONS_MENU = 3;
	public const int CREDIT_MENU = 4;
	public const int OFF_MENU = 5;

	public const int START_MENU_BUTTON = 0;
	public const int START_PLAY = 0;
	public const int START_STATS = 1;
	public const int START_OPTIONS = 2;
	public const int START_CREDITS = 3;
	public const int START_EXIT = 4;

	public const int STATS_BUTTON = 1;
	public const int STATS_EXIT = 0;

	public const int OPTIONS_BUTTON = 2;
	public const int OPTIONS_SOUND = 0;
	public const int OPTIONS_MUSIC = 1;
	public const int OPTIONS_EXIT = 3;

	public const int PAUSE_BUTTON = 3;
	public const int PAUSE_UNPAUSE = 0;
	public const int PAUSE_EXIT = 1;

	public const int CREDITS_MENU_BUTTON = 4; 
	public const int CREDITS_EXIT = 0;

}
