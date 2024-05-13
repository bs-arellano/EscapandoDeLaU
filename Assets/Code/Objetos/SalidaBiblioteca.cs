using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SalidaBiblioteca : MonoBehaviour, Interactive
{
    PlayerInventory playerInventory;
    public string keyName;
    bool available;
    AudioSource audioSource;
    public AudioClip doorLocked;
    public AudioClip doorOpen;
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
        if (playerInventory.HasItem(keyName))
        {
            playerInventory.UseItem(keyName);
            audioSource.PlayOneShot(doorOpen);
            StartCoroutine(Wait(0.7f, () =>
            {
                GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<TimeManager>().SaveTime();
                GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Camara>().ShowCursor();
                SceneManager.LoadScene("Salones");
            }));
        }
        else
        {
            audioSource.PlayOneShot(doorLocked);
            Debug.Log("No tiene llave");
        }
    }
    IEnumerator Wait(float seconds, System.Action callback)
    {
        yield return new WaitForSeconds(seconds);
        callback?.Invoke();
    }
}
