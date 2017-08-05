using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class balcaoScript : MonoBehaviour, ITrackableEventHandler {

	public GameObject pino;
	public Transform spawnPinoL;
	public Transform spawnPinoR;

	private  List<GameObject> pinos;

	private TrackableBehaviour myTrack;

	// Use this for initialization
	void Start () {
		pinos = new List<GameObject> ();

		myTrack = GetComponent<TrackableBehaviour> ();
		if (myTrack)
			myTrack.RegisterTrackableEventHandler (this);
	}

	public void OnTrackableStateChanged( TrackableBehaviour.Status oldS, TrackableBehaviour.Status newS ){
		if ( newS == TrackableBehaviour.Status.DETECTED ||
		     newS == TrackableBehaviour.Status.TRACKED ||
		     newS == TrackableBehaviour.Status.EXTENDED_TRACKED) {
			if (pinos.Count < 4) {
				float xSpawn = spawnPinoL.transform.position.x;
				float length = Mathf.Abs(spawnPinoL.transform.position.x - spawnPinoR.transform.position.x);

				for (int i = 0; i < 4; i++) {
					pinos.Add (Instantiate<GameObject> (pino, 
						new Vector3 (xSpawn + i * length/3, spawnPinoL.transform.position.y + 2.0f, spawnPinoL.transform.position.z),
						Quaternion.identity,
						this.transform.GetChild(0)));
					pinos [i].transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

				}
			}
		} else {
			foreach (var p in pinos) {
				Destroy (p);
			}
			pinos.Clear();
		}
	}

	// Update is called once per frame
	void Update() {
	}
}
