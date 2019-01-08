using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background4Behavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(Vector2.left * 2f * Time.deltaTime);

        if (this.transform.position.x <= -13.5f)
        {
            Instantiate(this, new Vector3(24.5f, 0, 1), Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
