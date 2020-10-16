using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChoiceScript2 : MonoBehaviour
{

    public GameObject TextBox;
    public GameObject ChoiceA;
    public GameObject ChoiceB;

    public string choice1Response;
    public string choice2Response;

    public int ChoiceMade;

    private void Start()
    {
        
    }
    public void ChoiceOption1() {
        TextBox.GetComponent<TMP_Text>().text = choice1Response;
        ChoiceMade = 1;
    }

    public void ChoiceOption2()
    {
        TextBox.GetComponent<TMP_Text>().text = choice2Response;
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
