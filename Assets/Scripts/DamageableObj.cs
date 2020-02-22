using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableObj : MonoBehaviour
{
    // Start is called before the first frame update
    public float hp;
    public float maxHp;
    public int regenAmount;

    virtual public void takeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0) {
            hp = 0;
            Debug.Log(name + " is dead.");
            Destroy(gameObject);
        }
    }
}
