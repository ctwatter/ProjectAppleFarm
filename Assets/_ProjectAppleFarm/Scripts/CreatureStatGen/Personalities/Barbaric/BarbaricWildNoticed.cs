using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BarbaricWildNoticed", menuName = "ScriptableObjects/BTSubtrees/Barbaric/WildNoticed")]
public class BarbaricWildNoticed : BTSubtree
{
    public override BTSequence BuildSequenceSubtree(CreatureAIContext context) {
        //DEFAULT BT SUBTREE
        #region WILD PLAYER

            #region wild attack enemy
                List<BTnode> AttackEnemySequenceList = new List<BTnode>();

                #region if target already exists selector
                    List<BTnode> TargetExistsSelectorList = new List<BTnode>();
                    BTCheckIfTargetExists checkIfTargetExists = new BTCheckIfTargetExists("Check if enemy already targeted", context);
                    BTActionFindTargetEnemy findTargetEnemy = new BTActionFindTargetEnemy("Find Closest Enemy in Range", context);
                    TargetExistsSelectorList.Add(checkIfTargetExists);
                    TargetExistsSelectorList.Add(findTargetEnemy);

                    BTSelector TargetExistsSelector = new BTSelector("Target Exists Selector", TargetExistsSelectorList);
                #endregion 

                #region attack selector
                    List<BTnode> AttackSelectorList = new List<BTnode>();

                    #region melee Sequence
                        List<BTnode> MeleeAbilitySequenceList = new List<BTnode>();
                        #region Melee Approach selector
                            List<BTnode> MeleeApproachSelectorList = new List<BTnode>();
                            //BTCheckDistanceToTarget checkIfDistanceToTarget = new BTCheckDistanceToTarget("Check if in range for attack", context);
                            BTActionApproachForAttack approachForAttack = new BTActionApproachForAttack("Approach for attack", context);
                            BTInverter invertApproachForAttack = new BTInverter("Invert Approach for Attack", approachForAttack);
                            BTActionAttackMelee attackMelee = new BTActionAttackMelee("Melee Attack", context);
                            //MeleeApproachSequenceList.Add(checkIfDistanceToTarget);
                            MeleeApproachSelectorList.Add(invertApproachForAttack);
                            MeleeApproachSelectorList.Add(attackMelee);
                            
                            BTSelector MeleeApproachAttackSelector = new BTSelector("Melee Approach / Attack Sequence", MeleeApproachSelectorList);
                        #endregion
                        BTCheckIfAbilityIsMelee ifAbilityIsMelee = new BTCheckIfAbilityIsMelee("check if ability is melee", context);
                            
                        MeleeAbilitySequenceList.Add(ifAbilityIsMelee);
                        MeleeAbilitySequenceList.Add(MeleeApproachAttackSelector);

                        BTSequence MeleeAbilitySequence = new BTSequence("Melee Ability Sequence", MeleeAbilitySequenceList);
                    #endregion

                    #region ranged sequence
                        List<BTnode> RangedAbilitySequenceList = new List<BTnode>();
                        #region Ranged Approach selector
                            List<BTnode> RangedApproachSelectorList = new List<BTnode>();
                            //using same invertApproachForAttack node
                            BTActionAttackRanged attackRanged = new BTActionAttackRanged("Ranged Attack", context);
                            RangedApproachSelectorList.Add(invertApproachForAttack);
                            RangedApproachSelectorList.Add(attackRanged);

                            BTSelector RangedApproachAttackSelector = new BTSelector("Ranged Approach / Attack Seelector", RangedApproachSelectorList);
                        #endregion
                        BTCheckIfAbilityIsRanged ifAbilityIsRanged = new BTCheckIfAbilityIsRanged("Check if ability is ranged", context);

                        RangedAbilitySequenceList.Add(ifAbilityIsRanged);
                        RangedAbilitySequenceList.Add(RangedApproachAttackSelector);

                        BTSequence RangedAbilitySequence = new BTSequence("Ranged Ability Sequence", RangedAbilitySequenceList);
                    #endregion

                    AttackSelectorList.Add(MeleeAbilitySequence);
                    AttackSelectorList.Add(RangedAbilitySequence);

                    BTSelector AttackSelector = new BTSelector("Attack Selector", AttackSelectorList);
                #endregion

                AttackEnemySequenceList.Add(TargetExistsSelector);
                AttackEnemySequenceList.Add(AttackSelector);

                BTSequence AttackEnemySequence = new BTSequence("Attack Enemy Sequence", AttackEnemySequenceList);


            #endregion

            #region wild approach player
                List<BTnode> WildApproachPlayerList = new List<BTnode>();
                BTActionWildApproachPlayer approachPlayer = new BTActionWildApproachPlayer("Approach Player", context);
                BTActionFollowIdle followIdle = new BTActionFollowIdle("Follow Idle", context);
                WildApproachPlayerList.Add(AttackEnemySequence);
                WildApproachPlayerList.Add(approachPlayer);
                WildApproachPlayerList.Add(followIdle);
                BTSelector approachPlayerSelector = new BTSelector("Run/Approach Player", WildApproachPlayerList);
            #endregion

            #region wild notice player
                List<BTnode> WildNoticePlayerList = new List<BTnode>();
                BTCheckWildPlayerInRadius playerNoticed = new BTCheckWildPlayerInRadius("Is Player Noticed", context);
                
                WildNoticePlayerList.Add(playerNoticed);
                WildNoticePlayerList.Add(approachPlayerSelector);
                BTSequence noticedSequence = new BTSequence("Player Is Noticed", WildNoticePlayerList);
            #endregion
        #endregion
        return noticedSequence;
    }
}
