using UnityEngine;
using System.Collections;

public class PlayerControlledTurret : MonoBehaviour {

	public GameObject weapon_prefab;
	public GameObject[] barrel_hardpoints;
	public float turret_rotation_speed = 3f;
	public float shot_speed;
	int barrel_index = 0;
	public float fireRate = 10.0f;
	private float nextFire = 0;
	// Use this for initialization
	void Start () {
		nextFire = fireRate;
	}
	

	void Update () {
	
		Vector2 turretPosition = Camera.main.WorldToScreenPoint(transform.position);
		Vector3 direction = AimPointer.pointerPosition - turretPosition;
		transform.rotation = Quaternion.Euler (new Vector3(0, 0, Mathf.LerpAngle(transform.rotation.eulerAngles.z, (Mathf.Atan2 (direction.y,direction.x) * Mathf.Rad2Deg) - 90f, turret_rotation_speed * Time.deltaTime)));

		if (Input.GetButtonDown("Fire1") && barrel_hardpoints != null && nextFire >= fireRate) {
			GameObject bullet = (GameObject) Instantiate(weapon_prefab, barrel_hardpoints[barrel_index].transform.position, transform.rotation);
			bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.up * shot_speed);
			bullet.GetComponent<Projectile>().firing_ship = transform.parent.gameObject;
			barrel_index++;
			if (barrel_index >= barrel_hardpoints.Length)
				barrel_index = 0;
			nextFire = 0;
		}
		if (nextFire < fireRate)
			nextFire += Time.deltaTime;
	}
}
