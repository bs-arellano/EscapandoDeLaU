using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    PlayerController playerController;
    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }
    public void ApplyInvisibility()
    {
        playerController.SetVisible(false);
        StartCoroutine(Invisibility());
    }
    private IEnumerator Invisibility()
    {
        yield return new WaitForSeconds(30);
        playerController.SetVisible(true);
    }
}
