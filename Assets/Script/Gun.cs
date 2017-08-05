using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public GameObject bulletPrefab;
    public GameObject effectFogo;
    public GameObject effectFumaca;
    public Transform spawnObject;
	void Update () {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetMouseButtonDown(0))
        {
            GameObject go = Instantiate(bulletPrefab, spawnObject.position, spawnObject.rotation) as GameObject;
            GameObject fire = Instantiate(effectFogo, spawnObject.position, spawnObject.rotation) as GameObject;
            GameObject smoke = Instantiate(effectFumaca, spawnObject.position, spawnObject.rotation) as GameObject;
			go.GetComponent<Rigidbody>().AddForce(spawnObject.forward * 300,ForceMode.VelocityChange);
        }
	}
}
