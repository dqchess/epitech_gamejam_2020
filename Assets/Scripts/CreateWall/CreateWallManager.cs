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
    List<PolygonCollider2D> collider2d = new List<PolygonCollider2D>();
    List<Color> colours = new List<Color>();

    void setUpPreShow()
    {
        asteroidPrefab = asteroids[Random.Range(0, asteroids.Length)];
        preshow = Instantiate(asteroidPrefab) as GameObject;
        preshow.AddComponent<WallManager>();
        spriteRenderers = new List<SpriteRenderer>(preshow.GetComponentsInChildren<SpriteRenderer>());

        collider2d = new List<PolygonCollider2D>(preshow.GetComponentsInChildren<PolygonCollider2D>());

         for(int i = 0; i < spriteRenderers.Count; ++i)
        {
            colours.Add(spriteRenderers[i].color);
            spriteRenderers[i].color = Color.green;
            collider2d[i].isTrigger = true;

        }
    }

    void Start()
    {
    }


    private void SpawnWall(Vector3 pos)
    {
        if (preshow.GetComponent<WallManager>().isTriggered == true) {
            FindObjectOfType<SoundManagers>().Play("fail_action");
            return;
        }
        for(int i = 0; i < spriteRenderers.Count; ++i)
        {
            spriteRenderers[i].color = colours[i];
            collider2d[i].isTrigger = false;
            FindObjectOfType<SoundManagers>().Play("create_wall");
          

        }

        preshow = null;

    }
    void Update()
    {
       if (Input.GetButtonDown("Fire2")) {
            deactivate();
        }

        if (Input.GetButtonDown("Fire3")) {
            activate();
        }
        if (preshow == null)
            return;
        preshow.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetButtonDown("Fire1")) {
            SpawnWall(preshow.transform.position);
        }


    
        
    }

    public void deactivate()
    {
        FindObjectOfType<SoundManagers>().Play("toggle_wall_deactivate");
        Destroy(preshow);
        preshow = null;
    }

    public void activate()
    {

        FindObjectOfType<SoundManagers>().Play("toggle_wall_activate");
        if (preshow == null)
             setUpPreShow();

        
    }

}
            

