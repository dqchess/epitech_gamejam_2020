using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroid : MonoBehaviour
{
    public float speed = 5f;
    private float dirX = 1.0f;
    private float dirY = 0.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;

    private float up;
    private float down;
    private float left;
    private float right;


    // Use this for initialization
    void Start()
    {
        Vector3 upLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));
        Vector3 downLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 downRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));


        up = upLeft.y;
        down = downRight.y;
        left = downLeft.x;
        right = downRight.x;

        if (transform.localPosition.x >= right)
        {

            dirX = Random.Range(-0.5f, 0.0f);
        }
        else
        {
            dirX = Random.Range(0.0f, 0.5f);
        }
        if (transform.localPosition.y >= up)
        {
            dirY = Random.Range(-0.5f, 0.0f);
        }
        else
        {
            dirY = Random.Range(0.0f, 0.5f);
        }
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(dirX * speed, dirY * speed);

    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<CircleCollider2D>().isTrigger == true)
            return;
        if (transform.position.x < -21 || transform.position.x > 21)
        {
            Destroy(this.gameObject);
        }
        if (transform.localPosition.y < down - 10 || transform.localPosition.y > up + 10)
        {
            Destroy(this.gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        FindObjectOfType<SoundManagers>().Play("Impact_Asteroid");

    }

}
