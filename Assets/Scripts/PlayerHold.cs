using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerHold : MonoBehaviour
{
    private float HoldTill = -5.071f;
    [SerializeField]
    private float HoldSpeed = 0.5f;
    private Vector2 HoldOffset;
    private bool canHold = false;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (canHold)
            Holding();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canHold = true;
        }

    }
    void Holding()
    {
        HoldOffset = gameObject.transform.position;
        if(HoldTill > HoldOffset.y)
        {
            HoldOffset = gameObject.transform.position;
            HoldOffset.y += HoldSpeed * Time.deltaTime;
            gameObject.transform.position = HoldOffset;
        }
    }
}
