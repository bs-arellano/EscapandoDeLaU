using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuertaBanos : MonoBehaviour, Interactive
{
    PlayerInventory playerInventory;
    public string keyName;
    public float rotation;
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
        if (playerInventory.HasItem(keyName))
        {
            playerInventory.UseItem(keyName);
            transform.Rotate(0,0,rotation);
        }
    }
}

