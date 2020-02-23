using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageable : DamageableObj
{
    override public void takeDamage(int damage)
    {
        hp -= damage;
        Debug.Log(name + " has taken " + damage + " damage, it now has " + hp + " health points !");
        AttackerStats.instance.health -= damage;
        if (AttackerStats.instance.health <= 0)
        {
            hp = 0;
            AttackerStats.instance.health = 0;
            Debug.Log(name + " is dead.");
            Destroy(gameObject);
        }
    }
}
