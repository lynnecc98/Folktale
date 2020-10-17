using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChoiceScriptPromiseMe : MonoBehaviour
{

    public GameObject TextBox;
    public GameObject ChoiceA;
    public GameObject ChoiceB;

    public GameObject ResponseButton1;
    public GameObject ResponseButton2;

    public string response1;
    public string choice1Response;
    public string choice2Response;

    public int ChoiceMade;
        
    private void Start()
    {
        ResponseButton2.SetActive(false);

    }

    public void Response1()
    {
        TextBox.GetComponent<TMP_Text>().text = response1;
        ResponseButton1.SetActive(false);
        ResponseButton2.SetActive(true);
        ResponseButton2.GetComponent<UnityEngine.Playables.PlayableDirector>().Play();
    }
    public void Response2()
    {
        //TextBox.GetComponent<TMP_Text>().text = response1;
        //ResponseButton1.SetActive(false);
        ResponseButton2.SetActive(false);
        //ResponseButton2.GetComponent<UnityEngine.Playables.PlayableDirector>().Play();
    }

    public void ChoiceOption1()
    {
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
        if (ChoiceMade >= 1)
        {
            ChoiceA.SetActive(false);
            ChoiceB.SetActive(false);
        }
    }
}
