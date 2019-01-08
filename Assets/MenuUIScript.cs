using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuUIScript : MonoBehaviour {
    public AudioClip music;

	// Use this for initialization
	void Start () {
        AudioSource.PlayClipAtPoint(music, new Vector3(0, 0, 0));
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnGUI()
    {
        int screenMid = Screen.width / 2;
        int screenTop = Screen.height / 2;
        GUIStyle style = new GUIStyle();
        style.richText = true;

        GUI.Label(new Rect(new Vector2(screenMid - 125, screenTop - 300), new Vector2(600, 62)), "<size=62>"+"Samurai Defence"+"</size>");

        if(GUI.Button(new Rect(new Vector2(screenMid, screenTop - 150), new Vector2(200, 100)), "Start"))
        {
            //create intro animation before main scene?
            SceneManager.LoadScene("MainScene");
        }
        if (GUI.Button(new Rect(new Vector2(screenMid, screenTop), new Vector2(200,100)), "Rules"))
        {
            //create rules scene
        }
        if (GUI.Button(new Rect(new Vector2(screenMid, screenTop + 150), new Vector2(200, 100)), "Settings"))
        {
            //create settings scene
        }
        if (GUI.Button(new Rect(new Vector2(screenMid, screenTop + 300), new Vector2(200, 100)), "Quit"))
        {
            Application.Quit();
        }
        
    }
}
