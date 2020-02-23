using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWallManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] asteroids;
    private GameObject asteroidPrefab;

    private GameObject preshow = null;

    public WallManager wallManager;

    List<SpriteRenderer> spriteRenderers = new List<SpriteRenderer>();
    List<CircleCollider2D> collider2d = new List<CircleCollider2D>();
    List<Color> colours = new List<Color>();

    void setUpPreShow()
    {
        asteroidPrefab = asteroids[Random.Range(0, asteroids.Length)];
        preshow = Instantiate(asteroidPrefab) as GameObject;
        preshow.AddComponent<WallManager>();
        spriteRenderers = new List<SpriteRenderer>(preshow.GetComponentsInChildren<SpriteRenderer>());

        collider2d = new List<CircleCollider2D>(preshow.GetComponentsInChildren<CircleCollider2D>());

         for(int i = 0; i < spriteRenderers.Count; ++i)
        {
            colours.Add(spriteRenderers[i].color);
            spriteRenderers[i].color = Color.green;
            collider2d[i].isTrigger = true;

        }
    }

    void Start()
    {
        setUpPreShow();
    }


    private void SpawnWall(Vector3 pos)
    {
        if (preshow.GetComponent<WallManager>().isTriggered == true)
            return;
        for(int i = 0; i < spriteRenderers.Count; ++i)
        {
            spriteRenderers[i].color = colours[i];
            collider2d[i].isTrigger = false;


        }
        setUpPreShow();
    }
    void Update()
    {
        if (preshow == null)
            return;
        preshow.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetButtonDown("Fire1")) {
            SpawnWall(preshow.transform.position);
        }
    
        
    }

    void deactivate()
    {
        Destroy(preshow);
        preshow = null;
    }

       void activate()
    {
        setUpPreShow();
    }

}
            

