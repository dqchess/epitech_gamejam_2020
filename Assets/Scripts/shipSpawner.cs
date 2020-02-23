using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class shipSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject [] ships;
    public GameObject player;
    public int amount = 1;
    public int level = 0;
    public Transform [] spawnPoints;
    void Start()
    {
        
    }

    public void SpawnShip()
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject tmp = Instantiate(ships[level], spawnPoints[Random.Range(0, 4)].position,Quaternion.identity, transform);
            tmp.GetComponent<AIDestinationSetter>().target = player.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
