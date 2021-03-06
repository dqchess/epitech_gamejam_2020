﻿using UnityEngine;
using System.Collections;

public class PlayerControlledTurret : MonoBehaviour {

	public string shootTouchName;
    public int nbShots = 1;

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
	public bool isInPlayer = false;
	// Use this for initialization
	void Start () {
		nextFire = fireRate;
		if (isInPlayer)
			nextFire *= AttackerStats.instance.fireRateCoeff;
	}
	

	void Update () {
	
		Vector2 turretPosition = Camera.main.WorldToScreenPoint(transform.position);
		Vector3 direction = AimPointer.pointerPosition - turretPosition;
		if (lockTurret != true)
			transform.rotation = Quaternion.Euler (new Vector3(0, 0, Mathf.LerpAngle(transform.rotation.eulerAngles.z, (Mathf.Atan2 (direction.y,direction.x) * Mathf.Rad2Deg) - 90f, turret_rotation_speed * Time.deltaTime)));

		if (Input.GetButtonDown(shootTouchName) && barrel_hardpoints != null && nextFire >= fireRate) {
			for (int i = 0; i < nbShots; i++) {
				GameObject bullet = (GameObject) Instantiate(weapon_prefab, barrel_hardpoints[barrel_index].transform.position, transform.rotation);
				bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.up * ((isInPlayer) ? (shot_speed * AttackerStats.instance.shotSpeedCoeff) : shot_speed));
				bullet.GetComponent<Projectile>().firing_ship = parent;
				bullet.GetComponent<Projectile>().damage = damage;
				if (isInPlayer)
					bullet.GetComponent<Projectile>().damage = ((int)(((float)(bullet.GetComponent<Projectile>().damage)) * AttackerStats.instance.attackCoeff));

				barrel_index++;
				if (barrel_index >= barrel_hardpoints.Length)
					barrel_index = 0;
				nextFire = 0;
			}
		}
		if (nextFire < fireRate)
			nextFire += Time.deltaTime;
	}
}