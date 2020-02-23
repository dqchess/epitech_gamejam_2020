using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutRandWall : MonoBehaviour
{
    public GameObject[] allWalls;
    private GameObject wall1;
    private GameObject wall2;

    private Vector3[] allPos = new[] {
            new Vector3(4, 6, 2),
            new Vector3(9, -3, 2),
            new Vector3(8, 0, 2),
            new Vector3(2, -5, 2),
            new Vector3(-5, -3, 2),
            new Vector3(-12, -3, 2),
            new Vector3(-4, 0, 2),
            new Vector3(-4, 4, 2)
        };
    private Vector3 pos1;
    private Vector3 pos2;

    private int index1_w;
    private int index2_w;
    private int index1_p;
    private int index2_p;

    void Start()
    {

        index1_w = Random.Range(0, allWalls.Length);
        index2_w = Random.Range(0, allWalls.Length);
        index1_p = Random.Range(0, allPos.Length);
        index2_p = Random.Range(0, allPos.Length);


        wall1 = allWalls[index1_w];
        wall2 = allWalls[index2_w];
        pos1 = allPos[index1_p];
        pos2 = allPos[index2_p];

        GameObject a = Instantiate(wall1) as GameObject;
        GameObject b = Instantiate(wall2) as GameObject;


        a.transform.position = pos1;
        b.transform.position = pos2;

    }
}
