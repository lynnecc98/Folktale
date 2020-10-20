using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ChoiceScriptPromiseMe : MonoBehaviour
{

    public GameObject TextBox;
    public GameObject FadeOutTimeline;
    public GameObject Mom;
    public GameObject ResponseButton1;
    public GameObject ResponseButton2;
    public GameObject FinalButtonCanvas;

    public string response1;

    private Animator m_Animator;

    private void Start()
    {
        ResponseButton2.SetActive(false);
        m_Animator = Mom.GetComponent<Animator>();
        FinalButtonCanvas.SetActive(false);
    }

    public void Response1()
    {
        TextBox.GetComponent<TMP_Text>().text = response1;
        ResponseButton1.SetActive(false);
        ResponseButton2.SetActive(true);
        m_Animator.CrossFade("LayingNodding", 0.3F);

        ResponseButton2.GetComponent<UnityEngine.Playables.PlayableDirector>().Play();
    }

    public void Response2()
    {
        ResponseButton2.SetActive(false);
        FadeOutTimeline.SetActive(true);
        StartCoroutine(ShowButtons());
    }

    IEnumerator ShowButtons ()
    {
        yield return new WaitForSeconds(3);
        FinalButtonCanvas.SetActive(true);
    }

    public void FinalButtonClick()
    {
        StartCoroutine(LoadNextScene());
    }

    IEnumerator LoadNextScene()
    {
        CrossSceneData.StartWithIntroSequence = false;
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Burial");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
