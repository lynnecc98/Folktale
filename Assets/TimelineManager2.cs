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
    bool paused = false;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Timeline1.time > 9.3)
        {
            if (paused == false) 
            {
                Timeline1.Pause();
                paused = true;

            }
            
        }
        
        if (Timeline1.time > 12.1) 
        {
            Timeline1.Stop();
            Timeline2.Play();
        }
        if (Timeline2.time > 6)
        {
            FadeOut.SetActive(true);
            StartCoroutine(LoadNextScene());
        }
    }

    IEnumerator LoadNextScene()
    {
        CrossSceneData.StartWithIntroSequence = false;
        yield return new WaitForSeconds(3);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("LeftOrRight");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void SelectedChoice() 
    {
        if (paused == true)
        {
            Timeline1.Resume();
            son.SetBool("isWalking", true);
        }
    }


}
