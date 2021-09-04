using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Platform : MonoBehaviour
{
    private float xLeft = -1.72f, xRight = 1.72f;

    private float xPoint, yPoint=-6;
    [SerializeField]
    private GameObject[] platform;
    private GameObject defPlatform;

    
    [SerializeField]
    private float ReleaseSpeed = 2f;
    private float CurrentReleaseSpeed;
 


    // Start is called before the first frame update
    void Start()
    {
        CurrentReleaseSpeed = ReleaseSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerControl.gameSet)
        release();
    }
    void release()
    {
        if (ReleaseSpeed > CurrentReleaseSpeed)
        {
            ReleaseSpeed = 0f;
            xPoint = Random.Range(xLeft, xRight);
            transform.position = new Vector3(xPoint, yPoint,  0f);
            defPlatform = platform[Random.Range(0, platform.Length)];
            Instantiate(defPlatform, transform.position, defPlatform.transform.rotation);
        }
        ReleaseSpeed += Time.deltaTime;
    }
}
