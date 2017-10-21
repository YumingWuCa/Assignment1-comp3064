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

public class CoinController : MonoBehaviour {

	// set min and max speed for the coin
	[SerializeField] float minXSpeed = -2f;
	[SerializeField] float maxXSpeed = 2f;
	[SerializeField] float minYSpeed = 3f;
	[SerializeField] float maxYSpeed = 8f;

	private Transform _transform;
	private Vector2 _currentSpeed;
	private Vector2 _currentPos;

	// initialize the coin
	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		Reset();
	}	

	// update the bullet box position
	// if coin out of the frame, recreate it
	void Update () {
		_currentPos = _transform.position;
		_currentPos -= _currentSpeed;
		_transform.position = _currentPos;

		if (_currentPos.x <= -351) {
			Reset();
		}
	}

	// create new coin to the frame with different position and speed
	public void Reset(){
		float xSpeed = Random.Range (minXSpeed, maxXSpeed);
		float ySpeed = Random.Range (minYSpeed, maxYSpeed);

		_currentSpeed = new Vector2 (xSpeed, ySpeed);

		float y = Random.Range(-147,147);
		// create a new coin at the beginning of the frame and apply some delay to it
		_transform.position = new Vector2(347 + Random.Range(0,500), y);
	}
}
