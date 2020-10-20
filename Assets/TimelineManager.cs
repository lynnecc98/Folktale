using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class TimelineManager : MonoBehaviour
{
    public PlayableDirector Timeline1;
    public PlayableDirector Timeline2;
    public PlayableDirector Timeline3;
    public GameObject StayPutSpeechBubble;
    public GameObject FadeOut;
    public GameObject ButtonCanvas;

    private void Start()
    {
        StayPutSpeechBubble.SetActive(false);
        ButtonCanvas.SetActive(false);
    }
    public void FollowClick()
    {
        ButtonCanvas.SetActive(false);
        Timeline1.Stop();
        Timeline2.Play();
    }

    public void StayClick()
    {
        StayPutSpeechBubble.SetActive(true);
        ButtonCanvas.SetActive(false);
        StartCoroutine(LoadNextSceneWithDelay());
    }

    public void ShowButtonCanvas()
    {
        ButtonCanvas.SetActive(true);
    }

    public void LoadNextScene()
    {
        FadeOut.SetActive(true);
        StartCoroutine(LoadNextSceneAsync());
    }

    IEnumerator LoadNextSceneWithDelay()
    {
        yield return new WaitForSeconds(3);
        LoadNextScene();
    }

    IEnumerator LoadNextSceneAsync()
    {
        CrossSceneData.StartWithIntroSequence = false;
        yield return new WaitForSeconds(3);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("BeQuiet");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

}
