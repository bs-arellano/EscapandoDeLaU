using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public int newGameScene;
    public GameObject cameraPivot;
    public GameObject settingsMenu;
    public float cameraRotationSpeed;

    void Update()
    {
        cameraPivot.GetComponent<Transform>().Rotate(Vector3.up * cameraRotationSpeed * Time.deltaTime);
    }
    public void NewGame()
    {
        PlayerPrefs.SetInt("Time",0);
        SceneManager.LoadScene(newGameScene);
    }

    public void Continue()
    {
        string lastScene = PlayerPrefs.GetString("LastScene");
        if (lastScene == "")
        {
            return;
        }
        SceneManager.LoadScene(lastScene);
    }

    public void Settings()
    {
        if (settingsMenu.activeSelf)
        {
            settingsMenu.SetActive(false);

        }
        else
        {
            settingsMenu.SetActive(true);
        }
        return;
    }

    public void Salir()
    {
        // if(Application.isEditor)
        // {
        //     UnityEditor.EditorApplication.isPlaying = false;
        //     return;
        // }
        Application.Quit();
    }
}
