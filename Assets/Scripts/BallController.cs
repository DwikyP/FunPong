using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public int force;
    Rigidbody2D rigid;
    int score1;
    int score2;
    Text scoreUIP1;
    Text scoreUIP2;
    GameObject finishPanel;
    Text txtWinner;
    AudioSource audio;
    public AudioClip hitSound;
    public AudioClip PointSound;
    public AudioClip winSound;

    // Start is called before the first frame update
    void Start()
    {
        score1 = 0;
        score2 = 0;
        scoreUIP1 = GameObject.Find("Score1").GetComponent<Text>();
        scoreUIP2 = GameObject.Find("Score2").GetComponent<Text>();
        rigid = GetComponent<Rigidbody2D>();
        Vector2 direction = new Vector2(2, 0).normalized;
        rigid.AddForce(direction * force);
        finishPanel = GameObject.Find("FinishPanel");
        finishPanel.SetActive(false);
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        Color color1 = new Color(1f, 0.39f, 0f);
        Color color2 = new Color(0.29f, 0.36f, 1f);
        

        if (coll.gameObject.name == "RightBound")
        {
            score1++;
            ShowScore();
            if(score1 == 5)
            {
                audio.PlayOneShot(winSound);
                finishPanel.SetActive(true);
                txtWinner = GameObject.Find("Winner").GetComponent<Text>();
                txtWinner.text = "Player Red Win";
                txtWinner.color = color1;
                Destroy(gameObject);
                return;

            }
            audio.PlayOneShot(PointSound);
            ResetBall();
            Vector2 direction = new Vector2(2, 0).normalized;
            rigid.AddForce(direction * force);
        }

        if (coll.gameObject.name == "LeftBound")
        {
            score2++;
            ShowScore();
            if (score2 == 5)
            {
                finishPanel.SetActive(true);
                txtWinner = GameObject.Find("Winner").GetComponent<Text>();
                txtWinner.text = "Player Blue Win";
                txtWinner.color = color2;
                Destroy(gameObject);
                return;

            }
            audio.PlayOneShot(PointSound);
            ResetBall();
            Vector2 direction = new Vector2(-2, 0).normalized;
            rigid.AddForce(direction * force);

        }

        if(coll.gameObject.name == "RedBet" || coll.gameObject.name == "BlueBet")
        {
            audio.PlayOneShot(hitSound);
            float angle = (transform.position.y - coll.transform.position.y) * 5f;
            Vector2 direction = new Vector2(rigid.velocity.x, angle).normalized;
            rigid.velocity = new Vector2(0, 0);
            rigid.AddForce(direction * force * 2);
        }
        
    }
    void ResetBall()
    {
        transform.localPosition = new Vector3(0, 0, -1);
        rigid.velocity = new Vector2(0, 0);
    }
    private void ShowScore()
    {
        scoreUIP1.text = score1 + "";
        scoreUIP2.text = score2 + "";
    }

}
