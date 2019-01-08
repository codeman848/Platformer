using UnityEngine;
using System.Collections;

public class ImpBehaviour2 : MonoBehaviour {
    public int bosshp;
    public GameObject boss;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (this.gameObject.transform.position.x <= -10)
        {
            Destroy(this.gameObject);
        }
        SpawnBoss();

    }
    void OnCollisionEnter2D(Collision2D col)
    {
    }
    void SpawnBoss()
    {
        if (PlayerBehaviour.score >= 15)
        {
            if (GameObject.FindGameObjectWithTag("Boss") == null)
            {
                boss.GetComponent<ImpBehaviour2>().bosshp = 1;
                Instantiate(boss, new Vector3(5f, 2.5f), Quaternion.identity);
            }
        }
    }

}
