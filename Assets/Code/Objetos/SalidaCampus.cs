using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SalidaCampus : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<TimeManager>().SaveTime();
            other.GetComponentInChildren<Camara>().ShowCursor();
            SceneManager.LoadScene("creditos");
        }
    }
}
