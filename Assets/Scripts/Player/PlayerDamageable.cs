using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageable : DamageableObj
{

    public HealthBar playerHealthBar;
    override public void takeDamage(int damage)
    {
        hp -= damage;
        AttackerStats.instance.hp -= damage;
        playerHealthBar.SetHealth(AttackerStats.instance.maxHp, AttackerStats.instance.hp);
        Debug.Log(name + " has taken " + damage + " damage, it now has " + AttackerStats.instance.hp + " health points !");
        if (AttackerStats.instance.hp <= 0)
        {
            hp = 0;
            AttackerStats.instance.hp = 0;
            Debug.Log(name + " is dead.");
            Destroy(gameObject);
        }
    }
}
