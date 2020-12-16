﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "BarbaricAbility", menuName = "ScriptableObjects/BTSubtrees/Barbaric/Ability")]
public class BarbaricAbility : BTSubtree
{
    public override BTSequence BuildSequenceSubtree(CreatureAIContext context) {
        #region CREATURE ABILITIES
            #region player triggered ability sequence        
                List<BTnode> AbilityTriggeredSequenceList = new List<BTnode>();

                #region Ability Selector
                    List<BTnode> AbilitySelectorList = new List<BTnode>();
                    BTActionAbilityFail AbilityFailsafe = new BTActionAbilityFail("Ability Failsafe", context);
                    #region MeleeAbilitySequence
                        List<BTnode> MeleeAbilitySequenceList = new List<BTnode>();
                        #region if target already exists selector
                            List<BTnode> TargetExistsSelectorList = new List<BTnode>();
                            BTCheckIfTargetExists checkIfTargetExists = new BTCheckIfTargetExists("Check if enemy already targeted", context);
                            BTActionFindTargetEnemy findTargetEnemy = new BTActionFindTargetEnemy("Find Closest Enemy in Range", context);
                            TargetExistsSelectorList.Add(checkIfTargetExists);
                            TargetExistsSelectorList.Add(findTargetEnemy);

                            BTSelector TargetExistsSelector = new BTSelector("Target Exists Selector", TargetExistsSelectorList);
                        #endregion 

                        #region Approach sequence
                            List<BTnode> MeleeApproachSelectorList = new List<BTnode>();
                            //BTCheckDistanceToTarget checkIfDistanceToTarget = new BTCheckDistanceToTarget("Check if in range for attack", context);
                            BTActionApproachForAttack approachForAttack = new BTActionApproachForAttack("Approach for attack", context);
                            BTInverter invertApproachForAttack = new BTInverter("Invert Approach for Attack", approachForAttack);
                            BTActionBarbaricMeleeAttack attackMelee = new BTActionBarbaricMeleeAttack("Barbaric Melee Attack", context);
                            //MeleeApproachSequenceList.Add(checkIfDistanceToTarget);
                            MeleeApproachSelectorList.Add(invertApproachForAttack);
                            MeleeApproachSelectorList.Add(attackMelee);
                            
                            BTSelector MeleeApproachAttackSelector = new BTSelector("Melee Approach / Attack Sequence", MeleeApproachSelectorList);
                        #endregion


                        BTCheckIfAbilityIsMelee ifAbilityIsMelee = new BTCheckIfAbilityIsMelee("check if ability is melee", context);
                        
                        MeleeAbilitySequenceList.Add(ifAbilityIsMelee);
                        MeleeAbilitySequenceList.Add(TargetExistsSelector);
                        MeleeAbilitySequenceList.Add(MeleeApproachAttackSelector);
                        //MeleeAbilitySequenceList.Add(MeleeAttackSequence);
                        //MeleeAbilitySequenceList.Add(AbilityFailsafe);
                        BTSequence MeleeAbilitySequence = new BTSequence("Melee Ability Sequence", MeleeAbilitySequenceList);

                    #endregion

                    #region RangedAbilitySequence
                        List<BTnode> RangedAbilitySequenceList = new List<BTnode>();
                        #region if target already exists selector
                            //using same targetExistsSelector from melee
                        #endregion 

                        #region Approach/Attack sequence
                            List<BTnode> RangedApproachSelectorList = new List<BTnode>();
                            //using same invertApproachForAttack node
                            BTActionBarbaricRangedAttack attackRanged = new BTActionBarbaricRangedAttack("Barbaric Ranged Attack", context);
                            RangedApproachSelectorList.Add(invertApproachForAttack);
                            RangedApproachSelectorList.Add(attackRanged);

                            BTSelector RangedApproachAttackSelector = new BTSelector("Ranged Approach / Attack Seelector", RangedApproachSelectorList);
                        #endregion
                        BTCheckIfAbilityIsRanged ifAbilityIsRanged = new BTCheckIfAbilityIsRanged("Check if ability is ranged", context);

                        RangedAbilitySequenceList.Add(ifAbilityIsRanged);
                        RangedAbilitySequenceList.Add(TargetExistsSelector);
                        RangedAbilitySequenceList.Add(RangedApproachAttackSelector);

                        BTSequence RangedAbilitySequence = new BTSequence("Ranged Ability Sequence", RangedAbilitySequenceList);
                    #endregion

                    #region UtilityAbilitySequence
                        List<BTnode> UtilityAblitySequenceList = new List<BTnode>();

                        BTCheckIfAbilityIsUtility ifAbilityIsUtility = new BTCheckIfAbilityIsUtility("Check if ability is utility", context);
                        //MAKE UTILITY ABLITY CAST

                        UtilityAblitySequenceList.Add(ifAbilityIsUtility);
                        //add action

                        BTSequence UtilityAbilitySequence = new BTSequence("Utility Ability Sequence", UtilityAblitySequenceList);

                        
                    #endregion
                    
                    AbilitySelectorList.Add(MeleeAbilitySequence);
                    AbilitySelectorList.Add(RangedAbilitySequence);
                    //AbilitySelectorList.Add(UtilityAbilitySequence);
                    AbilitySelectorList.Add(AbilityFailsafe);

                    BTSelector AbilitySelector = new BTSelector("Ability Selector", AbilitySelectorList);
                #endregion
                BTCheckPlayerTriggeredAbility ifPlayerTriggeredAbility = new BTCheckPlayerTriggeredAbility("if player triggered ability", context);
                AbilityTriggeredSequenceList.Add(ifPlayerTriggeredAbility);
                AbilityTriggeredSequenceList.Add(AbilitySelector);

                BTSequence AbilityTriggeredSequence = new BTSequence("Ability Triggered Sequence", AbilityTriggeredSequenceList);
            #endregion
        #endregion
        return AbilityTriggeredSequence;
    }
}
