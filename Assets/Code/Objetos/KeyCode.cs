using UnityEngine;

public class KeyCode : MonoBehaviour, Interactive
{
    public GameObject KeycodeUI;
    bool Interactive.active
    {
        get
        {
            return true;
        }
    }
    public void Interact()
    {
        OpenUI();
    }
    void OpenUI()
    {
        KeycodeUI.SetActive(true);
    }
}
