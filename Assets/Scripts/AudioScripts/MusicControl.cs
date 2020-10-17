using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    public Transform player;
    public Transform enemy;

    private float distance;

    FMODUnity.StudioEventEmitter musicEvent;

    // Start is called before the first frame update
    void Start()
    {
        musicEvent = GetComponent<FMODUnity.StudioEventEmitter>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = (player.position - enemy.position).magnitude;
        Debug.Log(2/distance);
        musicEvent.SetParameter("ThreatLevel", 2/distance);
    }
}
