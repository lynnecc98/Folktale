using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.RainMaker;

public class SequenceController : MonoBehaviour
{
    private GameObject water;
    private GameObject rain;
    private GameObject waterAnim;
    private GameObject clouds;

    RainScript rainScript;

    public Vector3 cloudStartPosition;
    private Vector3 cloudEndPosition;
    private float cloudJourneyLength;
    private float waterJourneyLength;
    public float cloudSpeed = 100.0F;

    public Vector3 waterEndPosition;
    private Vector3 waterStartPosition;

    private float startTime;
    private float rainStartTime;
    private float waterRiseStartTime;
    private bool isAnimating = false;

    // Start is called before the first frame update
    void Start()
    {
        water = GameObject.FindGameObjectWithTag("Water");
        rain = GameObject.Find("RainPrefab");
        clouds = GameObject.Find("Clouds");
        cloudEndPosition = clouds.gameObject.transform.position;
        print(cloudEndPosition);
        Animation anim = water.GetComponent<Animation>();
        clouds.gameObject.transform.position = cloudStartPosition;

        waterStartPosition = water.transform.position;

        //anim.Play();
        rainScript = rain.GetComponent<RainScript>();
        rainScript.RainIntensity = 0;

        StartSequence();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAnimating) return;
        float distCovered = (Time.time - startTime) * cloudSpeed;
        float rainIntensity = ((Time.time - rainStartTime) * (cloudSpeed / 2)) / cloudJourneyLength;

        float waterPositionFraction = ((Time.time - rainStartTime) * (cloudSpeed / 3)) / cloudJourneyLength;

        float fractionOfJourney = distCovered / cloudJourneyLength;


        rainScript.RainIntensity = Mathf.Max(rainIntensity, 0);
        clouds.gameObject.transform.position = Vector3.Lerp(cloudStartPosition, cloudEndPosition, fractionOfJourney);
        water.gameObject.transform.position = Vector3.Lerp(waterStartPosition, waterEndPosition, Mathf.Max(waterPositionFraction, 0));
    }

    public void StartSequence()
    {
        startTime = Time.time;
        rainStartTime = startTime + 10;
        waterRiseStartTime = startTime + 40;

        cloudJourneyLength = Vector3.Distance(cloudStartPosition, cloudEndPosition);
        waterJourneyLength = Vector3.Distance(waterStartPosition, waterEndPosition);
        isAnimating = true;

    }

}
