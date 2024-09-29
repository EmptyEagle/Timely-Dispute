using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonChoice : MonoBehaviour
{
    public ScrollSpeedHolder scroll;
    public GameObject speaker;
    public GameObject arrows;

    public GameObject choice1;
    public GameObject choice2;
    public bool isGood;

    static int goodPoints;
    
    void Start()
    {
        goodPoints = 0;
        arrows.SetActive(false);
    }

    void OnEnable()
    {
        arrows.SetActive(true);
    }

    void OnDisable()
    {
        arrows.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isGood)
            {
                goodPoints += 2;
            }
            else
            {
                goodPoints++;
            }
            speaker.SetActive(true);
            choice1.SetActive(true);
            Debug.Log("Pressed up");
            this.gameObject.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (isGood)
            {
                goodPoints += 2;
            }
            speaker.SetActive(true);
            choice2.SetActive(true);
            Debug.Log("Pressed down");
            this.gameObject.SetActive(false);
        }
        else if (scroll.hasThreeArrows && Input.GetKeyDown(KeyCode.RightArrow))
        {
            SceneManager.LoadScene("War");
        }
    }
}
