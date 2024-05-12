using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    public List<Item> inventory;
    public Image displayedItemSprite;
    public TextMeshProUGUI displayedItemName;
    private int itemSelected = 0;
    void Start()
    {
        inventory = new();
        displayedItemName.gameObject.SetActive(false);
        displayedItemSprite.gameObject.SetActive(false);
    }
    void Update()
    {
        if (inventory.Count == 0)
        {
            itemSelected = 0;
        }
        // Use the mouse wheel to change the selected item from 0 to inventory.Count - 1
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            itemSelected = (itemSelected + 1) % inventory.Count;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            itemSelected = (itemSelected - 1 + inventory.Count) % inventory.Count;
        }
        if (inventory.Count > 0)
        {
            displayedItemName.text = inventory[itemSelected].name;
            displayedItemName.gameObject.SetActive(true);
            displayedItemSprite.sprite = inventory[itemSelected].image;
            displayedItemSprite.gameObject.SetActive(true);
        }
        else
        {
            displayedItemName.text = "";
            displayedItemName.gameObject.SetActive(false);
            displayedItemSprite.sprite = null;
            displayedItemSprite.gameObject.SetActive(false);
        }
    }
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
