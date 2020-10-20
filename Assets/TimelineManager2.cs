using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class TimelineManager2 : MonoBehaviour
{
    public PlayableDirector Timeline1;
    public PlayableDirector Timeline2;
    public GameObject FadeOut;
    public Animator son;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
    }


    IEnumerator LoadNextSceneAsync()
    {
        yield return new WaitForSeconds(3);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("LeftOrRight");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void PauseScene()
    {
        Timeline1.Pause();
    }

    public void StartTimeline2()
    {
        Timeline2.Play();
    }

    public void SelectedChoice()
    {
        print("CHOICE CALLED");
        Timeline1.Resume();
        son.SetBool("isWalking", true);
    }

    public void LoadNextScene()
    {
        FadeOut.SetActive(true);
        StartCoroutine(LoadNextSceneAsync());
    }

}
