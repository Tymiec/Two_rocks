using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WielkiPolakMystery : MonoBehaviour
{
    [SerializeField] private TextMeshPro leftDigit;
    [SerializeField] private TextMeshPro middleDigit; // Added middle digit
    [SerializeField] private TextMeshPro rightDigit;
    [SerializeField] private AudioSource polskaGurom;
    [SerializeField] private Animator doorOpenAnim;
    [SerializeField] private GameObject objectToDeleteAfterSolving;
    private bool checkOnce = false;

    void Start()
    {
        leftDigit.text = Random.Range(3, 10).ToString(); // Fixed risk of auto solve
        middleDigit.text = Random.Range(0, 10).ToString(); // Assuming the middle digit can start at 0
        rightDigit.text = Random.Range(0, 10).ToString();
    }

    public void ChangeNumber(int whichDigit, int amount)
    {
        switch (whichDigit)
        {
            case 1:
                // Left digit
                leftDigit.text = ((int.Parse(leftDigit.text) + amount + 10) % 10).ToString();
                break;
            case 2:
                // Middle digit
                middleDigit.text = ((int.Parse(middleDigit.text) + amount + 10) % 10).ToString();
                break;
            case 3:
                // Right digit
                rightDigit.text = ((int.Parse(rightDigit.text) + amount + 10) % 10).ToString();
                break;
        }
        SolveCheck();
    }

    // Update is called once per frame
    void SolveCheck()
    {
        // Adjust the condition based on how the middle digit affects the mystery being solved
        if (leftDigit.text == "2" && middleDigit.text == "1" && rightDigit.text == "4") // Replace "X" with the correct condition for the middle digit
        {
            // What happens when the mystery is solved
            Debug.Log("POLSKA GUROM!");
            //play polska gurom
            if (!checkOnce)
            {
                Destroy(objectToDeleteAfterSolving);
                polskaGurom.Play();
                checkOnce = true;
            }
            
            //open the door
            doorOpenAnim.SetTrigger("TriggerN");
            
        }
    }
}