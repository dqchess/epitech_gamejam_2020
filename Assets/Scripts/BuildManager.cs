using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static BuildManager instance;
    public GameObject [] turrets;
    public GameObject actualTurret;
    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("arggh to many instance");
            return;
        }
        instance = this;
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        actualTurret = turrets[0];
    }

    public void changeTurret(int num)
    {
        actualTurret = turrets[num];
    }
}
