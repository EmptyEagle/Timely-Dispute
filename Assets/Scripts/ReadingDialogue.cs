using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadingDialogue : MonoBehaviour
{
    public GameObject speaker;
    public bool isFirst = false;
    public GameObject nextDialogue;
    public float delay = 0.1f;
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
            currentText = fullText.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
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
