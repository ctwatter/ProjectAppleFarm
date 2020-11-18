using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorTree : MonoBehaviour
{
    string _name;

    // Start is called before the first frame update
    void Start(string name)
    {
        _name = name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual bool Execute() {
        return true;
    }
}
