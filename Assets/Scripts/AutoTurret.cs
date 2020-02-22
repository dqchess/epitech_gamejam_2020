using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTurret : MonoBehaviour
{
	public GameObject weapon_prefab;
	public GameObject[] barrel_hardpoints;
    public GameObject target;
	public float turret_rotation_speed = 3f;
	public float shot_speed;
	int barrel_index = 0;
	public float fireRate = 10.0f;
	private float nextFire = 0;
    public bool hasTarget;
	public GameObject parent;
    public int nbShots = 1;
    public int damage;
	// Use this for initialization
	void Start () {
		nextFire = fireRate;
        hasTarget = false;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") {
            hasTarget = true;
            target = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") {
            hasTarget = false;
            target = null;
        }
    } 

    void OnTriggerStay2D(Collider2D other) 
    {

    }
	

	void Update () {
		Vector2 turretPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (hasTarget) {
		    Vector2 targetpos = Camera.main.WorldToScreenPoint(target.transform.position);
		    Vector3 direction = targetpos - turretPosition;
		    transform.rotation = Quaternion.Euler (new Vector3(0, 0, Mathf.LerpAngle(transform.rotation.eulerAngles.z, (Mathf.Atan2 (direction.y,direction.x) * Mathf.Rad2Deg) - 90f, turret_rotation_speed * Time.deltaTime)));
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 10f, (LayerMask.GetMask("CanHit")));
            if (hit.collider != null && hit.collider.gameObject.layer == 8 && hit.collider.gameObject != gameObject && barrel_hardpoints != null && nextFire >= fireRate) {
                for (int i = 0; i < nbShots; i++) {
                    GameObject bullet = (GameObject) Instantiate(weapon_prefab, barrel_hardpoints[barrel_index].transform.position, transform.rotation);
                    bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.up * shot_speed);
                    bullet.GetComponent<Projectile>().firing_ship = parent;
                    bullet.GetComponent<Projectile>().damage = damage;
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
}
