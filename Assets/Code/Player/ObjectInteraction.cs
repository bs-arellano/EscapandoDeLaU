using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        Interactive interactuable = other.GetComponent<Interactive>();
        if (interactuable != null && interactuable.active){
            interactuable.Interact();
        }
    }
}
