using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpProperties : MonoBehaviour {

    public int bosshp;
    public GameObject boss;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.transform.position.x <= -10)
        {
            Destroy(this.gameObject);
        }

    }
    void OnCollisionStay2D(Collision2D col)
    {
        Vector3 position = this.transform.position;
        if (col.gameObject.tag == "Platform")
        {
            position.x -= 0.067f;
            this.transform.position = position;
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Vector3 position = this.transform.position;
        if (col.gameObject.tag == "Platform")
        {
            position.x -= 0.067f;
            this.transform.position = position;
        }
    }

}