﻿// Jake
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    Fruit(bool playerDropped){
        droppedByPlayer = playerDropped;
    }

    public bool droppedByPlayer = false;

    public void destroy(){
        Destroy(gameObject);
    }
}
