using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    public Text debugText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void SetDebugText(string getText)
    {
        debugText.text = getText;
    }

    public void ClearDebugText()
    {
        debugText.text = "";
    }

    public void LoadMainMenu()
    {
        LoadLevel("MainMenu");
    }

    public void LoadLevel1()
    {
        LoadLevel("Level1");
    }

    public void LoadLevel2()
    {
        LoadLevel("Level2");
    }
}
