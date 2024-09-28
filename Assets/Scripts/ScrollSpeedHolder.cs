using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollSpeedHolder : MonoBehaviour
{
    public float delay = 0.01f;
    
    public float maxSeconds = 8;
    public float secondsLeft;

    void Start()
    {
        secondsLeft = maxSeconds;
    }
}
