using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPauser : MonoBehaviour
{
    [SerializeField] private AudioSource audioToPause;

    // This function is called when any GameObject enters the trigger.
    private void OnTriggerEnter(Collider other)
    {
        audioToPause.Stop();
    }

    // This function is called when any GameObject exits the trigger.
    private void OnTriggerExit(Collider other)
    {
        
        audioToPause.Play();
    }
}
