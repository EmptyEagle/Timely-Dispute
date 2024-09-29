using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollSpeedHolder : MonoBehaviour
{
    // This class is used to hold important variables that will stay the same across dialogue lines.
    public float delay = 0.01f;
    
    public float maxSeconds = 8;
    public float secondsLeft;

    public bool knowsTruth;
    public float keyWordTime;
    public int level;

    public GameObject endChoicesGood;
    public GameObject endChoicesBad;

    void Start()
    {
        secondsLeft = maxSeconds;
        knowsTruth = false;
        keyWordTime = 0f;
        endChoicesGood.SetActive(false);
        endChoicesBad.SetActive(false);
    }
}
