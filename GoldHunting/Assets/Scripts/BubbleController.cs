/*
 * PROGRAM: COMP3064 
 * SOURCE: LAB EXAMPLE
 * ASSIGNMENT 1: GOLD HUNTING
 * AUTHOR: YUMING WU 101027496
 * LAST MODIFIED BY YUMING WU
 * DATE LAST MODIFIED: OCT 20, 2017
 * PROGRAM DESCRIPTION: GAME DEVELOPMENT
 * REVISION HISTORY: NO REVISION
 * CODE REFFERENCE: LAB2
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// for the background
public class BubbleController : MonoBehaviour {

	// create min and max speed for the coin
	[SerializeField] float speed = 10f;
	[SerializeField] float startX = -351;
	[SerializeField] float endX = 351;
	[SerializeField] float startY = -147;
	[SerializeField] float endY = 147;

	private Transform _transform;
	private Vector2 _currentPos;

	// initialize the bulbble position
	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		_currentPos = _transform.position;
		Reset ();
	}	

	// update the position
	void Update () {
		_currentPos = _transform.position;
		_currentPos -= new Vector2 (speed, 0);
		if (_currentPos.x < endX) {
			Reset();
		}
		// apply changes
		_transform.position = _currentPos;
	}

	// reset the position to a specific range
	public void Reset(){
		float y = Random.Range (startY, endY);
		float dx = Random.Range (0, 1000);
		_currentPos = new Vector2 (startX + dx, y);
	}
}
