using UnityEngine;
using System.Collections;

public class PlatformBehaviour : MonoBehaviour {

    public GameObject platform;
    public float speed;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        platform.transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (platform.transform.position.x <= -12)
        {
            Destroy(platform);
        }

    }
}
