using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llave : MonoBehaviour, Interactive
{
    public PlayerInventory playerInventory;
    bool available;
    bool Interactive.active
    {
        get
        {
            return available;
        }
    }
    public void Start()
    {
        playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
        available = true;
    }
    public void Interact()
    {
        playerInventory.AddItem(new Item("llave", 1));
        Destroy(gameObject);
    }
}
