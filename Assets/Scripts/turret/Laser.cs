using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {
	public GameObject shoot_effect;
	public GameObject hit_effect;
	public GameObject firing_ship;
	public int damage = 5;
	
	// Use this for initialization
	void Start () {
		GameObject obj = (GameObject) Instantiate(shoot_effect, transform.position  - new Vector3(0,0,5), Quaternion.identity); //Spawn muzzle flash
		obj.transform.parent = firing_ship.transform;
		Destroy(gameObject, 5f); //Bullet will despawn after 5 seconds
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	void OnTriggerEnter2D(Collider2D col) {

		if (col.gameObject != firing_ship && col.gameObject.tag != "Projectile" && col.gameObject.layer == 8) {
			Debug.Log(col.gameObject.name);
			Instantiate(hit_effect, transform.position, Quaternion.identity);
			Destroy(gameObject);
			if (col.gameObject.GetComponent<DamagableObj>()) {
				Debug.Log("faefaefzfzaazf");
				col.gameObject.GetComponent<DamagableObj>().takeDamage(damage);
			}
		}
	}
	
	
	
}
