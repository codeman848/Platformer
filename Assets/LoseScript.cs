using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class LoseScript : MonoBehaviour {

    public string textShownOnScreen;
    public string fullText = "You have lost , but try again you may do beter next time. Would you like to try again?";
    public float wordsPerSecond = 1; // speed of typewriter
    public float timeElapsed = 0;
    public float textAcceleration = 3;
    public AudioClip loseMusic;

    // Use this for initialization
    void Start() {

        AudioSource.PlayClipAtPoint(loseMusic, new Vector3(0, 0, 0));
    }

    void Update()
    {
        timeElapsed += Time.deltaTime*textAcceleration;
        textShownOnScreen = GetWords(fullText, Convert.ToInt16(timeElapsed) * Convert.ToInt16(wordsPerSecond));
    }

    void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.richText = true;
        string distance = "Your distance was: " + PlayerBehaviour.score;

        GUI.Label(new Rect(Screen.width/2-400, 150, 800, 250), "<size=50>"+textShownOnScreen +"</size>");
        GUI.Label(new Rect(Screen.width/2-150, Screen.height/2 +50,375, 50), "<size=35>" + distance +"m" + "</size>");
        if(GUI.Button(new Rect(600, Screen.height / 2 + 200, 300, 60),"Retry?"))
        {
            SceneManager.LoadScene("MainScene");
        }
        if(GUI.Button(new Rect(1000, Screen.height / 2 + 200, 300, 60), "Quit"))
        {
            SceneManager.LoadScene("StartScene");
        }
    }


    private string GetWords(string text, int wordCount)
    {
        int words = wordCount;
        // loop through each character in text
        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == ' ')
            {
                words--;
            }
            if (words <= 0)
            {
                return text.Substring(0, i);
            }
        }
        return text;
    }
}
