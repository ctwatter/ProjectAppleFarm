using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DeceptiveFollowPlayer", menuName = "ScriptableObjects/BTSubtrees/Deceptive/FollowPlayer")]
public class DeceptiveFollowPlayer : BTSubtree
{

    public override BTSelector BuildSelectorSubtree(CreatureAIContext context) {
        #region BONDED FOLLOW PLAYER
            List<BTnode> BondedFollowPlayer = new List<BTnode>();

            #region DONT STEAL PLAYER
                List<BTnode> DontStealPlayerList = new List<BTnode>();
        
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
                
                DontStealPlayerList.Add(followPlayerIdle);
                DontStealPlayerList.Add(followPlayerTrail);
                DontStealPlayerList.Add(followPlayerSelector);
            
                BTSelector DontStealPlayerSelector = new BTSelector("Dont Steal Player", DontStealPlayerList);

            #endregion

            #region STEAL FROM PLAYER
                List<BTnode> StealFromPlayerList = new List<BTnode>();

                BTCheckShouldSteal shouldSteal = new BTCheckShouldSteal("Should Steal", context);
                BTActionSteal steal = new BTActionSteal("Steal", context);

                StealFromPlayerList.Add(shouldSteal);
                StealFromPlayerList.Add(steal);

                BTSequence stealFromPlayerSequence = new BTSequence("Steal From Player", StealFromPlayerList);
            #endregion

            BondedFollowPlayer.Add(stealFromPlayerSequence);
            BondedFollowPlayer.Add(DontStealPlayerSelector);

            BTSelector bondedFollowPlayerSelector = new BTSelector("Bonded Follow Player", BondedFollowPlayer);
        #endregion
        return bondedFollowPlayerSelector;
    }
}
