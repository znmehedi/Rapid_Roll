using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class BoundPlayer : MonoBehaviour
{
    private float xLeft = -2.424f, xRight = 2.424f, yDown = -5f;
    private Vector2 xBound;

    [SerializeField]
    private Transform playerHold;
    private Vector2 playerHoldOffset;
    private Animator playerEnd;

    
    private float speed = 1f;
    
    private void Awake()
    {
        playerEnd = GetComponent<Animator>();
            
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xboundCheck();
    }
    void xboundCheck()
    {
        xBound = transform.position;
        if (xBound.x < xLeft)
            xBound.x = xLeft;
        else if (xBound.x > xRight)
            xBound.x = xRight;

        if (xBound.y < yDown)
        {
            PlayerControl.gameSet = false;
            playerEnd.Play("playerEnd");

            
            while (xBound.y < yDown)
            {
                playerHoldOffset = playerHold.position;
                playerHoldOffset.y += speed * Time.deltaTime;
                playerHold.position = playerHoldOffset;
            }
        }

        transform.position = xBound;
    }
}
