using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadingDialogue : MonoBehaviour
{
    public ScrollSpeedHolder scroll;
    public float delayOverride = 0.01f;
    public GameObject speaker;
    public bool isFirst = false;
    public GameObject nextDialogue;
    public string fullText;
    string currentText = "";

    float maxSeconds = 8;
    float secondsLeft;

    // Start is called before the first frame update
    void Start()
    {
        secondsLeft = maxSeconds;
        if (!isFirst)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        for(int i = 0; i < fullText.Length; i++)
        {
            scroll.delay = delayOverride;
            if (Input.GetKey("z") && secondsLeft > 0f)
            {
                Debug.Log("pressing z");
                scroll.delay = 0.1f;
                secondsLeft -= 0.1f;
            }
            //Debug.Log("Current delay is:" + scroll.delay);
            currentText = fullText.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(scroll.delay);
        }
        yield return new WaitForSeconds(.05f);
        nextDialogue.SetActive(true);
        if (nextDialogue.name.Contains("King"))
        {
            speaker.GetComponent<Text>().text = "King:";
        }
        else if (nextDialogue.name.Contains("Peasant 1"))
        {
            speaker.GetComponent<Text>().text = "Peasant 1:";
        }
        else if (nextDialogue.name.Contains("Peasant 2"))
        {
            speaker.GetComponent<Text>().text = "Peasant 2:";
        }
        this.gameObject.SetActive(false);
    }
}
