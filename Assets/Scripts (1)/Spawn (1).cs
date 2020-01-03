using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] enemies;
    public static int health = 10;

    public List<Rigidbody2D> EnemyRBs;
    public static int referanceNumber = 0;
    [SerializeField] GameObject bacteria;
    public int spawnRadius = 2;
    public Transform[] spawnPoints;
    public GameObject enemyBoss;
    bool check = true;

    public GameObject Opening;

    public GameObject[] place;
    private Transform placeTransfrom;

    private void Start()
    {
        place = GameObject.FindGameObjectsWithTag("center");
        placeTransfrom = gameObject.transform;
        StartCoroutine(spawnBacteria());

    }

    private void Update()
    {
        if (Boss.count == progression.NextLevel && check == true) //Boss.count == 10 && check == true
        {
           // StartCoroutine(Calling());
        }
        if (check == false){
           // StopCoroutine(Calling());
        }
    }

    //public IEnumerator Calling()
    //{
    //    Ripple.check = true;
    //    bring();
    //    yield return new WaitForSeconds(2f); 
    //    Vector2 spawnPos = SpaceShip.Position;
    //    spawnPos += Random.insideUnitCircle.normalized * spawnRadius;
    //    Instantiate(enemyBoss, spawnPos, Quaternion.identity);
    //    yield return new WaitForSeconds(1.5f);                 
    //}

    public void bring()
    {
        check = false;
    }

    public IEnumerator spawnBacteria()
    {
        while(true)
        {
            int randEnemy = Random.Range(0,referanceNumber); 
            Vector2 spawnPos = SpaceShip.Position;
            spawnPos += Random.insideUnitCircle.normalized * spawnRadius;
            GameObject open =  Instantiate(Opening, placeTransfrom.position, Quaternion.identity); 
            int randomSpawnPoint = Random.Range(1, spawnPoints.Length);
            yield return new WaitForSeconds(1f);
            Destroy(open);
            //Instantiate(bacteria, spawnPoints[randomSpawnPoint].position, Quaternion.identity);
            Instantiate(enemies[randEnemy], placeTransfrom.position, Quaternion.identity);
        }
    }
}
