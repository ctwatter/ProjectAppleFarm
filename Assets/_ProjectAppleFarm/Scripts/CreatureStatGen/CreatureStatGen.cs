//COLIN
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureStatGen : MonoBehaviour
{


    public Vector2 lifeRange = new Vector2(100, 150);

    public Vector2 powerRange = new Vector2(5,20);
    //not sure what these two will be called yet, but I think 3 stats is good
    public Vector2 utilityRange = new Vector2(5, 20); 
    public Vector2 dexterityRange = new Vector2(10, 30); //dexterity is place holder??

    public float power;
    public float utility;
    public float dexterity;

    List<personality> finalPersonalities = new List<personality>();

    List<personality> PowerPersonalities = new List<personality>();
    List<personality> UtilityPersonalities = new List<personality>();
    List<personality> DexterityPersonalities = new List<personality>();
    
    //personality example. make a bunch of these, put them all in a list and do some logic :)
                                //personality( _name, _statModType, _basePercentage, _maxPercentage, _statModifierAmount ){
    personality Adventurous = new personality("Adventurous", statModifierType.POWER, 0.1f, 0.4f, 1.1f); //could pre write out all personalities we like
    
    void rollStats(){
        power = Random.Range(powerRange.x, powerRange.y);
    }

    void initPersonalities(){
        PowerPersonalities.Add(Adventurous);
    }

    void choosePersonalities(){
        foreach (personality personality in PowerPersonalities) {
            if(personality.calcChance(power, powerRange.x, powerRange.y)) {
                finalPersonalities.Add(personality);
                break;
            }
        }
        foreach (personality personality in UtilityPersonalities) {
            if(personality.calcChance(power, powerRange.x, powerRange.y)) {
                finalPersonalities.Add(personality);
                break;
            }
        }
        foreach (personality personality in DexterityPersonalities) {
            if(personality.calcChance(power, powerRange.x, powerRange.y)) {
                finalPersonalities.Add(personality);
                break;
            }
        }
    }

}


public class personality {


    public string personalityName; //personality name
    public statModifierType statModType; //the stat that this personality will modify
    public float basePercentage; //base chance that a creature can roll this personality
    public float maxPercentage;
    public float statModifierAmount; // amount that this personality affects the stat.

    public personality(string _name, statModifierType _statModType, float _basePercentage, float _maxPercentage, float _statModifierAmount ){
        personalityName = _name;
        statModType = _statModType;
        basePercentage = _basePercentage;
        maxPercentage = _maxPercentage;
        statModifierAmount = _statModifierAmount;
    }

    public bool calcChance(float roll, float minRoll, float MaxRoll) {
        float chance = linearMap(roll, minRoll, MaxRoll, basePercentage, maxPercentage);
        if (chance < Random.Range(0f,1f)){
            return true;
        } else {
            return false;
        }
    }

    public float linearMap(float value, float inputLow, float inputHigh, float outputLow, float outputHigh) {
        return outputLow + (outputHigh - outputLow) * (value - inputLow) / (inputHigh - inputLow);
    }
}

public enum statModifierType {
    POWER, UTILITY, DEXTERITY
}