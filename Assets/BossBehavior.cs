using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour {

    public static int bosshp;

    public int Bosshp
    {
        get
        {
            return bosshp;
        }

        set
        {
            bosshp = value;
        }
    }

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (this.transform.position.x <= -12)
        {
            ImpBehaviour i = new ImpBehaviour();
            var boss = GameObject.FindGameObjectWithTag("Boss");
            
            i.SpawnBoss(boss.GetComponent<BossBehavior>().Bosshp);
            Destroy(boss);
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
