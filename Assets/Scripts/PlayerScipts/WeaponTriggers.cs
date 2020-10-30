using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTriggers : MonoBehaviour
{
    private PlayerStats playerStats;
    // Start is called before the first frame update
   private void Start() {
       playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
   }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyStats>().CurrHealth -= playerStats.damage;
            if(other.gameObject.GetComponent<EnemyStats>().CurrHealth <= 0)
            {
                Destroy(other.gameObject);
            }
            {

            }
        }
    }
}
