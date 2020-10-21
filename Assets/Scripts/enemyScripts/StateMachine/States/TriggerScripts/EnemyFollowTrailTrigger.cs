//Author : Jake
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowTrailTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.transform.tag == "Enemy") {
            other.GetComponent<Enemy>().isInTrail = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.transform.tag == "Enemy") {
            other.GetComponent<Enemy>().isInTrail = false;
        }
    }
}
