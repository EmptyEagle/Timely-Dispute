using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonChoice : MonoBehaviour
{
    public ScrollSpeedHolder scroll;
    public GameObject speaker;

    public GameObject choice1;
    public GameObject choice2;
    public bool isGood;

    static int goodPoints;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isGood)
            {

            }
            speaker.SetActive(true);
            choice1.SetActive(true);
            Debug.Log("Pressed up");
            this.gameObject.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            speaker.SetActive(true);
            choice2.SetActive(true);
            Debug.Log("Pressed down");
            this.gameObject.SetActive(false);
        }
    }
}
