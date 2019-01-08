using UnityEngine;
using System.Collections;

public class backgroundBehaviour : MonoBehaviour {

    private Vector3 pos;

    public Vector3 Pos
    {
        get
        {
            return pos;
        }

        set
        {
            pos = value;
        }
    }

    // Use this for initialization
    void Start () {


    }
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(Vector2.left * 2f * Time.deltaTime);

        if(this.transform.position.x <= -22.40f)
        {
            GameObject bg = this.gameObject;
            Instantiate(this, new Vector3(22.40f, 0,1), Quaternion.identity);
            //bg.transform.position.Set(this.transform.position.x,this.transform.position.y,1);
            Destroy(bg);
        }

    }
}
