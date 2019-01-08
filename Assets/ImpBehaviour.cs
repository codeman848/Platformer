using UnityEngine;
using System.Collections;
using System;

public class ImpBehaviour : MonoBehaviour {

    private float timer = 4f;
    public GameObject imp;
    public GameObject boss;
    public int bosshp;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        SpawnImps();
        if(GameObject.FindGameObjectWithTag("Boss") == null)
        {
            SpawnBoss();
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

    void SpawnImps()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            float randY = UnityEngine.Random.Range(-3.5f, 5f);
            float randX = UnityEngine.Random.Range(-3.5f, 5f);
            Instantiate(imp, new Vector3(randX, randY), Quaternion.identity);
            timer = 4f;
        }

    }
    public void SpawnBoss()
    {
        if (PlayerBehaviour.score >= 10 && GetComponent<BossBehavior>() == null)
        {
            boss.GetComponent<BossBehavior>().Bosshp = 3;
            Instantiate(boss, new Vector3(6f, 2.5f), Quaternion.identity);
        }
    }
    internal void SpawnBoss(int hp)
    {
        if (PlayerBehaviour.score >= 10)
        {
            var g = GameObject.FindGameObjectWithTag("Boss");
            if (g != null)
            {
                g.GetComponent<BossBehavior>().Bosshp = hp;
                var boss = new GameObject();
                if (g != null)
                {
                    boss = g;
                    Instantiate(boss, new Vector3(6f, 2.5f), Quaternion.identity);
                }
                else
                {
                    return;
                }
            }

            else
            {
                var t = GameObject.FindGameObjectWithTag("Boss(Clone)");
                t.GetComponent<BossBehavior>().Bosshp = hp;
                var boss = new GameObject();
                if (g != null)
                {
                    boss = t;
                    Instantiate(boss, new Vector3(6f, 2.5f), Quaternion.identity);
                }
                else
                {
                    return;
                }
            }
        }
    }
    
}
