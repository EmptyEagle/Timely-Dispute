using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slowdown : MonoBehaviour
{
    public float maxSeconds = 8;
    float secondsLeft;
    Vector3 barSize;

    // Start is called before the first frame update
    void Start()
    {
        secondsLeft = maxSeconds;
    }

    // Update is called once per frame
    void Update()
    {
        barSize = transform.localScale;
        while (Input.GetKeyDown("z"))
        {
            StartCoroutine(DecreaseTime());
        }
    }

    IEnumerator DecreaseTime()
    {
        if (secondsLeft > 0)
        {
            secondsLeft -= 0.1f;
            barSize.x -= 0.1f;
            transform.localScale = barSize;
        }
        else
        {
            Debug.Log("You are out of juice!");
        }
        yield return new WaitForSeconds(.1f);
    }
}
