using UnityEngine;

public class Llave : MonoBehaviour, Interactive
{
    public PlayerInventory playerInventory;
    public Sprite inventorySprite;
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
        playerInventory.AddItem(new Item("llave", 1, inventorySprite));
        available = false;
        Destroy(gameObject);
    }
}
