using UnityEngine;
using System.Collections;
using UnityEngine.XR.Interaction.Toolkit;

public class FuseBoxAnimation : MonoBehaviour
{
    [SerializeField] private Animator shieldAnimator;
    private bool isOpen = false;
    private bool isGrabbingSwitch = false;
    private bool isGrabbingShield = false; 

    void Start()
    {
        shieldAnimator = GetComponentInParent<Animator>();
    }

    public void OnShieldGrabbed(SelectEnterEventArgs args)
    {
        // Check if the shield is already being grabbed
        if (!isGrabbingShield)
        {
            isGrabbingShield = true; 
            ToggleShield();
        }
    }

    public void OnShieldReleased(SelectExitEventArgs args) 
    {
        // Reset the flag when the shield is released
        isGrabbingShield = false;
    }

    private void ToggleShield()
    {
        // Toggle shield open/close with animation
        if (isOpen)
        {
            shieldAnimator.Play("CloseShield");
        }
        else
        {
            shieldAnimator.Play("OpenShield");
        }
        isOpen = !isOpen;
        Debug.Log("IsOpen " + isOpen);
    }

    public void OnSwitchPress()
    {
        shieldAnimator.Play("TurnOnSwitch");
    }

}
