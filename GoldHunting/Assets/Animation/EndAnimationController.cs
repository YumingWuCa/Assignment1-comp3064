using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAnimationController : MonoBehaviour {
	// to stop the animation non stop active
	void End () {
		Destroy (gameObject);
	}	
}
