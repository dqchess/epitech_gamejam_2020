using UnityEngine;
using System.Collections;

public class ExampleShipControl : MonoBehaviour {

	public bool slideAttaque = false;
	public float acceleration_amount = 1f;
	public float rotation_speed = 1f;
	public GameObject turret;
	public float turret_rotation_speed = 3f;

	// Use this for initialization
	void Start () {
	}


	// Update is called once per frame
	void Update () {

		AttackerStats attacker = GetComponentInParent(typeof(AttackerStats)) as AttackerStats;



		if (Input.GetKey(KeyCode.Z)) {//forward
			GetComponent<Rigidbody2D>().AddForce(transform.up * acceleration_amount * attacker.moveSpeedCoeff * Time.deltaTime);

		}
		// if (Input.GetKey(KeyCode.S)) {//back
		// 	GetComponent<Rigidbody2D>().AddForce((-transform.up) * acceleration_amount * attacker.moveSpeedCoeff * Time.deltaTime);

		// }
		if (slideAttaque == true) {
			if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.Q)) {//slide left
				GetComponent<Rigidbody2D>().AddForce((-transform.right) * acceleration_amount * attacker.moveSpeedCoeff * 0.6f  * Time.deltaTime);
				//print ("strafeing");
			}
			if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)) {//slide right
				GetComponent<Rigidbody2D>().AddForce((transform.right) * acceleration_amount * attacker.moveSpeedCoeff * 0.6f  * Time.deltaTime);

			}
		}

		if (!Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)) {//turn right
			GetComponent<Rigidbody2D>().AddTorque(-rotation_speed * attacker.rotateSpeedCoeff  * Time.deltaTime);

		}
		if (!Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.Q)) {//turn left
			GetComponent<Rigidbody2D>().AddTorque(rotation_speed * attacker.rotateSpeedCoeff  * Time.deltaTime);

		}
		if (Input.GetKey(KeyCode.S)) {//stop move
			GetComponent<Rigidbody2D>().angularVelocity = Mathf.Lerp(GetComponent<Rigidbody2D>().angularVelocity, 0, rotation_speed * attacker.rotateSpeedCoeff * 0.06f * Time.deltaTime);
			GetComponent<Rigidbody2D>().velocity = Vector2.Lerp(GetComponent<Rigidbody2D>().velocity, Vector2.zero, acceleration_amount * attacker.moveSpeedCoeff * 0.06f * Time.deltaTime);
		}


  		Vector3 upLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));
        Vector3 downLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 downRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
        Vector3 upRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
		Vector3 vel = GetComponent<Rigidbody2D>().velocity;

		// Debug.Log("transform.position.y ALO: " + transform.position.y);
		// Debug.Log("transform.position.z ALO: " + transform.position.z);
		// Debug.Log("transform.position.x ALO: " + transform.position.x);
		 // X axis
		if (transform.position.x <= upLeft.x) {
			Debug.Log("CC");
			transform.position = new Vector3(upLeft.x, transform.position.y, 0);
		} else if (transform.position.x >= upRight.x) {
			transform.position = new Vector3(upRight.x, transform.position.y, 0);
		}

		// Y axis
		if (transform.position.y <= downLeft.y) {

			transform.position = new Vector3(transform.position.x, downLeft.y, 0);
		} else if (transform.position.y >= upLeft.y) {
			transform.position = new Vector3(transform.position.x, upLeft.y, 0);
		}


	}
}
