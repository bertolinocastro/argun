using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balcaoScript : MonoBehaviour {

	public GameObject pino;
	public Transform spawnPino;

	private  List<GameObject> pinos;

	// Use this for initialization
	void Start () {
		pinos = new List<GameObject> ();
	}
	
	// Update is called once per frame
	void Update() {
		
		if (this.gameObject.activeSelf && pinos.Count == 0) {
			float xSpawn = spawnPino.transform.position.x;
			float balcWidth = this.transform.localScale.x;


			for(int i = 0; i < 4; i++ ){
				pinos.Add (Instantiate<GameObject> (pino, 
					new Vector3 (xSpawn + i * 45.0f, spawnPino.transform.position.y + 20.0f, spawnPino.transform.position.z),
					Quaternion.identity,
				this.transform));
			}
		} else {
			pinos.Clear();
		}
	}
}
