using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class wildCreatureStateBase 
{
     protected wildCreatureStateBase(GameObject gameObject)
    {
        this.gameObject = gameObject;
        this.transform = gameObject.transform;
    }

    protected GameObject gameObject;
    protected Transform transform;

    public abstract Type Tick();

    public abstract void Enter();
    public abstract void Exit();
}
