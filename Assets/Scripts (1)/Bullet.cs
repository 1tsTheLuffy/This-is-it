using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject[] center;
    public float speed = 18f;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D pam = gameObject.GetComponent<Rigidbody2D>();
        center = GameObject.FindGameObjectsWithTag("center");
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = pam.transform.up * speed;
        Destroy(this.rb, 2f);
    } 
}
