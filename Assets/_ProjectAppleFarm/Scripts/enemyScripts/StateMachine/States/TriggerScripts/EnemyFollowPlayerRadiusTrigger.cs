//Author: Jake
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayerRadiusTrigger : MonoBehaviour
{
    public bool isPlayerInRadius = false;
    private void OnTriggerEnter(Collider other) {
        if(other.transform.tag == "Player") {
            isPlayerInRadius = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.transform.tag == "Player") {
            isPlayerInRadius = false;
        }
    }
}
