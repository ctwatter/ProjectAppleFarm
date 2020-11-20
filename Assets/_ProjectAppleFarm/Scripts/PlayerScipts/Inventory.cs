using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Eugene

[System.Serializable] 
public class Inventory : ScriptableObject
{
    private void Start() {
        {
            //manually add items to inventory in beginninng?
        }
    }

    public List<InventorySlot> inventory = new List<InventorySlot>();
    public void AddItem (Item _item)
    {
        inventory.Add(new InventorySlot(_item));
    }

}

[System.Serializable] 
public class InventorySlot
{
    public Item item;
    public InventorySlot(Item _item) {
        {
            item = _item;
        }
    }
}