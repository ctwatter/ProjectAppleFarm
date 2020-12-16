using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creatureAnimator : MonoBehaviour
{
    public GameObject model;
    public Animator animator => model.GetComponent<Animator>();

}
