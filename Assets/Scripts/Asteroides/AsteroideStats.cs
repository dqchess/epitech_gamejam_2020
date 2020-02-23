using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroideStats : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float mass = GetComponent<Rigidbody2D>().mass = 1 + 300 * GetComponent<CircleCollider2D>().radius * GetComponent<CircleCollider2D>().radius;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
