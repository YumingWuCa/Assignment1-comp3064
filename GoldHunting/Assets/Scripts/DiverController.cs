/*
 * PROGRAM: COMP3064 
 * SOURCE: LAB EXAMPLE
 * ASSIGNMENT 1: GOLD HUNTING
 * AUTHOR: YUMING WU 101027496
 * LAST MODIFIED BY YUMING WU
 * DATE LAST MODIFIED: OCT 20, 2017
 * PROGRAM DESCRIPTION: GAME DEVELOPMENT
 * REVISION HISTORY: REVISION 5 TIMES
 * CODE REFFERENCE: LAB2
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiverController : MonoBehaviour {

	[SerializeField] private float speed = 7f;

	// size of the camera view
	// to keep the diver stay activity in the view
	[SerializeField] private float up = 140;
	[SerializeField] private float down = 140;
	[SerializeField] private float right = 310;
	[SerializeField] private float left = -310;
	[SerializeField] GameObject bullet;
	private Transform _transform;
	private Vector2 _currentPos;

	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		_currentPos = _transform.position;
		bullet = GameObject.Find ("bullet");
	}

	// use the standard keys (WASD) to control the diver from the user keyboard input
	void FixedUpdate () { 
		
		_currentPos = _transform.position;

		if (Input.GetKey(KeyCode.W)) {
			_currentPos += new Vector2 (0, speed);			
		}
		if (Input.GetKey(KeyCode.S)){
			_currentPos -= new Vector2 (0, speed);			
		}
		if (Input.GetKey(KeyCode.A)){
			_currentPos -= new Vector2 (speed, 0);			
		}
		if (Input.GetKey(KeyCode.D)){
			_currentPos += new Vector2 (speed, 0);			
		}	
		CheckBounds();
		_transform.position = _currentPos;

		// use the space key to create bullet at the sametime move forward
		// in order to collides with the ghost
		if (Input.GetKeyDown (KeyCode.Space)) {
			GameObject shoot = Instantiate (bullet);
			shoot.transform.position = new Vector2((_transform.position.x + 1.5f), (_transform.position.y));
		}
	}

	// set up the range for the diver stay in the frame
	private void CheckBounds(){
		if (_currentPos.y > up) {
			_currentPos.y = up;
		}
		if (_currentPos.y < down){
			_currentPos.y = down;
		}
		if (_currentPos.x < left) {
			_currentPos.x = left;
		}
		if (_currentPos.x > right) {
			_currentPos.x = right;
		}
	}

}
