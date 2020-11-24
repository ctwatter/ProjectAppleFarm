using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Eugene

[System.Serializable] 
public class Inventory : ScriptableObject
{
    public int index;
    private void Start() {
        {
            //manually add items to inventory in beginninng?
        }
    }

    public ItemDatabase inventory = new ItemDatabase();

    void AddItem (Item item) 
    {
        inventory.itemList.Add (item);
        index = inventory.itemList.Count;
    }
    
    void DeleteItem (int index) 
    {
        inventory.itemList.RemoveAt (index);
    }
    void DeleteItem (string itemName) 
    {
        inventory.itemList.RemoveAll(p => p.itemName == itemName);
    }

}



// [System.Serializable] 
// public class InventorySlot
// {
//     public Item item;
//     public InventorySlot(Item _item) {
//         {
//             item = _item;
//         }
//     }
// }