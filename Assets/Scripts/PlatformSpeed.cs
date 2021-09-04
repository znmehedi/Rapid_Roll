using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlatformSpeed : MonoBehaviour
{
    private Vector2 offset;
    [SerializeField]
    private float speed=1f;
    private float upperBound=5.5f;
    private float BreakUpper = 3f, BreakLower = -2f;
    private float xLeft = -1.837f, xRight = 1.837f;
    private float BreakPoint;
    public bool isSpike;
    private bool canMove = true, canBreak=false;

    private bool moveHorizontal=false;

    private float rightLeft;

    private Animator breakAnim;
    private float animSpeed=1f;
    private Rigidbody2D movePlaform;

    private void Awake()
    {
        breakAnim = GetComponent<Animator>();
        movePlaform = GetComponent<Rigidbody2D>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        if (!isSpike && Random.Range(0, 7)  > 5)
        {
            canBreak = true;
            BreakPoint = Random.Range(BreakLower, BreakUpper);
        }

        //horizontal Move
        if(Random.Range(0, 6) > 3)
            moveHorizontal = true;
        if (Random.Range(0, 2) == 1)
            rightLeft = 1f;
        else
            rightLeft = -1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove && PlayerControl.gameSet)
        Speed();

        if(canBreak && offset.y>=BreakPoint && PlayerControl.gameSet)
        BreakPlatform();

        if (!PlayerControl.gameSet)
            movePlaform.velocity = new Vector2(0f, 0f);
    }

    void Speed()
    {
        offset = transform.position;
        //offset.y += speed * Time.deltaTime;
        //transform.position = offset;
        
        if (moveHorizontal && offset.y<=BreakUpper && offset.y>=BreakLower)
        {

            //With xRight - xLeft bound
            
                movePlaform.velocity = new Vector2(rightLeft*speed, movePlaform.velocity.y);

            if ((offset.x < xLeft) || (offset.x > xRight))
            {
                moveHorizontal = false;
            }

        }
        else
            movePlaform.velocity = new Vector2(0f, speed);
        //fixBound


        //destroy platform
        if (offset.y > upperBound)
        {
            Destroy(gameObject);
        }
    }
    void BreakPlatform()
    {
        canMove = false;
        breakAnim.Play("BreakPlatform");
        breakAnim.speed = animSpeed;
        //animspeed["BreakPlatform"].speed = animSpeed;
        Destroy(gameObject, 0.1f);
    }
}
