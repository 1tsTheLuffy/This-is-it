using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInCircle : MonoBehaviour
{
    public AudioSource As;
    public AudioClip clp;

    public GameObject bullet;
    public float rotation = 0;
    public float speed = 10;

    public static float Shoot = 1f;

    public static int health = 10;
    // Start is called before the first frame update
    void Start()
    {
        As = GetComponent<AudioSource>();
        clp = GetComponent<AudioClip>();
        StartCoroutine(fire());

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //rotation = rotation + 30 * Time.deltaTime;

            //transform.rotation = Quaternion.Euler(0, 0, rotation);
            //transform.Translate(0, speed * Time.deltaTime, 0);
            this.transform.RotateAround(this.transform.parent.position, this.transform.parent.forward * speed, 90f * Time.deltaTime);
            

        }

        if(health == 0)
        {
            Destroy(this.gameObject);
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            Debug.Log("touched" + health);
            health -= 10;
            Destroy(collision.transform.gameObject);
        }

        if (collision.CompareTag("Enemy_Bullet"))
        {
            health -= 5;
        }
    }
    private void FixedUpdate()
    {
       
    }

    IEnumerator fire()
    {
        while (true)
        {
            GameObject fire = Instantiate(bullet, transform.position, transform.rotation);
            As.PlayOneShot(clp);
            Destroy(fire, 0.5f);
            fire.transform.localScale *= 0.5f;
            text.strength -= 0.1f;
            yield return new WaitForSeconds(Shoot);
        }
    }
}
