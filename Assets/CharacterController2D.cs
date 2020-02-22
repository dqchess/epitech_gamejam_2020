using System.Collections;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    private float _horizontalInput = 0;
    private float _verticalInput = 0;
    public int movementSpeed = 0;
    public float rotationSpeed = 0;

    Rigidbody2D rb2D;

    void Start() {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update() {
        GetPlayerInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
        RotatePlayer();
    }

    private void GetPlayerInput()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        rb2D.velocity = transform.up * Mathf.Clamp01(_verticalInput) * movementSpeed * Time.deltaTime; // up -> right
    }

    private void RotatePlayer()
    {
        float rotation = -_horizontalInput * rotationSpeed * Time.deltaTime;
        rb2D.AddTorque(rotation);
    }
}
