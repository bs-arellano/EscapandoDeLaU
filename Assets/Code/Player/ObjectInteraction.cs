using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class ObjectInteraction : MonoBehaviour
{
    public PlayerInput playerInputSystem;
    public GameObject interactUI;
    Interactive interactuable;
    void OnTriggerStay(Collider other)
    {
        Debug.Log(other.name);
        if (other.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        interactuable = other.GetComponent<Interactive>();
        if (interactuable != null && interactuable.active)
        {
            interactUI.GetComponentInChildren<Text>().text = playerInputSystem.actions["Interact"].GetBindingDisplayString();
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