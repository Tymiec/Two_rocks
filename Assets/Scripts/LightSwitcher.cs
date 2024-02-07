using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitcher : MonoBehaviour
{  
    [SerializeField] private GameObject targetGameObject;
    [SerializeField] private GameObject audioToBeDisabled;
    [SerializeField] private AudioSource audioToPlay;
    [SerializeField] private GameObject volumeToBeDisabled;

    // This function is called when any GameObject enters the trigger.
    private void OnTriggerEnter(Collider other)
    {
        // Disable the GameObject when any GameObject enters the trigger.
        targetGameObject.SetActive(false);
        if (audioToBeDisabled)
        {
            audioToBeDisabled.SetActive(false);
        }

        if (volumeToBeDisabled)
        {
            volumeToBeDisabled.SetActive(false);
        }

        if (audioToPlay)
        {
            audioToPlay.Play();
        }
    }

    // This function is called when any GameObject exits the trigger.
    private void OnTriggerExit(Collider other)
    {
        // Enable the GameObject when any GameObject exits the trigger.
        targetGameObject.SetActive(true);
        
        if (audioToBeDisabled)
        {
            audioToBeDisabled.SetActive(true);
        }
        
        if (volumeToBeDisabled)
        {
            volumeToBeDisabled.SetActive(true);
        }
    }
}
