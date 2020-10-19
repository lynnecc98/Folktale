using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TimelineManager2 : MonoBehaviour
{
    public PlayableDirector Timeline1;
    public PlayableDirector Timeline2;
    public GameObject FadeOut;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Timeline1.time > 6)
        {
            if (Input.GetKeyDown("space"))
            {
                Timeline1.Stop();
                Timeline2.Play();
            }
        }
        if (Timeline2.time > 6)
        {
            FadeOut.SetActive(true);
        }
    }


}
