using UnityEngine;
using System.Collections;

public class PotionBehavior : MonoBehaviour {

    public GameObject potion;
   // private float timer = 8f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        SpawnPotions();
	}
    void SpawnPotions()
    {
       // timer -= Time.deltaTime;

      //  if (timer <= 0f)
      //  {
      //      float randY = Random.Range(-3.5f, 5f);
       //     Instantiate(potion, new Vector3(2.5f, randY), Quaternion.identity);
       //     timer = 8f;
      //  }

    }
}
