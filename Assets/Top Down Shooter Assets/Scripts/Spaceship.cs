using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    private Vector2 mousePos;
    private Vector2 movement;
    [SerializeField] float movementSpeed;

    Rigidbody2D rb;
    Camera cam;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        transform.up = direction;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x * movementSpeed * Time.fixedDeltaTime, 
            movement.y * movementSpeed * Time.fixedDeltaTime);
    }
}
