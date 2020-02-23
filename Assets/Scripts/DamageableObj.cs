using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableObj : MonoBehaviour
{
    // Start is called before the first frame update
    public float hp;
    public float maxHp;
    public HealthBar healthBar;
    public int regenAmount;

    virtual public void takeDamage(int damage)
    {
        hp -= damage;
        if (healthBar)
            healthBar.SetHealth(maxHp, hp);
        if (hp <= 0)
        {
            hp = 0;
            Debug.Log(name + " is dead.");
            Destroy(gameObject);
        }
    }
    public void increaseHp(int amount)
    {
        maxHp += amount;
        hp += amount;
        if (healthBar)
            healthBar.SetHealth(maxHp, hp);
    }

    public void incrasePlayerHp(int amount)
    {
        AttackerStats.instance.maxHp += amount;
        AttackerStats.instance.hp += amount;
    }
}
