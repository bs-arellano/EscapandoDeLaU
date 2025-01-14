using UnityEngine;

public class Llave : MonoBehaviour, Interactive
{
    PlayerInventory playerInventory;
    public Sprite inventorySprite;
    public string keyName;
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
        playerInventory.AddItem(new Item("Llave " + keyName , 1, inventorySprite));
        available = false;
        Destroy(gameObject);
    }
}
