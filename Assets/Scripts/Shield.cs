using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : DamageableObj
{
    // Start is called before the first frame update
    public float reloadTime = 20f;
    float actualTime = 0;
    bool isReloading = false;
    public GameObject shield;
    CircleCollider2D col;
    public override void takeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            hp = 0;
            Debug.Log("death");
            isReloading = true;
            shield.SetActive(false);
            GetComponent<CircleCollider2D>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading == true)
        {
            actualTime += Time.deltaTime;
            if (actualTime >= reloadTime)
            {
                isReloading = false;
                shield.SetActive(true);
                hp = maxHp;
                actualTime = 0;
                GetComponent<CircleCollider2D>().enabled = true;

            }
        }
    }
}
