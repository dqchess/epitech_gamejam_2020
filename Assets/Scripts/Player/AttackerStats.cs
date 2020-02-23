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
    public float hp = 100;
    public float maxHp = 100;

    public int damage = 100;
    public float miningValue = 1;

    public float attackCoeff = 1f;
    public float fireRateCoeff = 1f;
    public float rotateSpeedCoeff = 1f;
    public float moveSpeedCoeff = 1f;
    public float shotSpeedCoeff = 1f;
    public int level = 0;
    
    public void increaseMoveSpeedCoeff(float value)
    {
        moveSpeedCoeff += value;
    }

    public void increaseAttackCoeff(float value)
    {
        attackCoeff += value;
    }

    public void decreaseAttack(float value)
    {
        attackCoeff -= value;
    }

    public void increaseRotateSpeedCoeff(float value)
    {
        rotateSpeedCoeff += value;
    }

    public void increaseMining(float value)
    {
        miningValue += value;
    }
}
