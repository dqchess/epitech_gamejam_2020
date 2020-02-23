using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageableObj : MonoBehaviour
{
    // Start is called before the first frame update
    public float hp;
    public float maxHp;
    public HealthBar healthBar;
    public int regenAmount;
    public GameObject slayer;

    public UnityEvent onDeath = new UnityEvent();

    virtual public void takeDamage(int damage, GameObject origin)
    {
        slayer = origin;
        hp -= damage;
        if (healthBar)
            healthBar.SetHealth(maxHp, hp);
        if (hp <= 0)
        {
            hp = 0;
            Debug.Log(name + " is dead.");
            if (onDeath != null)
                onDeath.Invoke();
            if (gameObject.name != "Station")
                Destroy(gameObject);
        }
    }
    virtual public void increaseHp(int amount)
    {
        maxHp += amount;
        hp += amount;
        if (healthBar)
            healthBar.SetHealth(maxHp, hp);
    }
}
