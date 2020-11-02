using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjHit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.transform.tag == "Enemy") {
            other.GetComponent<EnemyStats>().takeDamage(gameObject.GetComponent<ProjectileScript>().damage);
            Destroy(gameObject);
        }
    }
}
