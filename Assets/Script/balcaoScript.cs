using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class balcaoScript : MonoBehaviour {

	public GameObject pino;
	public Transform spawnPinoL;
	public Transform spawnPinoR;

	private  List<GameObject> pinos;
	private List<Vector3> pinosPos;
	private Quaternion balcaoRotInit;

	// Use this for initialization
	void Start () {

		// Travando rotacao
		//transform.GetComponent<Rigidbody>().freezeRotation = true;
		balcaoRotInit = transform.GetChild(0).transform.rotation;

		pinos = new List<GameObject> ();
		pinosPos = new List<Vector3> ();

		float xSpawn = spawnPinoL.transform.position.x;
		float length = Mathf.Abs(spawnPinoL.transform.position.x - spawnPinoR.transform.position.x);


		for (int i = 0; i < 4; i++) {
			pinosPos.Add (new Vector3 (xSpawn + i * length / 3, spawnPinoL.transform.position.y + 5.0f, spawnPinoL.transform.position.z));

			pinos.Add (Instantiate<GameObject> (pino, 
				pinosPos[i],
				Quaternion.identity,
				this.transform.GetChild (0)));
			pinos [i].transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
		}
	}

	// Update is called once per frame
	void Update() {

		transform.GetChild (0).transform.rotation = balcaoRotInit;

		float xSpawn = spawnPinoL.transform.position.x;
		float length = Mathf.Abs(spawnPinoL.transform.position.x - spawnPinoR.transform.position.x);

		int i = 0; 
		foreach (var p in pinos) {
			if (p.transform.localPosition.x > 40.0f || p.transform.localPosition.z > 15.0f || p.transform.localPosition.z < -15.0f || p.transform.localPosition.y < - 20.0f) {
				//p.transform.position = transform.GetChild (0).transform.GetChild (0).position + new Vector3( pinosPos [i].x, 0, 0 );
				p.transform.position = new Vector3 (xSpawn + i * length / 3, spawnPinoL.transform.position.y + 5.0f, spawnPinoL.transform.position.z);
				p.transform.rotation = Quaternion.identity;
				p.GetComponent<Rigidbody> ().velocity = Vector3.zero;
				p.GetComponent<Rigidbody> ().angularVelocity= Vector3.zero;
			}
			i++;
		}
	}
}
