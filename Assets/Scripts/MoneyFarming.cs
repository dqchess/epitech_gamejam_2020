using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyFarming : MonoBehaviour
{
    public float cristals;
    public float gain;
    float t;

    // Start is called before the first frame update
    void Start()
    {
        t = 0;
    }

    // Update is called once per frame
    void Update()
    {
        t+= Time.deltaTime;
        if (t > 1f) {
            cristals += gain; 
            t = 0;
        }
    }
}
