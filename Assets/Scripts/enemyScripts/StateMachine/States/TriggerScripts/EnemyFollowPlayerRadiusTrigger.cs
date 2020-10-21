//Author: Jake
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayerRadiusTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.transform.tag == "Enemy") {
            if(!other.GetComponent<Enemy>().isInPlayerRadius)
            other.GetComponent<Enemy>().isInPlayerRadius = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.transform.tag == "Enemy") {
            if(other.GetComponent<Enemy>().isInPlayerRadius)
            other.GetComponent<Enemy>().isInPlayerRadius = false;
        }
    }
}
