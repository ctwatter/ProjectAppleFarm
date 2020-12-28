﻿// Jake
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HeartyFollowPlayer", menuName = "ScriptableObjects/BTSubtrees/Hearty/HeartyFollowPlayer")]
public class HeartyFollowPlayer : BTSubtree
{
    public override BTSelector BuildSelectorSubtree(CreatureAIContext context) {
        #region BONDED FOLLOW PLAYER
            List<BTNode> BondedFollowPlayer = new List<BTNode>();
        
            #region get food sequence
                List<BTNode> findFoodList = new List<BTNode>();
                HeartyBTCheckWildFindFood findFood = new HeartyBTCheckWildFindFood("Find Food", context);
                HeartyBTActionWildApproachFood goEatFood = new HeartyBTActionWildApproachFood("Go eat food", context);
                findFoodList.Add(findFood);
                findFoodList.Add(goEatFood);
                BTSequence followGetFoodSequence = new BTSequence("Follow Get Food", findFoodList);
            #endregion

            #region bonded follow idle sequence
                List<BTNode> BondedIdleFollowList = new List<BTNode>();
                BTCheckInPlayerRadius inRadius = new BTCheckInPlayerRadius("In Player Radius", context);
                BTActionFollowIdle followIdle = new BTActionFollowIdle("Follow Idle", context);
                BondedIdleFollowList.Add(inRadius);
                BondedIdleFollowList.Add(followIdle);
                BTSequence followPlayerIdle = new BTSequence("Follow Player Idle", BondedIdleFollowList);
            #endregion

            #region bonded trail player sequence
                List<BTNode> BondedTrailPlayerList = new List<BTNode>();
                BTCheckInPlayerTrail inTrail = new BTCheckInPlayerTrail("In Player Trail", context);
                BTActionTrailPlayer trailPlayer = new BTActionTrailPlayer("Trail Player", context);
                BondedTrailPlayerList.Add(inTrail);
                BondedTrailPlayerList.Add(trailPlayer);
                BTSequence followPlayerTrail = new BTSequence("Follow Player Trail", BondedTrailPlayerList);
            #endregion
            
            #region bonded get closer to player selector
                List<BTNode> BondedGetCloserToPlayerList = new List<BTNode>();
                BTActionFollowPlayer followPlayerAction = new BTActionFollowPlayer("Follow Player", context);
                BTActionFollowTP followPlayerTP = new BTActionFollowTP("Follow Player TP", context);
                BondedGetCloserToPlayerList.Add(followPlayerAction);
                BondedGetCloserToPlayerList.Add(followPlayerTP);
                BTSelector followPlayerSelector = new BTSelector("Get Closer To Player", BondedGetCloserToPlayerList);
            #endregion
            
            BondedFollowPlayer.Add(followGetFoodSequence);
            BondedFollowPlayer.Add(followPlayerIdle);
            BondedFollowPlayer.Add(followPlayerTrail);
            BondedFollowPlayer.Add(followPlayerSelector);

            BTSelector bondedFollowPlayerSelector = new BTSelector("Bonded Follow Player", BondedFollowPlayer);
        #endregion
        return bondedFollowPlayerSelector;
    }
}
