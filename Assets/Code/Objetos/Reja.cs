using System.Collections;
using UnityEngine;

public class Reja : MonoBehaviour, Interactive
{
    bool moved;
    PlayerInventory playerInventory;
    public string keyName;
    Vector3 startPosition;
    Vector3 targetPosition;
    float elapsedTime = 0f;
    bool Interactive.active
    {
        get
        {
            return !moved;
        }
    }
    void Start()
    {
        moved = false;
        playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
    }
    public void Interact()
    {   
        if (!moved && playerInventory.HasItem(keyName))
        {
            playerInventory.UseItem(keyName);
            startPosition = transform.position;
            targetPosition = transform.position - new Vector3(0, 3, 0);
            //transform.GetComponent<AudioSource>().Play();
            StartCoroutine(moveBack());
            moved = true;
        }
    }
    private IEnumerator moveBack()
    {
        while (elapsedTime<5f)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime/3f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }
}
