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
    public Text endText;
    bool hazardHit = true;
    private bool facingRight = true;


    public Text CollectText;
    public Text loseText;
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

        if (facingRight == false && moveHorizontal > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveHorizontal < 0)
        {
            Flip();
        }


        if (timer > 0 && isAlive == true)
        {
            timer = timer - Time.deltaTime;
        }

        else if (timer <= 0 || isAlive == false)
        {

            int wholeTime = (int)timer;

            endText.text = "You saved the fossil!";
            anim.SetBool("Fin", true);

            RyTrGameLoader.AddScore(wholeTime);

            StartCoroutine(ByeAfterDelay(2));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag == "Hazard")
        {
            endText.text = "You lose!";
        }

        
    }


private void Update()
    { 
if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))

        {
            anim.SetBool("isTilting", true);
        }
        else
        {
            anim.SetBool("isTilting", false);
        }
    }



    void Flip()
    {
        facingRight = !facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
    }


    IEnumerator ByeAfterDelay(float time)
    {
        yield return new WaitForSeconds(time);

 
        RyTrGameLoader.gameOn = false;
    }
}