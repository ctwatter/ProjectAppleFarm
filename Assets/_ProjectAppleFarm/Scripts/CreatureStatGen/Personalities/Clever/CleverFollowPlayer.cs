using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CleverFollowPlayer", menuName = "ScriptableObjects/BTSubtrees/Clever/FollowPlayer")]
public class CleverFollowPlayer : BTSubtree
{

    public override BTSelector BuildSelectorSubtree(CreatureAIContext context) {
        #region BONDED FOLLOW PLAYER
            List<BTnode> BondedFollowPlayer = new List<BTnode>();
        
            #region bonded clever sequence
                List<BTnode> BondedCleverSequenceList = new List<BTnode>();
                BTActionFindInterestingItem findItem = new BTActionFindInterestingItem("Check For Items", context);
                BTActionApproachItem approachItem = new BTActionApproachItem("Approach Item", context);
                BTActionItemAlertPlayer alertPlayer = new BTActionItemAlertPlayer("Alert Player", context);
                BondedCleverSequenceList.Add(findItem);
                BondedCleverSequenceList.Add(approachItem);
                BondedCleverSequenceList.Add(alertPlayer);
                BTSequence bondedClever = new BTSequence("Bonded Clever", BondedCleverSequenceList);
            #endregion

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
            
            BondedFollowPlayer.Add(bondedClever);
            BondedFollowPlayer.Add(followPlayerIdle);
            BondedFollowPlayer.Add(followPlayerTrail);
            BondedFollowPlayer.Add(followPlayerSelector);

            BTSelector bondedFollowPlayerSelector = new BTSelector("Bonded Follow Player", BondedFollowPlayer);
        #endregion
        return bondedFollowPlayerSelector;
    }
}
