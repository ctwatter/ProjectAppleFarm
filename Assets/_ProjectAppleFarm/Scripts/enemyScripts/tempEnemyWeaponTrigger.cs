using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempEnemyWeaponTrigger : MonoBehaviour
{

    [SerializeField] private EnemyStats enemyStats;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerStats>().takeDamage(enemyStats.damage);
        }
    }
}
