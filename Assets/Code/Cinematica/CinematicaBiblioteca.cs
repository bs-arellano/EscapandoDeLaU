using System.Collections;
using UnityEngine;

public class CinematicaBiblioteca : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player.SetActive(false);
        StartCoroutine(EndCinematica());
    }

    IEnumerator EndCinematica()
    {
        yield return new WaitForSeconds(10);
        player.SetActive(true);
        Destroy(gameObject);
    }
}
