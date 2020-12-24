// Jake
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTriggers : MonoBehaviour
{
    private PlayerStats playerStats;
    private PlayerStateMachine playerStateMachine;
    // Start is called before the first frame update
   private void Start() {
       playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
       playerStateMachine = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStateMachine>();
   }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Enemy")
        {
            // Check which attack state we're in to determine damage
            if(playerStateMachine.currentState is BasicHitState_0){
                other.gameObject.GetComponent<EnemyStats>().takeDamage(playerStats.attack1Damage);
            } else if(playerStateMachine.currentState is BasicHitState_1){
                other.gameObject.GetComponent<EnemyStats>().takeDamage(playerStats.attack2Damage);
            } else if(playerStateMachine.currentState is BasicHitState_2){
                other.gameObject.GetComponent<EnemyStats>().takeDamage(playerStats.attack3Damage);
            } else{
                Debug.Log("Default Damage");
                other.gameObject.GetComponent<EnemyStats>().takeDamage(playerStats.attack1Damage);
            }
        } else if(other.gameObject.tag == "FruitTree"){
            print("Hit tree with sword");
            other.gameObject.GetComponent<FruitTree>().dropFruit();
        }
    }
}
