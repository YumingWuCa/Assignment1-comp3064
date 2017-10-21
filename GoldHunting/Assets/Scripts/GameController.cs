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
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Update interface
public class GameController : MonoBehaviour {

	[SerializeField] Text lifeLabel = null;
	[SerializeField] Text scoreLabel = null;
	[SerializeField] Text gameOverLabel = null;
	[SerializeField] Text winLabel = null;
	[SerializeField] Text highScoreLable = null;
	[SerializeField] Button resetBtn = null;

	[SerializeField] GameObject ghost = null;

	void Start () {
		// connect Player class to this class
		Player.Instance.gameCtrl = this;
		initialize ();
	}

	// the start and playing mode
	// initialize the starts
	private void initialize(){
		// call the Player class functions disaplay the current score and lives to the user
		Player.Instance.Point = 0;
		Player.Instance.Life = 3;
		Player.Instance.HighScore = 0;

		lifeLabel.gameObject.SetActive (true);
		scoreLabel.gameObject.SetActive (true);
//		startBtn.gameObject.SetActive (true);
		gameOverLabel.gameObject.SetActive (false);
		winLabel.gameObject.SetActive(false);
		highScoreLable.gameObject.SetActive (false);
		resetBtn.gameObject.SetActive (false);

		// create more ghost to increase the challange to the user
		StartCoroutine ("MoreGhost");
	}

	// appear the result when the life == 0
	public void GameOver(){
		gameOverLabel.gameObject.SetActive (true);
		highScoreLable.gameObject.SetActive (true);
		resetBtn.gameObject.SetActive (true);

		// life and score not appear
		lifeLabel.gameObject.SetActive (false);
		scoreLabel.gameObject.SetActive (false);
		winLabel.gameObject.SetActive(false);

		highScoreLable.text = "Your Score: " + Player.Instance.Point;
	}

	// appear the result when collected 1000 points
	// or collected the golden crown
	public void Win(){

		winLabel.gameObject.SetActive(true);
		highScoreLable.gameObject.SetActive (true);
		resetBtn.gameObject.SetActive (true);

		scoreLabel.gameObject.SetActive(false);
		lifeLabel.gameObject.SetActive(false);
		gameOverLabel.gameObject.SetActive(false);
		resetBtn.gameObject.SetActive (false);

		highScoreLable.text = "Your Score: " + Player.Instance.Point;
	}

	// restart button function
	public void ResetBtnClick(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	// create more ghosts to the scene to challange the user
	private IEnumerator MoreGhost(){

		int time = Random.Range(1,10);
		yield return new WaitForSeconds ((float)time);
		Instantiate (ghost);
		// increase the challange to the user
		StartCoroutine ("MoreGhost");
	}

	// call Player class to get score and life information to the UI
	public void updateUI(){
		scoreLabel.text = "Score: " + Player.Instance.Point;
		lifeLabel.text = "Life: " + Player.Instance.Life;
		highScoreLable.text = "Your Score: " + Player.Instance.Point;
	}
}
