using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureAI : MonoBehaviour
{
    public BTnode behaviorTree;
    private CreatureAIContext context;

    private void Start()
    {
        context = GetComponent<CreatureAIContext>();
        BuildBT();
    }

    //build the behavior tree for the creature
    private void BuildBT() 
    {
        List<BTnode> dummy = new List<BTnode>();

        BTSelector _root = new BTSelector("Root", dummy);

        behaviorTree = _root;
    }
}
