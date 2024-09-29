using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdvanceScene : MonoBehaviour
{
    string currentScene;
    public string loadScene;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (currentScene == "Tutorial")
            {
                SceneManager.LoadScene("Dispute 1");
            }
            else if (currentScene == "Dispute 1")
            {
                SceneManager.LoadScene(loadScene);
            }
            else if (currentScene == "Dispute 2")
            {
                SceneManager.LoadScene(loadScene);
            }
            else if (currentScene == "Compensated" || currentScene == "Drunken" || currentScene == "Both Jailed" || currentScene == "Huh")
            {
                SceneManager.LoadScene("Dispute 2");
            }
        }
    }
}
