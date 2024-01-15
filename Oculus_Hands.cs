using UnityEngine;
using UnityEngine.InputSystem;

public class OculusHands : MonoBehaviour
{
    public InputActionReference gripReference, triggerReference;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();

        // Register event handlers for grip actions
        gripReference.action.started += GripPressed;
        gripReference.action.canceled += GripCanceled;

        // Register event handlers for trigger actions
        triggerReference.action.started += TriggerPressed;
        triggerReference.action.canceled += TriggerCanceled;
    }

    private void OnDestroy()
    {
        // Unregister event handlers for grip actions
        gripReference.action.started -= GripPressed;
        gripReference.action.canceled -= GripCanceled;

        // Unregister event handlers for trigger actions
        triggerReference.action.started -= TriggerPressed;
        triggerReference.action.canceled -= TriggerCanceled;
    }

    private void GripPressed(InputAction.CallbackContext context)
    {
        Debug.Log("Grip Pressed");
        anim.SetBool("GripPressed", true);
    }

    private void GripCanceled(InputAction.CallbackContext context)
    {
        Debug.Log("Grip Canceled");
        anim.SetBool("GripPressed", false);
    }

    private void TriggerPressed(InputAction.CallbackContext context)
    {
        Debug.Log("Trigger Pressed");
        anim.SetBool("TriggerPressed", true);
    }

    private void TriggerCanceled(InputAction.CallbackContext context)
    {
        Debug.Log("Trigger Canceled");
        anim.SetBool("TriggerPressed", false);
    }
}
