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

public class DiverCollision : MonoBehaviour {
	[SerializeField] GameController gameController;
	[SerializeField] GameObject blood = null;

	private AudioSource _coinAudio;
	private AudioSource _ghostAudio;
	private AudioSource _bulletBoxAudio;

	// inilizate different collision audios to the scene
	void Start(){
		_coinAudio = GetComponent<AudioSource> ();
		_ghostAudio = GetComponent<AudioSource> ();
		_bulletBoxAudio = GetComponent<AudioSource> ();
	}

	// when diver hit the ghost, diver lost life 
	// hit the coin earn points
	// hit the bulletbox earn life 
	// wehn diver hit each of the other object different audio affects 
	public void OnTriggerEnter2D(Collider2D other){	
		// when the object hit the enemy, the blood animation appeared, player lost life 	
		if (other.gameObject.tag.Equals ("enemy")) {
			_ghostAudio = other.gameObject.GetComponent<AudioSource> ();
			if (_ghostAudio != null) {
				_ghostAudio.Play ();
			}
			GameObject b = Instantiate(blood);
			b.transform.position = other.gameObject.transform.position;
			Player.Instance.Life--;
		} else if (other.gameObject.tag.Equals ("coin")) {
			_coinAudio = other.gameObject.GetComponent<AudioSource> ();
			if (_coinAudio != null) {
				_coinAudio.Play ();
			}
			Player.Instance.Point += 100; 
			other.gameObject.GetComponent<CoinController> ().Reset ();
		}else if (other.gameObject.tag.Equals ("bulletbox")) {
			_bulletBoxAudio = other.gameObject.GetComponent<AudioSource> ();
			if (_bulletBoxAudio != null) {
				_bulletBoxAudio.Play ();
			}
			Player.Instance.Life++;
			other.gameObject.GetComponent<BulletboxController> (). Reset();
		}
	}
}
