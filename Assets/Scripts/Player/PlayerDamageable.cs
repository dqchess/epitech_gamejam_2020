using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageable : DamageableObj
{
    override public void takeDamage(int damage)
    {
        hp -= damage;
        AttackerStats.instance.hp -= damage;
        healthBar.SetHealth(AttackerStats.instance.maxHp, AttackerStats.instance.hp);
        Debug.Log(name + " has taken " + damage + " damage, it now has " + AttackerStats.instance.hp + " health points !");
        if (AttackerStats.instance.hp <= 0)
        {
            hp = 0;
            AttackerStats.instance.hp = 0;
            Debug.Log(name + " is dead.");
            if (onDeath != null)
                onDeath.Invoke();
            // Destroy(gameObject);
        }
    }

    override public void increaseHp(int amount)
    {
        AttackerStats.instance.hp += amount;
        AttackerStats.instance.maxHp += amount;
        if (healthBar)
            healthBar.SetHealth(maxHp, hp);
    }
}
