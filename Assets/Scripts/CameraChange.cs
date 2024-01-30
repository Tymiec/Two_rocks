using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraChange : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject activeCamera;
    [SerializeField] private GameObject targetCamera;
    [SerializeField] private GameObject modelToBeDestroyed;
    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log("Turning off intro camera");
        activeCamera.SetActive(false);
        targetCamera.SetActive(true);
        if (modelToBeDestroyed)
        {
            Destroy(modelToBeDestroyed);
        }

        Destroy(gameObject);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
