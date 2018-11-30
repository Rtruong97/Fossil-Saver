using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RyTrPlayerController : MonoBehaviour
{

    public float speed;
    private Animator anim;
    public float timer;
    private Rigidbody2D rb2d;
    private int count;
    public int wholetime;
    public bool isAlive;
    public Text SurviveText;
    public Text endText;


    public Text CollectText;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        timer = 10;
        count = 0;
        endText.text = "";
        isAlive = true;
    }


    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(moveHorizontal * speed, rb2d.velocity.y);

        if (timer > 0 && isAlive == true)
        {
            timer = timer - Time.deltaTime;
        }
        
        else if (timer <= 0 || isAlive == false)
        {
            
            int wholeTime = (int)timer;

            endText.text = "You saved the fossil!";

            GameObject.active = false;

            RyTrGameLoader.AddScore(wholeTime);

            StartCoroutine(ByeAfterDelay(2));

        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {

            RyTrGameLoader.AddScore(1);

    }

            private void Update()
    {
        Vector3 characterScale = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = -1;
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = 1;
        }

        transform.localScale = characterScale;

    }

    IEnumerator ByeAfterDelay(float time)
    {
        yield return new WaitForSeconds(time);

 
        RyTrGameLoader.gameOn = false;
    }
}