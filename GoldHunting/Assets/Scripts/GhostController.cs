/*
 * PROGRAM: COMP3064 
 * SOURCE: LAB EXAMPLE
 * ASSIGNMENT 1: GOLD HUNTING
 * AUTHOR: YUMING WU 101027496
 * LAST MODIFIED BY YUMING WU
 * DATE LAST MODIFIED: OCT 20, 2017
 * PROGRAM DESCRIPTION: GAME DEVELOPMENT
 * REVISION HISTORY: REVISION 5 TIMES
 * CODE REFFERENCE: LAB3
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// instantiate ghosts to challenge the user
public class GhostController : MonoBehaviour {

	// speed for ghost's random position
	[SerializeField] float minXSpeed = -2f; // right to left minimium speed
	[SerializeField] float maxXSpeed = 2f; // right to left maximum speed
	[SerializeField] float minYSpeed = 5f; // top down minimum speed
	[SerializeField] float maxYSpeed = 10f; // top down maximum speed

	private Transform _transform;
	private Vector2 _currentSpeed;
	private Vector2 _currentPos;

	// initializate ghost object 
	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		Reset();
	}	

	// update the position of the ghost
	// if the ghost out of the frame, create the new position
	void FixedUpdate () {
		_currentPos = _transform.position;
		_currentPos -= _currentSpeed;
		_transform.position = _currentPos;

		if (_currentPos.x <= -351) {
			Reset ();
		}
	}

	// reset the ghost by random position and speed
	public void Reset(){
		float xSpeed = Random.Range (minXSpeed, maxXSpeed);
		float ySpeed = Random.Range (minYSpeed, maxYSpeed);

		// speed itself will be 
		_currentSpeed = new Vector2 (xSpeed, ySpeed);

		float y = Random.Range(-147,147);
		// set the enemy just right out of the edge of the view board
		// the speed will be randomly between 0-100
		_transform.position = new Vector2(347 + Random.Range (0,100), y);
	}
}
