using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Eugene

public class PlayerInventory : ScriptableObject 
{
    public ItemDatabase inventory;
    void AddItem (Item item) 
    {
        inventory.itemList.Add (item);
    }
    
    void DeleteItem (string name) 
    {
        inventory.itemList.RemoveAll(x => x.itemName == name);
    }
}