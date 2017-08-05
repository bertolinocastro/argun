using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ReadTarget : MonoBehaviour,ITrackableEventHandler
{    
    public GameObject coluna;
    public Transform spawnColuna;
    private TrackableBehaviour mTrackableBehaviour;

    void start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
            Debug.Log("Start");
        }
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus,TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED || newStatus == TrackableBehaviour.Status.TRACKED || newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            GameObject go = Instantiate(coluna, spawnColuna.position, spawnColuna.rotation) as GameObject;
            Debug.Log("Objeto traqueiado");
        }
    }
}
