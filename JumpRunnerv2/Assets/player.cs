using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;

    public float speed;

    public float jumpPower;

    public GameObject platform;

    private Vector2 spawnPoint;

    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2d;

    private float i;
    private float pos;
    Scene thisScene;
    // Start is called before the first frame update
    void Start()
    {
        i = transform.position.x;
        pos = platform.transform.position.x + 7;
    }

    private void Awake()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();

        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(speed, 0f, 0f);

        if (Mathf.Floor(transform.position.x - i) == 7)
        {
            GameObject newPlatform = Instantiate(platform, new Vector2(pos, Random.Range(-3.0f, 3.0f)), Quaternion.identity);
            //Destroy(platform);
            //platform = newPlatform;
            pos = newPlatform.transform.position.x + 7;
            i = transform.position.x;
        }


        // Implement the jump here
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody2d.velocity = Vector2.up * jumpPower;
        }

        

        



        // Check if the player fell to the bottom
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("TitleScene");
        }
    }

    private bool IsGrounded()
    {
        float extraHeightText = 0.05f;
        RaycastHit2D raycastHit = Physics2D.Raycast(boxCollider2d.bounds.center, Vector2.down, boxCollider2d.bounds.extents.y + extraHeightText, platformLayerMask);
        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
            rayColor = Color.red;
        Debug.DrawRay(boxCollider2d.bounds.center, Vector2.down * (boxCollider2d.bounds.extents.y + extraHeightText), rayColor);
        return raycastHit.collider != null;
    }
}

    