using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RayButton : MonoBehaviour
{
    [SerializeField] private Transform transfromCameraRoot;
    private GigaButton hoveredButton;
    
    public void OnClick()
    {

        Physics.Raycast(transfromCameraRoot.position, transfromCameraRoot.forward, out RaycastHit hitInfo, 10f);
        if (!hitInfo.collider)
        {
            return;
        }

        GigaButton buttonCheck = hitInfo.collider.GetComponent<GigaButton>();
        if (!buttonCheck)
        {
            return;
        }

        buttonCheck.Click();
    }

    void Update()
    {
        Physics.Raycast(transfromCameraRoot.position, transfromCameraRoot.forward, out RaycastHit hitInfo, 10f);
        if (!hitInfo.collider)
        {
            hoveredButton?.Hover(false);
            hoveredButton = null;
            return;
        }

        GigaButton buttonCheck = hitInfo.collider.GetComponent<GigaButton>();
        if (!buttonCheck)
        {
            hoveredButton?.Hover(false);
            hoveredButton = null;
            return;
        }

        if (hoveredButton == buttonCheck)
        {
            return;
        }

        hoveredButton?.Hover(false);
        
        hoveredButton = buttonCheck;
        hoveredButton?.Hover(true);
    }
}
