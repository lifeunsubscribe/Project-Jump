using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class jump : MonoBehaviour
{
	Scene thisScene;
    public float jumpPower;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space"))
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up*jumpPower,0);
        }
		if(transform.position.y < -10){
		Destroy(gameObject);
		 thisScene = SceneManager.GetActiveScene();
         SceneManager.LoadScene(thisScene.name);
		}
    }
}
