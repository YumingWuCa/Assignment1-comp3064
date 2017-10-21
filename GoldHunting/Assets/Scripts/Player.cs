/*
 * PROGRAM: COMP3064 
 * SOURCE: LAB EXAMPLE
 * ASSIGNMENT 1: GOLD HUNTING
 * AUTHOR: YUMING WU 101027496
 * LAST MODIFIED BY YUMING WU
 * DATE LAST MODIFIED: OCT 20, 2017
 * PROGRAM DESCRIPTION: GAME DEVELOPMENT
 * REVISION HISTORY: REVISION 5 TIMES
 * CODE REFFERENCE: LAB6
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// store user's scores and life information
public class Player {

	private int _point = 0;
	private int _life = 3;
	private int _highScore = 0;

	public GameController gameCtrl;

	// allow other controllers to use this singleton class
	static private Player _instance;

	static public Player Instance {
		get{ if (_instance == null) {
				_instance = new Player ();			
			} 
			return _instance;
		}
	}

	// default
	private Player(){

	}
		
	// updates score values and pass it to the UI
	// when points reach 9999 player or go to the other levelwin
	public int Point{ 
		get { return _point; } 
		set { 
			_point = value; 
			if (value >= 9999) {

				gameCtrl.Win ();

			} else {
				gameCtrl.updateUI ();
			}
		}
	}

	// updates score values and pass it to the UI
	// when life <= 0 game over
	public int Life {
		get { return _life; }
		set {
			_life = value;
			if (_life <= 0) {
				gameCtrl.GameOver ();
			} else {
				gameCtrl.updateUI ();
			}
		}
	}

	// updates score values and pass it to the UI
	public int HighScore { 
		get { return _highScore; } 
		set { 			
			if (value > _highScore)
				_highScore = _point;
			PlayerPrefs.SetInt ("_highScore", _highScore);			
		}	
	}		
}


