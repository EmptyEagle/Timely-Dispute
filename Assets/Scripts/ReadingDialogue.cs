using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadingDialogue : MonoBehaviour
{
    // This class is in charge of reading the dialogue letter by letter, limiting the player's 'z' key usage, and keeping a tally of how much time the slow down covers 'keywords'
    public ScrollSpeedHolder scroll;
    public float delayOverride = 0.01f;
    public GameObject speaker;
    public bool isFirst = false;
    public bool isLast = false;
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
            if (this.name.Contains("Peasant 1"))
            {
                speaker.GetComponent<Text>().text = "<b>Peasant 1:</b>";
            }
            else if (this.name.Contains("Peasant 2"))
            {
                speaker.GetComponent<Text>().text = "<b>Peasant 2:</b>";
            }
            else if (this.name.Contains("Warlock Peasant"))
            {
                speaker.GetComponent<Text>().text = "<b>Warlock Peasant:</b>";
            }
            else if (this.name.Contains("Kingdom Peasant"))
            {
                speaker.GetComponent<Text>().text = "<b>Kingdom Peasant:</b>";
            }
            else if (this.name.Contains("King"))
            {
                speaker.GetComponent<Text>().text = "<b>King:</b>";
            }
            scroll.delay = delayOverride;
            if (Input.GetKey("z") && scroll.secondsLeft > 0f)
            {
                scroll.delay = 0.03f;
                scroll.secondsLeft -= 0.025f;
                if (fullText.Contains("drunk") || fullText.Contains("alcohol") || fullText.Contains("DRUNK") || fullText.Contains("drinking") || fullText.Contains("drink") || fullText.Contains("drunken"))
                {
                    scroll.drunkTime += 0.025f;
                    //Debug.Log(scroll.drunkTime);
                }
                //Debug.Log(scroll.secondsLeft);
            }
            currentText = fullText.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(scroll.delay);
        }
        yield return new WaitForSeconds(.05f);
        if (isLast)
        {
            if (scroll.knowsDrunk)
            {
                scroll.endChoicesGood.SetActive(true);
            }
            else
            {
                scroll.endChoicesBad.SetActive(true);
            }
            speaker.SetActive(false);
            this.gameObject.SetActive(false);
        }
        nextDialogue.SetActive(true);
        if (scroll.drunkTime > 0.5f)
        {
            scroll.knowsDrunk = true;
        }
        this.gameObject.SetActive(false);
    }
}
