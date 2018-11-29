using UnityEngine.UI;
using System.Collections;
using UnityEngine;

public class RyTrPlayerController : MonoBehaviour
{

    public float speed;
    public Text winText;
    private Animator anim;

    private Rigidbody2D rb2d;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        winText.text = "";
        anim = GetComponent<Animator>();
        Destroy(gameObject, 2);
    }


    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        rb2d.velocity = new Vector2(moveHorizontal * speed, rb2d.velocity.y);


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

}