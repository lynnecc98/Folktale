using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceScript : MonoBehaviour
{

    public GameObject TextBox;
    public GameObject ChoiceA;
    public GameObject ChoiceB;
    public int ChoiceMade;

    public void ChoiceOption1() {
        TextBox.GetComponent<Text>().text = "choice 1 selected";
        ChoiceMade = 1;
    }

    public void ChoiceOption2()
    {
        TextBox.GetComponent<Text>().text = "choice 2 selected";
        ChoiceMade = 2;
    }

    void Update()
    {
        if (ChoiceMade >= 1) {
            ChoiceA.SetActive(false);
            ChoiceB.SetActive(false);
        }
    }
}
