using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureFollowPlayerRadiusTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.transform.tag == "CaptCreature") {
            if(!other.GetComponent<CaptCreature>().isInPlayerRadius)
            other.GetComponent<CaptCreature>().isInPlayerRadius = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.transform.tag == "CaptCreature") {
            if(other.GetComponent<CaptCreature>().isInPlayerRadius)
            other.GetComponent<CaptCreature>().isInPlayerRadius = false;
        }
    }
}
