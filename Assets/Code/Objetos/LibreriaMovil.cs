using System.Collections;
using UnityEngine;

public class LibreriaMovil : MonoBehaviour, Interactive
{
    bool moved;
    Vector3 startPosition;
    Vector3 targetPosition;
    float elapsedTime = 0f;
    bool Interactive.active
    {
        get
        {
            return !moved;
        }
        set
        {
            moved = !value;
        }
    }
    void Start()
    {
        moved = false;
    }
    public void Interact()
    {
        if (!moved)
        {
            startPosition = transform.position;
            targetPosition = transform.position - new Vector3(0, 0, 3);
            transform.GetComponent<AudioSource>().Play();
            StartCoroutine(moveBack());
            moved = true;
        }
    }
    private IEnumerator moveBack()
    {
        while (elapsedTime<3f)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime/3f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }
}
