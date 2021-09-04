using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScroll : MonoBehaviour
{
    private float scrollSpeed = 0.1f;
    private MeshRenderer body;
    private Vector3 offset;
    private void Awake()
    {
        body = GetComponent<MeshRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerControl.gameSet)
        scroll();
    }
    void scroll()
    {
        offset = body.sharedMaterial.GetTextureOffset("_MainTex");
        offset.y += scrollSpeed * Time.deltaTime;
        body.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
