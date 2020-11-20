using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Items/Fruit", fileName = "FruitName.asset")]
public class Fruits : Item
{
    public enum FruitType {
        Fragaria, Creature2, Creature3, Creature4
    }

    public FruitType fruitType;
}
