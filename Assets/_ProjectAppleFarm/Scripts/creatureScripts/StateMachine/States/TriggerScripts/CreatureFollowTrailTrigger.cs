//Author : Colin
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureFollowTrailTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.transform.tag == "CaptCreature") {
            other.GetComponent<CaptCreature>().isInTrail = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.transform.tag == "CaptCreature") {
            other.GetComponent<CaptCreature>().isInTrail = false;
        }
    }
}
