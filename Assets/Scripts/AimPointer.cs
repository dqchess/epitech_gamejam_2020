using UnityEngine;
using System;
using System.Collections;

[System.Serializable]
public class AimPointer : MonoBehaviour {
	
	public Texture pointerTexture;
	public float mouse_sensitivity_modifier = 15f;
	public static Vector2 pointerPosition;
	public static AimPointer instance;
	
	void Awake() {	
		pointerPosition = new Vector2 (Screen.width / 2, Screen.height / 2);
		instance = this;
	}
	
	void Start () {
		Screen.lockCursor = true;
	}
	
	void Update () {
		Screen.lockCursor = true;
		
		float x_axis = Input.GetAxis("Mouse X");
		float y_axis = Input.GetAxis("Mouse Y");
	
		pointerPosition += new Vector2(x_axis * mouse_sensitivity_modifier, y_axis * mouse_sensitivity_modifier);
											
		pointerPosition.x = Mathf.Clamp (pointerPosition.x, 0, Screen.width);
		pointerPosition.y = Mathf.Clamp (pointerPosition.y, 0, Screen.height);
	}
	
	void OnGUI() {
		if (pointerTexture != null)
			GUI.DrawTexture(new Rect(pointerPosition.x - (pointerTexture.width / 2), Screen.height - pointerPosition.y - (pointerTexture.height / 2), pointerTexture.width, pointerTexture.height), pointerTexture);
	}
}
