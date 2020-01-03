using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bacteria : MonoBehaviour
{
     float speed = 4;
     float minDistance = 0.4f;

    [SerializeField] Transform spaceShip;
   // [SerializeField] SpaceShip spaceShip;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spaceShip = GameObject.FindGameObjectWithTag("pla").transform;
        //spaceShip = GameObject.FindGameObjectWithTag("pla").GetComponent<SpaceShip>();
    }

    private void Update()
    {
        float distance = Vector2.Distance(transform.position, spaceShip.position);
        //Debug.Log(distance);
        if (distance > minDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, spaceShip.position, speed * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("BulletTag"))
        {
            Debug.Log("worked");
            Debug.Log(MoveInCircle.health);
            Destroy(gameObject);
            Destroy(collision.transform.gameObject);
        }
    }
}
