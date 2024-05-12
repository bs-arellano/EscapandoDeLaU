using UnityEngine;

public class Item
{
    public string name;
    public int quantity;
    public Sprite image;
    public Item(string name, int quantity, Sprite image)
    {
        this.name = name;
        this.quantity = quantity;
        this.image = image;
    }
}