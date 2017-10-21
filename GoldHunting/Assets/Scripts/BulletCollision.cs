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

public class BulletCollision : MonoBehaviour {
	
	[SerializeField] GameObject smoke = null;

	private AudioSource _bulletAudio;

	// when want to use the function to enter the trigger
	public void OnTriggerEnter2D(Collider2D other){	// collider2D is the reference to other collider to this object
		// when the object hit the enemy, smokes, gain points and enemy disappear
		if (other.gameObject.tag.Equals ("enemy")) {
			
			// the smoke animation applied 
			Instantiate(smoke).GetComponent<Transform>().position
			= other.gameObject.transform.position;
			_bulletAudio = other.gameObject.GetComponent<AudioSource> ();
			if (_bulletAudio != null) {
				_bulletAudio.Play ();
			}
			// gain 200 points
			Player.Instance.Point += 200;		
			// ghost and bullet both disappear when they hitten
			gameObject.GetComponent<BulletController> ().Reset ();	
			other.gameObject.GetComponent<GhostController> ().Reset ();
		} 
	}		
}
