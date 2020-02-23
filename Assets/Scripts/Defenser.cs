using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defenser : MonoBehaviour
{

    #region Singleton

    public static Defenser instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("ATTENTION !!!!");
            return;
        }
        instance = this;
    }

    #endregion

    public float crystals;
    public float gain;
    float t;

    void Start()
    {
        t = 0;
    }

    void Update()
    {
        t += Time.deltaTime;
        if (t > 1f) {
            crystals += gain; 
            t = 0;
        }
    }

    public void upgradeGain(int amount)
    {
        gain += amount;
    }
}
