using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnTriggerPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource soundToBePlayedOnce;
    private bool hasPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasPlayed)
        {
            soundToBePlayedOnce.Play();
            hasPlayed = true;
        }
    }
}