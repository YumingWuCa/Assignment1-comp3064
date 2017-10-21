/*
 * PROGRAM: COMP3064 
 * SOURCE: LAB EXAMPLE
 * ASSIGNMENT 1: GOLD HUNTING
 * AUTHOR: YUMING WU 101027496
 * LAST MODIFIED BY YUMING WU
 * DATE LAST MODIFIED: OCT 20, 2017
 * PROGRAM DESCRIPTION: GAME DEVELOPMENT
 * REVISION HISTORY: REVISION 1 TIMES
 * CODE REFFERENCE: LAB2
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// create a background for the scene
public class FloorController : MonoBehaviour { 
	[SerializeField] private float speed = 5f; //the speed of the background
	// set up the start point and end point on unity for the background
	[SerializeField] private float startX = 311; 
	[SerializeField] private float endX = -335; 

	// to access the transform: keep track of the position and scale
	private Transform _transform;
	private Vector2 _currentPos; // track x, y position

	// initialize the beginning
	void Start () {
		_transform = gameObject.GetComponent<Transform>();
 		_currentPos = _transform.position; 
		Reset();
	}
	
	// Update the position of the background 
	void Update () {
		_currentPos = _transform.position; 
		_currentPos -= new Vector2 (speed, 0); 
		// if on the left edge, then reset it
		if (_currentPos.x < endX){  
			Reset();
		}

		// apply changes
		_transform.position = _currentPos;
	}

	// apply changes to the background
	private void Reset(){
		_currentPos = new Vector2 (startX, 0); 
	}

}
