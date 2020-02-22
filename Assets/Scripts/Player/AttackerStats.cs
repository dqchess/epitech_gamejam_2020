using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerStats : MonoBehaviour
{

    #region Singleton

    public static AttackerStats instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There is another AttackerStats instance");
            return;
        }
        instance = this;
    }

    #endregion

    public float crystals = 0;
    public int health = 100;
    public int damage = 100;
    public float miningValue = 10;
}
