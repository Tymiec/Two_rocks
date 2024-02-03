using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : GigaButton
{
    [SerializeField] private Renderer hoverHighlight;
    [SerializeField] private AudioSource audioSource;
    
    private Color startingEmissionColor;
    
    void Start()
    {
        // Store the initial emission color of the material
        startingEmissionColor = hoverHighlight.material.GetColor("_EmissiveColor");
    }
    public override void Click()
    {
        //play sound
        audioSource.Play();
    }

    public override void Hover(bool highlight)
    {
        if (highlight)
        {
            hoverHighlight.material.SetColor("_EmissiveColor", Color.yellow * 555455);
        }
        else
        {
            hoverHighlight.material.SetColor("_EmissiveColor", startingEmissionColor); 
        }
    }
}
