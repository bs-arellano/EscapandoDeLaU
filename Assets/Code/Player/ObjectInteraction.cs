using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectInteraction : MonoBehaviour
{
    public GameObject interactUI;
    Interactive interactuable;
    void OnTriggerEnter(Collider other)
    {
        interactuable = other.GetComponent<Interactive>();
        if (interactuable != null)
        {
            interactUI.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        EndInteraction();
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if (interactuable != null && interactuable.active && context.performed)
        {
            interactuable.Interact();
        }
        if (interactuable == null || !interactuable.active)
        {
            EndInteraction();
        }
    }
    void EndInteraction()
    {
        interactuable = null;
        interactUI.SetActive(false);
    }
}