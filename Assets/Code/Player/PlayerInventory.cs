using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerInventory : MonoBehaviour
{
    public List<Item> inventory = new();
    public void AddItem(Item item)
    {
        if (HasItem(item.name))
        {
            Item existingItem = inventory.FirstOrDefault(inventoryItem => inventoryItem.name.Equals(item.name));
            existingItem.quantity++;
        }
        else
        {
            inventory.Add(item);
        }
    }
    public bool HasItem(string name)
    {
        if (inventory.Count == 0) return false;
        return inventory.Any(inventoryItem => inventoryItem.name.Equals(name));
    }
    public int GetQuantity(string name)
    {
        if (HasItem(name))
        {
            Item existingItem = inventory.FirstOrDefault(inventoryItem => inventoryItem.name.Equals(name));
            return existingItem.quantity;
        }
        else
        {
            return 0;
        }
    }
    public void UseItem(string name, int quantity = 1)
    {
        if (HasItem(name))
        {
            Item existingItem = inventory.FirstOrDefault(inventoryItem => inventoryItem.name.Equals(name));
            existingItem.quantity -= quantity;
            if (existingItem.quantity == 0)
            {
                inventory.Remove(existingItem);
            }
        }
    }
}
