using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeyRebind : MonoBehaviour
{
    public InputActionAsset inputActions;
    //Get the action map from the inputActions
    InputActionMap actionMap => inputActions.actionMaps[0];
    public string actionName;
    private InputAction selectedAction;
    public GameObject guiActionName;
    public GameObject guiActionKey;
    private InputActionRebindingExtensions.RebindingOperation rebindOperation;
    

    void Start()
    {
        selectedAction = actionMap.FindAction(actionName);
        guiActionName.GetComponent<TextMeshProUGUI>().text = actionName;
        guiActionKey.GetComponent<TextMeshProUGUI>().text = selectedAction.GetBindingDisplayString(0);
    }
    void Update(){
        if (rebindOperation != null)
            if (rebindOperation.completed)
            {
                selectedAction.Enable();// after this you can use the new key
                guiActionKey.GetComponent<TextMeshProUGUI>().text = selectedAction.GetBindingDisplayString(0);
                rebindOperation = null;
            }
    }
    public void Rebind()
    {
        selectedAction.Disable();
        rebindOperation = selectedAction.PerformInteractiveRebinding()
            .WithControlsExcluding("Mouse")
            .WithCancelingThrough("<Keyboard>/escape")
            .OnMatchWaitForAnother(0.2f)
            .Start();
    }
}
