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
        SceneManager.LoadScene(newGameScene);
    }

    public void Continue()
    {

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
}
