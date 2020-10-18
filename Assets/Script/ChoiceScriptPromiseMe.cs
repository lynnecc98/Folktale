using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ChoiceScriptPromiseMe : MonoBehaviour
{

    public GameObject TextBox;
    //public GameObject ChoiceA;
    //public GameObject ChoiceB;
    public GameObject FadeOutTimeline;

    public GameObject ResponseButton1;
    public GameObject ResponseButton2;

    //public Scene nextScene;

    public string response1;
    //public string choice1Response;
    //public string choice2Response;

    public int ChoiceMade;

    private void Start()
    {
        ResponseButton2.SetActive(false);
        FadeOutTimeline.SetActive(false);

    }

    public void Response1()
    {
        TextBox.GetComponent<TMP_Text>().text = response1;
        ResponseButton1.SetActive(false);
        ResponseButton2.SetActive(true);

        ResponseButton2.GetComponent<UnityEngine.Playables.PlayableDirector>().Play();
    }

    public void Response2()
    {
        //TextBox.GetComponent<TMP_Text>().text = response1;
        //ResponseButton1.SetActive(false);
        ResponseButton2.SetActive(false);
        FadeOutTimeline.SetActive(true);
        //FadeOutTimeline.GetComponent<UnityEngine.Playables.PlayableDirector>().Play();
        StartCoroutine(LoadYourAsyncScene());
    }

    //public void ChoiceOption1()
    //{
    //    TextBox.GetComponent<TMP_Text>().text = choice1Response;
    //    ChoiceMade = 1;
    //}

    //public void ChoiceOption2()
    //{
    //    TextBox.GetComponent<TMP_Text>().text = choice2Response;
    //    ChoiceMade = 2;
    //}

    //void Update()
    //{
    //    if (ChoiceMade >= 1)
    //    {
    //        ChoiceA.SetActive(false);
    //        ChoiceB.SetActive(false);
    //    }
    //}

    IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.
        yield return new WaitForSeconds(3);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Burial");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
