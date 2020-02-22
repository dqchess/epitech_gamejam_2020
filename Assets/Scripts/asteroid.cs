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
        if (transform.position.x >= 16)
        {

            dirX = Random.Range(-0.5f, 0.0f);
        }
        else
        {
            dirX = Random.Range(0.0f, 0.5f);
        }
        if (transform.position.y >= 9)
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
        if (transform.position.x < -21 || transform.position.x > 21)
        {
            Destroy(this.gameObject);
        }
        if (transform.position.y < -13 || transform.position.y > 13)
        {
            Destroy(this.gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        // FindObjectOfType<SoundManagers>().Play("Impact_Asteroid");
        Debug.Log("impact");
    }

}
