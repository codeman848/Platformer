using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Timers;

public class PlayerBehaviour : MonoBehaviour {
    public float speed;
    public float sWidth = Screen.width;
    public float sHeight = Screen.height;
    public static int hp = 100;
    public Rigidbody2D rigidbody;
    public int HP
    {
        get
        {
            return hp;
        }

        set
        {
            hp = value;
        }
    }
    public AudioClip ImpDie;
    public AudioClip MuchioHit;
    public AudioClip music;
    public AudioSource PlayerAudio;
    public static int score = 0;
    public static int headCount;

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

    public static int HeadCount
    {
        get
        {
            return headCount;
        }

        set
        {
            headCount = value;
        }
    }

    // Use this for initialization
    void Start () {
        AudioSource.PlayClipAtPoint(music, new Vector3(0, 0, 0));
        score = 0;
        headCount = 0;
        hp = 100;
    }
	
	// Update is called once per frame
	void Update () {

        this.GetComponent<Transform>().position += new Vector3(speed, 0);
        speed += 0.000002f;
        if (hp <= 0)
        {
            SceneManager.LoadScene("LoseScene");
        }

        if (this.transform.position.x <= -12)
        {
            SceneManager.LoadScene("LoseScene");
        }

        //GameObject boss = GameObject.FindGameObjectWithTag("Boss");
        //if (boss.GetComponent<ImpBehaviour>().bosshp <= 0)
        //{
        //    SceneManager.LoadScene("WinScene");
        //}
    }
    void OnGUI()
    {
        Rect healthbox = new Rect(new Vector2(5, 25), new Vector2(200, 50));

        Texture2D texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, Color.green);
        texture.Apply();
        GUI.skin.box.normal.background = texture;
        GUI.Box(healthbox, GUIContent.none);
        GUI.color = Color.black;
        GUI.Label(new Rect(55, 55, 400, 200), hp + "%");


        Rect health = new Rect(new Vector2(5, 25), new Vector2(100, 25));


        GUI.color = Color.black;
        GUI.Label(new Rect(1200, 5, 400, 60), "<size=60>" + "Distance: " + score + "m" + "</size>");
        GUI.Label(new Rect(500, 5, 375, 60), "<size=60>" + "HeadCount: " + HeadCount +"</size>");

        if (GUI.RepeatButton(new Rect(new Vector2(100,800), new Vector2(200,75)), "Idle"))
        {
            this.GetComponent<Animator>().Play("Muchio_Idle");
            this.transform.Translate(Vector2.left * 8 * Time.deltaTime/2.7f);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.GetComponent<Animator>().Play("Muchio_Attack");
        }
        if (GUI.Button(new Rect(new Vector2(1600, 800), new Vector2(200, 75)), "Jump"))
        {
            if(this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Muchio_Run"))
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(50, 500), ForceMode2D.Force);
            }
            this.GetComponent<Animator>().Play("Muchio_Idle");
        }
        if (GUI.Button(new Rect(new Vector2(1350,800), new Vector2(200,75)), "Attack"))
        {
                this.GetComponent<Animator>().Play("Muchio_Attack");
        }
        else
        {
          //  this.GetComponent<Animator>().Play("Muchio_Idle");
        }
    }
    void OnCollisionStay2D(Collision2D col)
    {
        //Timer t = new Timer(1000);
        //t.Start();
        //Vector3 position = this.transform.position;
        if (this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Muchio_Attack") && col.gameObject.tag == "Imp")
        {
            this.GetComponent<AudioSource>().clip = ImpDie;
            this.GetComponent<AudioSource>().Play();
            HeadCount += 1;
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "Boss" && this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Muchio_Attack"))
        {
            //must add audiosource to player and play sdouinds from that can i can check duration of the clip playing
            if (!GetComponent<AudioSource>().isPlaying)
            {
                this.GetComponent<AudioSource>().clip = ImpDie;
                this.GetComponent<AudioSource>().Play();
                col.gameObject.GetComponent<BossBehavior>().Bosshp -= 1;
            }
            if (col.gameObject.GetComponent<BossBehavior>().Bosshp <= 0)
            {
                HeadCount += 5;
                Destroy(col.gameObject);
                SceneManager.LoadScene("WinScene");
            }
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Platform")
        {
            gameObject.GetComponent<Animator>().Play("Muchio_Run");
            Score += 1;
        }

        if (this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Muchio_Attack") && col.gameObject.tag == "Imp")
        {
            this.GetComponent<AudioSource>().clip = ImpDie;
            this.GetComponent<AudioSource>().Play();


            HeadCount += 1;
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "Imp" && this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Muchio_Idle") | this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Muchio_Run"))
        {
            AudioSource.PlayClipAtPoint(MuchioHit, new Vector3(0, 0, 0));

            hp = hp - 10;
            var x = this.GetComponent<Rigidbody2D>();
            x.AddForce(-new Vector2(250,0));
            this.GetComponent<SpriteRenderer>().color = Color.red;
        }

        if (col.gameObject.tag == "Boss" && this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Muchio_Idle") | this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Muchio_Run"))
        {
            AudioSource.PlayClipAtPoint(MuchioHit, new Vector3(0, 0, 0));

            hp = hp - 25;
            var x = this.GetComponent<Rigidbody2D>();
            x.AddForce(-new Vector2(250, 0));
            this.GetComponent<SpriteRenderer>().color = Color.red;
        }

        else
        {
            this.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
