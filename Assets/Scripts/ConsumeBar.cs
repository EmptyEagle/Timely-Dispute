using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumeBar : MonoBehaviour
{
    public ScrollSpeedHolder scroll;
    Vector3 temp;

    // Update is called once per frame
    void Update()
    {
        temp = transform.localScale;

        if (scroll.secondsLeft > 0) temp.x = scroll.secondsLeft / scroll.maxSeconds;

        transform.localScale = temp;
    }
}
