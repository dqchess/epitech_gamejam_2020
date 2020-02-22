using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExternWallManager : MonoBehaviour
{
    public Transform t1;
    public Transform t2;
    public Transform t3;
    public Transform t4;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 camPos = Camera.main.ScreenToWorldPoint(new Vector3(0,Screen.height, 0));
        t1.position = camPos;
        t4.position = camPos;
        camPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,0, 0));
        t2.position = camPos;
        t3.position = camPos;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
