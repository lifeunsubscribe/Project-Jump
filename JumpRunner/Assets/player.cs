using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed;

    public float jumpPower;

    public GameObject platform;

    private Vector2 spawnPoint;

    private float i;
    private float pos;
    // Start is called before the first frame update
    void Start()
    {
        i = transform.position.x;
        pos = platform.transform.position.x + 7;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate (speed, 0f, 0f);
        
        if (Mathf.Floor(transform.position.x - i) == 7)
        {
            GameObject newPlatform = Instantiate(platform,new Vector2 (pos,Random.Range(-3.0f, 3.0f)), Quaternion.identity);
            //Destroy(platform);
            //platform = newPlatform;
            pos = newPlatform.transform.position.x + 7;
            i = transform.position.x;
        }
        

    }
    
    
}
