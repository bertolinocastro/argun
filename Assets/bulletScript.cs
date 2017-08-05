using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if( transform.position.z > 1000.0f || transform.position.y < -100.0f || 
			transform.position.x < -200.0f || transform.position.x > 200.0f )
			Destroy(gameObject);
			
			
			/*
		if (p.transform.localPosition.x > 40.0f || p.transform.localPosition.z > 15.0f
			|| p.transform.localPosition.z < -15.0f || p.transform.localPosition.y < - 20.0f) {*/
	}
}
