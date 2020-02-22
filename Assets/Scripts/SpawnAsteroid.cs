using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroid : MonoBehaviour
{
    public GameObject[] asteroids;
    private GameObject asteroidPrefab;
    public float respawnTime = 5.0f;
    private Vector2 screenBounds;
    private int UpDown = 0;
    private int RightLeft = 0;

    private float posX;
    private float posY;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(asteroidWave());

        UpDown = Random.Range(-1, 1);
        RightLeft = Random.Range(-1, 1);
    }
    private void spawnEnemy()
    {
        asteroidPrefab = asteroids[Random.Range(0, asteroids.Length)];

        GameObject a = Instantiate(asteroidPrefab) as GameObject;
        if (UpDown >= 0)
        {
            posY = Random.Range(-20, -12);
        }
        else
        {
            posY = Random.Range(12, 20);
        }
        if (RightLeft >= 0)
        {
            posX = Random.Range(-25, -20);
        }
        else
        {
            posX = Random.Range(20, 25);

        }

        a.transform.position = new Vector3(posX, posY, 2);

        UpDown = Random.Range(-1, 1);
        RightLeft = Random.Range(-1, 1);

    }
    IEnumerator asteroidWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    }
}