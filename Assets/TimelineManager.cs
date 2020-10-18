using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TimelineManager : MonoBehaviour
{
    public PlayableDirector Timeline1;
    public PlayableDirector Timeline2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Timeline1.time > 6.5) 
        {
            if (Input.GetKeyDown("space")) {
                Timeline1.Stop();
                Timeline2.Play();
            }
        }
    }


}
