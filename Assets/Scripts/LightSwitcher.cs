using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitcher : MonoBehaviour
{  
    [SerializeField] private GameObject targetGameObject;

    // This function is called when any GameObject enters the trigger.
    private void OnTriggerEnter(Collider other)
    {
        // Disable the GameObject when any GameObject enters the trigger.
        targetGameObject.SetActive(false);
    }

    // This function is called when any GameObject exits the trigger.
    private void OnTriggerExit(Collider other)
    {
        // Enable the GameObject when any GameObject exits the trigger.
        targetGameObject.SetActive(true);
    }
}
