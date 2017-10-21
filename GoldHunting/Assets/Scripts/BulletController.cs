/*
 * PROGRAM: COMP3064 
 * SOURCE: LAB EXAMPLE
 * ASSIGNMENT 1: GOLD HUNTING
 * AUTHOR: YUMING WU 101027496
 * LAST MODIFIED BY YUMING WU
 * DATE LAST MODIFIED: OCT 20, 2017
 * PROGRAM DESCRIPTION: GAME DEVELOPMENT
 * REVISION HISTORY: REVISION 5 TIMES
 * CODE REFFERENCE: LAB5
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// instantiate a bullet when "space" pressed
// bullet move fast forward
// when it hits the ghost, the ghost will disappear as smoke and earn 200 points
public class BulletController : MonoBehaviour {
	
	// set the default speed to the bullet
	[SerializeField] private float speed = 7f;
	[SerializeField] GameObject bullet;

	private Transform _transform;
	private Vector2 _currentPos; 

	private AudioSource _bulletAudio;

	// initializate the bullet object
	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		_currentPos = transform.position;
		bullet = GameObject.Find ("Canvas");
	}

	// update the position of the bullet
	void FixedUpdate () {
		_currentPos = _transform.position;
		_currentPos += new Vector2 (speed, 0);
		_transform.position = _currentPos;
	}

	public void Reset(){
		Destroy (this.gameObject);
	}
}
