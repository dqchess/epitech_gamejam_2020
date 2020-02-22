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


    // Use this for initialization
    void Start()
    {
        if (transform.position.x >= 20)
        {

            dirX = Random.Range(-0.5f, 0.0f);
        }
        else
        {
            dirX = Random.Range(0.0f, 0.5f);
        }
        if (transform.position.y >= 12)
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
        if (transform.position.x < -30 || transform.position.x > 30)
        {
            Destroy(this.gameObject);
        }
        if (transform.position.y < -30 || transform.position.y > 30)
        {
            Destroy(this.gameObject);
        }
    }
}
