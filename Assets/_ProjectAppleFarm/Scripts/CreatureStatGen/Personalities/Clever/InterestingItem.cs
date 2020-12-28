//Enrico

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterestingItem : MonoBehaviour
{

    public GameObject item;
    Collider collider;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake() {
        collider = GetComponent<Collider>();
        //item = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.transform.tag == "Player") {
            other.GetComponent<PlayerController>().nearInteractable = true;
            other.GetComponent<PlayerController>().interactableObject = item;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.transform.tag == "Player") {
            other.GetComponent<PlayerController>().nearInteractable = false;
            other.GetComponent<PlayerController>().interactableObject = null;
        }   
    }
}
