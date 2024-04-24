using UnityEngine;
using UnityEngine.SceneManagement;
public class Salida : MonoBehaviour, Interactive
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
        if (playerInventory.HasItem("llave"))
        {
            playerInventory.UseItem("llave");
            GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Camara>().ShowCursor();
            SceneManager.LoadScene("Salones");
        }
        else
        {
            Debug.Log("No tiene llave");
        }
    }
}
