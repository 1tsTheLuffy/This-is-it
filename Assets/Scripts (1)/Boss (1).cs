using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{


    //public static Boss instance;
    public static int count = 0;
    [Header("Shooting")]

    public static bool isShooter = false;
    public float strafeSpeed = 1f;
    public float shootDistance = 5f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 1f;
    private float nextTimeToFire = .9f;


    public int health = 5;
    public float spawnRadius = 4;
    private float speed = 1.5f;
    private float minDistance = 0.2f;
    float turnSpeed = 0.3f;
    //repealihg
    public float repelRange = .5f;
    public float repelAmount = 1f;

    public GameObject enemyBoss;
    [SerializeField] Transform SpaceShip;
    [SerializeField] SpaceShip spaceShip;
    private Rigidbody2D rb;


    private static List<Rigidbody2D> EnemyRBs;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
           
        SpaceShip = GameObject.FindGameObjectWithTag("pla").transform;
        spaceShip = GameObject.FindGameObjectWithTag("pla").GetComponent<SpaceShip>();


        if(EnemyRBs == null)
        {
            EnemyRBs = new List<Rigidbody2D>();
        }
        EnemyRBs.Add(this.rb);

        transform.localScale = Vector3.one * (progression.Growth);
    }

    private void OnDestroy()
    {

        EnemyRBs.Remove(this.rb);
    }

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
        Vector2 newPos;
        float distance = Vector2.Distance(rb.transform.position, SpaceShip.position);
        Vector2 direction = (SpaceShip.position - rb.transform.position).normalized;

        if (distance > minDistance)
        {
           // transform.position = Vector2.MoveTowards(transform.position, SpaceShip.position, speed * Time.fixedDeltaTime);
        }
        if (isShooter)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            //rb.rotation = angle;
            rb.rotation = Mathf.LerpAngle(rb.rotation, angle, turnSpeed);

            if (distance > shootDistance)
            {
                newPos = MoveRegular(direction);
            }
            else
            {
                newPos = MoveStrafing(direction);
            }
            rb.MovePosition(newPos);
            Shoot();

            newPos -= rb.position;

            rb.AddForce(newPos, ForceMode2D.Force);

        }
        else
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = Mathf.LerpAngle(rb.rotation, angle, turnSpeed);

            newPos = MoveRegular(direction);
            rb.MovePosition(newPos);
        }
     }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("BulletTag"))
        {
            count++;
            Debug.Log(count);
            Ripple.MaxAmount = 50f;
            Ripple.check = true;
            health -= 5;
            Destroy(collision.transform.gameObject);
        }
    }

    Vector2 MoveStrafing(Vector2 direction)
    {
        Vector2 newPos = transform.position + transform.right * Time.fixedDeltaTime * strafeSpeed;
        return newPos;
    }

    void Shoot()
    {
        if (Time.time >= nextTimeToFire)
        {
            GameObject bullet = Instantiate(bulletPrefab, this.rb.position, firePoint.rotation);
            Destroy(bullet, 15f);
            
            nextTimeToFire = Time.time + 1f / fireRate;
        }
    }

    Vector2 MoveRegular(Vector2 direction)
    {
        
        Vector2 repelForce = Vector2.zero;
        foreach (Rigidbody2D enemy in EnemyRBs)
        {
            if (enemy == rb)
                continue;

            if (Vector2.Distance(enemy.position, rb.position) <= repelRange)
            {
                Vector2 repelDir = (rb.position - enemy.position).normalized;
                repelForce -= repelDir;
            }
        }

        Vector2 newPos = transform.position + transform.up * Time.fixedDeltaTime * speed;
        newPos += repelForce * Time.fixedDeltaTime * repelAmount;

        return newPos;
    }
}
