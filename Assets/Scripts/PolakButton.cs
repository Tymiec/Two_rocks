using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolakButton : GigaButton
{
    [SerializeField] private int direction;
    [SerializeField] private int digitPlacement;
    [SerializeField] private WielkiPolakMystery wielkiPolakMystery;

    [SerializeField] private Renderer hoverHighlight;
    
    private Color startingEmissionColor;
    
    void Start()
    {
        // Store the initial emission color of the material
        startingEmissionColor = hoverHighlight.material.GetColor("_EmissiveColor");
    }
    public override void Click()
    {
        wielkiPolakMystery.ChangeNumber(digitPlacement,direction);
    }

    public override void Hover(bool highlight)
    {
        if (highlight)
        {
            hoverHighlight.material.SetColor("_EmissiveColor", Color.white * 555455);
        }
        else
        {
            hoverHighlight.material.SetColor("_EmissiveColor", startingEmissionColor); 
        }
    }
}