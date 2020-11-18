using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CreatureAIContext : MonoBehaviour
{
    #region Behavior Tree Context

    public GameObject player;
    public GameObject target;
    public Transform creatureTransform;
    public bool isWild;

    #endregion


    private void OnAwake()
    {
        creatureTransform = transform;
    }
}
