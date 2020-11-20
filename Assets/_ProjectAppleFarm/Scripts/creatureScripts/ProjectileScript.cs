using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    GameObject target;
    Rigidbody rigidBody;
    // Start is called before the first frame update
    float speed = 10;
    public float damage = 50;
    void Start()
    {
        
    }
    private void Awake() {
        rigidBody = GetComponent<Rigidbody>();
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.LookAt(target.transform.position);
            rigidBody.velocity = (transform.rotation*Vector3.forward*speed);
        }
    }
    public void setTarget(GameObject _target, float _speed, float _damage)
    {
        target = _target;
        speed = _speed;
        damage = _damage;
    }
}
