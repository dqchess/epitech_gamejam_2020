using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] asteroids;
    private GameObject asteroidPrefab;


    public WallManager wallManager;

    List<SpriteRenderer> spriteRenderers = new List<SpriteRenderer>();
    List<CircleCollider2D> collider2d = new List<CircleCollider2D>();

    public bool isTriggered = false;

    void Start()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spriteRenderers = new List<SpriteRenderer>(GetComponentsInChildren<SpriteRenderer>());
   
        
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            Debug.Log("Collide");
            for(int i = 0; i < spriteRenderers.Count; ++i)
            {
                spriteRenderers[i].color = Color.red;
            }
            isTriggered = true;
             Debug.Log(isTriggered);

        }

    }

      private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player") {
        
            for(int i = 0; i < spriteRenderers.Count; ++i)
            {
                spriteRenderers[i].color = Color.green;
            }
            isTriggered = false;
        }
    }
}
