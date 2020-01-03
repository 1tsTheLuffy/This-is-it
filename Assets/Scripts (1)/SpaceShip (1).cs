using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceShip : MonoBehaviour
{
    
    public static Vector2 Position;
    private Vector2 mousePos;
    private Vector2 movementVector;

    public GameObject fire;
    float value = 0;
    public int score;
    public float movementSpeed ;

    //health 


    public Text scoreText;

    public GameObject bullet;

    Vector2 movement = Vector2.zero;
    Vector2 velocity = Vector2.zero;
    public float moveSmooth = .3f;

    Rigidbody2D rb;
    Camera cam;

    public SpaceShip(float movementSpeed)
    {
        this.movementSpeed = movementSpeed;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }
    private void keepMoving()
    {
        rb.velocity += new Vector2(0,5) * Time.deltaTime;
    }
    private void Update()
    {
        keepMoving();

        //movementVector.x = Input.GetAxisRaw("Horizontal");
        float x = Input.GetAxisRaw("Horizontal");
        //movementVector.y = Input.GetAxisRaw("Vertical");
        float y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        transform.localScale = Vector3.one * progression.Growth;
        //transform.up = direction;
        //Position = rb.position;
      
        transform.position = new Vector2(x * Time.deltaTime * movementSpeed, y * Time.deltaTime * movementSpeed);
        // Instantiate(fire, Position + new Vector2(0,-1.5f), Quaternion.identity);

        if (Input.GetMouseButtonDown(0))
        {
            value += 1f;
            GameObject fire = Instantiate(bullet, transform.position, transform.rotation);
            Destroy(fire, 0.5f);
            fire.transform.localScale *= 0.5f;
            text.strength -= 0.1f;
        }

    }

    private void FixedUpdate()
    {

       // Vector2 desiredVelocity = movementVector * movementSpeed * progression.Growth;
        //rb.velocity = Vector2.SmoothDamp(rb.velocity, desiredVelocity, ref velocity, moveSmooth);
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

       
        // rb.velocity = new Vector2(movementVector.x * movementSpeed * Time.fixedDeltaTime, movementVector.y * movementSpeed * Time.fixedDeltaTime);
    }
}
