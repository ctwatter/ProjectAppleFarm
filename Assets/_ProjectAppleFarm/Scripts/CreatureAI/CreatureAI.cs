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

    private void Update() {
        behaviorTree.Evaluate();
        
    }


    private void FixedUpdate() {
        //behaviorTree.Evaluate();
    }
    //build the behavior tree for the creature
    private void BuildBT() 
    {
        List<BTnode> BondedFollowPlayer = new List<BTnode>();
        
        #region bonded follow idle sequence
        List<BTnode> BondedIdleFollowList = new List<BTnode>();
        BTCheckInPlayerRadius inRadius = new BTCheckInPlayerRadius("In Player Radius", context);
        BTActionFollowIdle followIdle = new BTActionFollowIdle("Follow Idle", context);
        BondedIdleFollowList.Add(inRadius);
        BondedIdleFollowList.Add(followIdle);
        BTSequence followPlayerIdle = new BTSequence("Follow Player Idle", BondedIdleFollowList);
        #endregion

        #region bonded trail player sequence
        List<BTnode> BondedTrailPlayerList = new List<BTnode>();
        BTCheckInPlayerTrail inTrail = new BTCheckInPlayerTrail("In Player Trail", context);
        BTActionTrailPlayer trailPlayer = new BTActionTrailPlayer("Trail Player", context);
        BondedTrailPlayerList.Add(inTrail);
        BondedTrailPlayerList.Add(trailPlayer);
        BTSequence followPlayerTrail = new BTSequence("Follow Player Trail", BondedTrailPlayerList);
        #endregion

        #region bonded get closer to player selector
        List<BTnode> BondedGetCloserToPlayerList = new List<BTnode>();
        BTActionFollowPlayer followPlayerAction = new BTActionFollowPlayer("Follow Player", context);
        BTActionFollowTP followPlayerTP = new BTActionFollowTP("Follow Player TP", context);
        BondedGetCloserToPlayerList.Add(followPlayerAction);
        BondedGetCloserToPlayerList.Add(followPlayerTP);
        BTSelector followPlayerSelector = new BTSelector("Get Closer To Player", BondedGetCloserToPlayerList);
        #endregion
        
        
        BondedFollowPlayer.Add(followPlayerIdle);
        BondedFollowPlayer.Add(followPlayerTrail);
        BondedFollowPlayer.Add(followPlayerSelector);

        BTSelector _root = new BTSelector("Root", BondedFollowPlayer);

        behaviorTree = _root;
    }

}
