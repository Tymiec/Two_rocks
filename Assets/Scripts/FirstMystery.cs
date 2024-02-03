using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FirstMystery : MonoBehaviour
{
    [SerializeField] private TextMeshPro leftDigit;
    [SerializeField] private TextMeshPro rightDigit;
    void Start()
    {
        leftDigit.text = Random.Range(1, 8).ToString();
        rightDigit.text = Random.Range(1, 9).ToString();
    }

    public void ChangeNumber(int whichDigit, int amount)
    {
        switch (whichDigit)
        {
            case 1:
                //left digit
                leftDigit.text = ((int.Parse(leftDigit.text) + amount + 10) %10).ToString();
                break;
            case 2:
                //right digit
                rightDigit.text = ((int.Parse(rightDigit.text) + amount + 10) %10).ToString();
                break;
        }
        SolveCheck();
    }

    // Update is called once per frame
    void SolveCheck()
    {
        if (leftDigit.text == "9" && rightDigit.text == "5")
        {
            //co sie ma stac jak sie otworzy
            Debug.Log("You solved the mistery");
        }
    }
}
