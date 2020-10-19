using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public static class CrossSceneData
{
    public static bool StartWithIntroSequence = true;
}

public class MainController : MonoBehaviour
{
    public GameObject BurialTimeline;
    public GameObject IntroTimeline;
    public GameObject IntroUI;
    public GameObject FadeOutTimeline;

    public AudioMixer AmbientNoiseMixer;
    public AudioMixer FrogMixer;

    private UnityEngine.Playables.PlayableDirector burialDirector;
    private UnityEngine.Playables.PlayableDirector introDirector;

    // Start is called before the first frame update
    void Start()
    {
        burialDirector = BurialTimeline.GetComponent<UnityEngine.Playables.PlayableDirector>();
        introDirector = IntroTimeline.GetComponent<UnityEngine.Playables.PlayableDirector>();
        StartCoroutine(FadeAudioSource.StartFade(AmbientNoiseMixer, "RainMixerVolume", 1F, 0));
      
        if (CrossSceneData.StartWithIntroSequence)
        {
            burialDirector.initialTime = 60;
            burialDirector.Play();
            introDirector.Play();
            StartCoroutine(FadeAudioSource.StartFade(FrogMixer, "FrogMixerVolume", 1F, 0));
        }
        else
        {
            burialDirector.initialTime = 0;
            burialDirector.Play();
            StartCoroutine(FadeAudioSource.StartFade(FrogMixer, "FrogMixerVolume", 60F, 0));
        }
    }

    public void HandleStartClick()
    {
        FadeOutTimeline.SetActive(true);
        CrossSceneData.StartWithIntroSequence = false;
        StartCoroutine(FadeAudioSource.StartFade(AmbientNoiseMixer, "RainMixerVolume", 3F, -80));
        StartCoroutine(FadeAudioSource.StartFade(FrogMixer, "FrogMixerVolume", 3F, -80));
        StartCoroutine(LoadNextScene());
    }

    IEnumerator LoadNextScene()
    {

        yield return new WaitForSeconds(3);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("HurryUp");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
