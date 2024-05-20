using UnityEngine.SceneManagement;
using UnityEngine;

public class SalidaSalones : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<TimeManager>().SaveTime();
            other.GetComponentInChildren<Camara>().ShowCursor();
            SceneManager.LoadScene("campus1");
        }
    }
}
