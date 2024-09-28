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

    // Start is called before the first frame update
    void Start()
    {
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
            if (Input.GetKey("z") && scroll.secondsLeft > 0f)
            {
                scroll.delay = 0.03f;
                scroll.secondsLeft -= 0.025f;
                Debug.Log(scroll.secondsLeft);
            }
            currentText = fullText.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(scroll.delay);
        }
        yield return new WaitForSeconds(.05f);
        nextDialogue.SetActive(true);
        if (nextDialogue.name.Contains("King"))
        {
            speaker.GetComponent<Text>().text = "<b>King:</b>";
        }
        else if (nextDialogue.name.Contains("Peasant 1"))
        {
            speaker.GetComponent<Text>().text = "<b>Peasant 1:</b>";
        }
        else if (nextDialogue.name.Contains("Peasant 2"))
        {
            speaker.GetComponent<Text>().text = "<b>Peasant 2:</b>";
        }
        this.gameObject.SetActive(false);
    }
}
