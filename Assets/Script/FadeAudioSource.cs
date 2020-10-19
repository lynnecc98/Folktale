using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public static class FadeAudioSource
{
    public static IEnumerator StartFade(AudioMixer mixer, string varName, float duration, float targetVolume)
    {
        float current;
        mixer.GetFloat(varName, out current);

        float currentTime = 0;
        float start = current;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            mixer.SetFloat(varName, Mathf.Lerp(start, targetVolume, currentTime / duration));
            //audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }
}