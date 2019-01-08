using UnityEngine;
using System.Collections;

public class PlatformManager : MonoBehaviour {

    public float sWidth = Screen.width;
    public float sHeight = Screen.height;
    public GameObject platform;
    private float timer = 2f;
    private float timer2 = 2f;
    public GameObject player;
    public static int score = 0;

    public int Score
    {
        get
        {
            return score;
        }

        set
        {
            score = value;
        }
    }


    // Use this for initialization
    void Start () {
        Instantiate(platform, new Vector3(0, -1), Quaternion.identity);
        Instantiate(platform, new Vector3(2.6f, -1), Quaternion.identity);
        Instantiate(platform, new Vector3(5.2f, -1), Quaternion.identity);
        Instantiate(platform, new Vector3(7.8f, -1), Quaternion.identity);
        Instantiate(platform, new Vector3(10.3f, -1), Quaternion.identity);
        Instantiate(platform, new Vector3(12.9f, -1), Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
        GenerateFloor();
        GeneratePlatforms();
    }

    void GeneratePlatforms()
    {
        timer -= Time.deltaTime;

        if(timer <= 0f)
        {
            float randY = Random.Range(-2.5f, 4.5f);
            Instantiate(platform, new Vector3(10f, randY), Quaternion.identity);
            timer = 1.5f;
            Score += 50;
        }

    }

    void GenerateFloor()
    {
        timer2-= Time.deltaTime;

        if (timer2 <= 0.64f)
        {
            Instantiate(platform, new Vector3(12f, -3.0f), Quaternion.identity);
            timer2 = 1.5f;
        }
    }
}
