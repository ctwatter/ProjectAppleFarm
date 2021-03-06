﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wild_creature_interact : MonoBehaviour
{
    public GameObject wildCreature;
    Collider collider;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake() {
        collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.transform.tag == "Player") {
            other.GetComponent<PlayerController>().nearInteractable = true;
            other.GetComponent<PlayerController>().wildCreature = wildCreature;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.transform.tag == "Player") {
            other.GetComponent<PlayerController>().nearInteractable = false;
            other.GetComponent<PlayerController>().wildCreature = null;
        }   
    }
}
