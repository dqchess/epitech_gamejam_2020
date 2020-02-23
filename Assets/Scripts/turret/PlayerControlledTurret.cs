﻿using UnityEngine;
using System.Collections;

public class PlayerControlledTurret : MonoBehaviour
{

    public string shootTouchName;
    public bool lockTurret;
    public GameObject weapon_prefab;
    public GameObject[] barrel_hardpoints;
    public float turret_rotation_speed = 3f;
    public float shot_speed;
    int barrel_index = 0;
    public float fireRate = 10.0f;
    private float nextFire = 0;
    public int damage;
    public GameObject parent;
    // Use this for initialization
    void Start()
    {
        nextFire = fireRate;
    }

    void playSound(string name)
    {
        if (name == "Projectile Sharp 1")
        {
            FindObjectOfType<SoundManagers>().Play("laserShot");
        }

    }

    void Update()
    {

        Vector2 turretPosition = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 direction = AimPointer.pointerPosition - turretPosition;
        if (lockTurret != true)
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.LerpAngle(transform.rotation.eulerAngles.z, (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) - 90f, turret_rotation_speed * Time.deltaTime)));

        if (Input.GetButtonDown(shootTouchName) && barrel_hardpoints != null && nextFire >= fireRate)
        {
            GameObject bullet = (GameObject)Instantiate(weapon_prefab, barrel_hardpoints[barrel_index].transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.up * shot_speed);
            bullet.GetComponent<Projectile>().firing_ship = parent;
            bullet.GetComponent<Projectile>().damage = damage;
            playSound(weapon_prefab.gameObject.name);


            barrel_index++;
            if (barrel_index >= barrel_hardpoints.Length)
                barrel_index = 0;
            nextFire = 0;
        }
        if (nextFire < fireRate)
            nextFire += Time.deltaTime;


    }


}