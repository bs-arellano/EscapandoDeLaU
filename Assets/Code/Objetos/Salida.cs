using UnityEngine;
using UnityEngine.SceneManagement;
public class Salida : MonoBehaviour, Interactive
{
    public PlayerInventory playerInventory;
    bool available;
    AudioSource audioSource;
    public AudioClip doorLocked;
    bool Interactive.active
    {
        get
        {
            return available;
        }
    }
    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
            audioSource.PlayOneShot(doorLocked);
            Debug.Log("No tiene llave");
        }
    }
}
