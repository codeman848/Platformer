using UnityEngine;
using System.Collections;

public class HealthPotionScript : MonoBehaviour {
    public GameObject player;
    public GameObject health;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col){

        if(col.gameObject.tag == "Player")
        {
            PlayerBehaviour.hp += 10;
            Destroy(health);
        }
    }
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Platform")
        {
            this.transform.Translate(Vector2.left * 8 * Time.deltaTime / 2.7f);
        }
    }
}
