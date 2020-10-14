using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public bool startWithIntro = false;
    public GameObject BurialTimeline;
    public GameObject IntroTimeline;
    public GameObject IntroUI;

    private UnityEngine.Playables.PlayableDirector burialDirector;
    private UnityEngine.Playables.PlayableDirector introDirector;

    // Start is called before the first frame update
    void Start()
    {
        burialDirector = BurialTimeline.GetComponent<UnityEngine.Playables.PlayableDirector>();
        introDirector = IntroTimeline.GetComponent<UnityEngine.Playables.PlayableDirector>();

        if (startWithIntro)
        {
            IntroUI.SetActive(true);
            burialDirector.initialTime = 60;
            burialDirector.Play();
            introDirector.Play();
        }
        else
        {
            IntroUI.SetActive(false);
            burialDirector.initialTime = 0;
            burialDirector.Play();
        }
    }
}
