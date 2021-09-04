using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public static bool gameSet = true;
    private bool GameOn=false;
    [SerializeField]
    private float MoveSpeed = 0.5f;
    private Rigidbody2D playerBody;

    private Animator playerEnd;
    

    private void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
        playerEnd = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(gameSet)
        move();
    }
    void move()
    {
        if (Input.GetAxisRaw("Horizontal") > 0f)
            playerBody.velocity = new Vector2(MoveSpeed, playerBody.velocity.y);


        else if (Input.GetAxisRaw("Horizontal") < 0f)
            playerBody.velocity = new Vector2(-MoveSpeed, playerBody.velocity.y);
        
        //bound
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("SpikePlatform") || collision.gameObject.CompareTag("Finish"))
        {

            playerEnd.Play("PlayerEnd");
 
            gameSet = false;


        }

        if (collision.gameObject.CompareTag("FixedPlatform"))
            GameOn = true;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("UpSpike") && GameOn)
        {
            gameSet = false;
            playerEnd.Play("PlayerEnd");
        }
    }


}
