using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class PlayerBaseState
{
    protected PlayerBaseState(GameObject gameObject)
    {
        this.gameObject = gameObject;
        this.transform = gameObject.transform;
    }

    protected GameObject gameObject;
    protected Transform transform;


    
    public abstract Type Tick();
    public abstract void PhysicsTick();

    public abstract void Enter();
    public abstract void Exit();

}
