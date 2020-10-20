using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ChoiceScriptLeftOrRight : MonoBehaviour
{

    public GameObject TextBox;
    public GameObject ChoiceA;
    public GameObject ChoiceB;
    public GameObject Mom;

    public string choice1Response;
    public string choice2Response;

    public GameObject FadeOutTimeline;

    public int ChoiceMade;
    private Animator m_Animator;

    private void Start()
    {
        m_Animator = Mom.GetComponent<Animator>();
    }

    public void ChoiceOption1()
    {
        TextBox.GetComponent<TMP_Text>().text = choice1Response;
        ChoiceMade = 1;
        m_Animator.CrossFade("Yelling", 0.1F);
        StartCoroutine(LoadYourAsyncScene());
    }

    public void ChoiceOption2()
    {
        TextBox.GetComponent<TMP_Text>().text = choice2Response;
        ChoiceMade = 2;
        m_Animator.CrossFade("Yelling", 0.1F);
        StartCoroutine(LoadYourAsyncScene());
    }

    void Update()
    {
        if (ChoiceMade >= 1)
        {
            ChoiceA.SetActive(false);
            ChoiceB.SetActive(false);
        }
    }

    IEnumerator LoadYourAsyncScene()
    {
        yield return new WaitForSeconds(3);

        FadeOutTimeline.SetActive(true);

        yield return new WaitForSeconds(3);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("PromiseMe");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
