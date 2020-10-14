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
    private GameObject mainCamera;
    private GameObject grave;

    RainScript rainScript;

    public Vector3 cloudStartPosition;
    private Vector3 cloudEndPosition;

    private float cloudJourneyLength;
    private float waterJourneyLength;
    public float cloudSpeed = 100.0F;

    public Vector3 waterEndPosition;
    private Vector3 waterStartPosition;

    public Vector3 cameraStartPosition;
    public Vector3 cameraEndPosition;

    private Vector3 graveStartPosition;
    private Vector3 graveEndPosition;

    private float startTime;
    private float waterRiseStartTime;
    private float graveStartTime;
    private float rainStartTime;
    private float changeDirectionTime;

    private bool isAnimating = false;

    // Start is called before the first frame update
    void Start()
    {
        water = GameObject.FindGameObjectWithTag("Water");
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        rain = GameObject.Find("RainPrefab");
        clouds = GameObject.Find("Clouds");
        grave = GameObject.Find("Grave");

        cloudEndPosition = clouds.gameObject.transform.position;

        //Animation anim = water.GetComponent<Animation>();

        clouds.gameObject.transform.position = cloudStartPosition;

        waterStartPosition = water.transform.position;
        graveStartPosition = grave.transform.position;
        graveEndPosition = graveStartPosition;
        graveEndPosition.y -= 3;

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

        float waterPositionFraction = ((Time.time - waterRiseStartTime) * (cloudSpeed / 3)) / cloudJourneyLength;
        float gravePositionFraction = ((Time.time - graveStartTime) * (cloudSpeed)) / cloudJourneyLength;

        float fractionOfJourney = distCovered / cloudJourneyLength;
        //float reverseFractionOfJourney = distCovered / cloudJourneyLength;

        if(Time.time < changeDirectionTime)
        {
            rainScript.RainIntensity = Mathf.Max(rainIntensity, 0);
            clouds.gameObject.transform.position = Vector3.Lerp(cloudStartPosition, cloudEndPosition, fractionOfJourney);
            water.gameObject.transform.position = Vector3.Lerp(waterStartPosition, waterEndPosition, Mathf.Max(waterPositionFraction, 0));
            mainCamera.gameObject.transform.position = Vector3.Lerp(cameraStartPosition, cameraEndPosition, Mathf.Max(fractionOfJourney, 0));
            grave.transform.position = Vector3.Lerp(graveStartPosition, graveEndPosition, Mathf.Max(gravePositionFraction, 0));
        } else
        {
            water.gameObject.transform.position = Vector3.Lerp(waterStartPosition, waterEndPosition, Mathf.Max(waterPositionFraction, 0));

        }

    }

    public void StartSequence()
    {
        startTime = Time.time;
        rainStartTime = startTime + 10;

        graveStartTime = startTime + 60;
        waterRiseStartTime = startTime + 20;

        changeDirectionTime = startTime + 90;

        cloudJourneyLength = Vector3.Distance(cloudStartPosition, cloudEndPosition);
        waterJourneyLength = Vector3.Distance(waterStartPosition, waterEndPosition);
        isAnimating = true;
    }

}
