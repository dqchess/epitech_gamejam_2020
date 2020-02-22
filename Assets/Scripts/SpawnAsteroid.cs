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


        Debug.Log("upLeft >- " + upLeft);
        Debug.Log("downLeft >- " + downLeft);
        Debug.Log("downRight >- " + downRight);
        up = upLeft.y;
        down = downRight.y;
        left = downLeft.x;
        right = downRight.x;

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
            posY = Random.Range(down - 5, down);
        }
        else
        {
            posY = Random.Range(up, up + 5);
        }
        if (RightLeft >= 0)
        {
            posX = Random.Range(left - 5, left);
        }
        else
        {
            posX = Random.Range(right, right + 5);

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