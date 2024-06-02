using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CinematicaCampus : MonoBehaviour
{
    // Start is called before the first frame update
    public float temp = 28f;

    // Update is called once per frame
    void Update()
    {
        temp-=Time.deltaTime;
        if(temp <=0){
            SceneManager.LoadScene("campus1");
        }
    }
}
