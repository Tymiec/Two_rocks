using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : GigaButton
{
    [SerializeField] private int direction;
    [SerializeField] private int digitPlacement;
    [SerializeField] private FirstMystery firstMystery;

    [SerializeField] private Renderer hoverHighlight;
    private Color startingEmissionColor;
    
    void Start()
    {
        // Store the initial emission color of the material
        startingEmissionColor = hoverHighlight.material.GetColor("_EmissiveColor");
    }
    public override void Click()
    {
        firstMystery.ChangeNumber(digitPlacement,direction);
    }

    public override void Hover(bool highlight)
    {
        if (highlight)
        {
            // hoverHighlight.material.SetColor("_EmissiveColor", Color.white * 1); 555455
            hoverHighlight.material.SetColor("_EmissiveColor", Color.white * 2554);
        }
        else
        {
            hoverHighlight.material.SetColor("_EmissiveColor", startingEmissionColor); 
        }
    }
}
