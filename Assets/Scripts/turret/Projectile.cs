using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public GameObject shoot_effect;
    public GameObject hit_effect;
    public GameObject firing_ship;
    public int damage = 5;

    // Use this for initialization
    void Start()
    {
        GameObject obj = (GameObject)Instantiate(shoot_effect, transform.position - new Vector3(0, 0, 5), Quaternion.identity); //Spawn muzzle flash
        obj.transform.parent = firing_ship.transform;
        Destroy(gameObject, 5f); //Bullet will despawn after 5 seconds
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject != firing_ship && col.gameObject.tag != "Projectile" && col.gameObject.layer == 8 && col.gameObject.tag != firing_ship.tag && col.isTrigger == false)
        {
            if (gameObject.tag != "Laser")
            {
                Destroy(gameObject);
                FindObjectOfType<SoundManagers>().Play("tower_shot_explosion");
                Instantiate(hit_effect, transform.position, Quaternion.identity);
            }
            else
            {
                FindObjectOfType<SoundManagers>().Play("tower_shot_explosion");
                Instantiate(hit_effect, col.gameObject.transform.position, Quaternion.identity);
            }
            if (col.gameObject.GetComponent<DamageableObj>())
            {
                Debug.Log("hit " + col.gameObject.name);
                col.gameObject.GetComponent<DamageableObj>().takeDamage(damage);
            }
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {

        if (col.gameObject != firing_ship && col.gameObject.tag != "Projectile" && col.gameObject.layer == 8 && gameObject.tag == "Laser" && col.gameObject.tag != firing_ship.tag && col.isTrigger == false)
        {

            if (col.gameObject.GetComponent<DamageableObj>())
            {
                col.gameObject.GetComponent<DamageableObj>().takeDamage(damage);
            }
        }
    }



}
