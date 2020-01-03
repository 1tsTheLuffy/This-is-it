using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class progression : MonoBehaviour
{
    public GameManager game;
    public static progression instance;
    public static int Score;
    public static float Growth = 2f;
    public static bool IsGrowing;
    public static int NextLevel = 10;

    public static int[] LevelNextPoint = { 10, 20, 40, 60, 80, 100, 145, 170, 190, 244, 250 };
    public GameObject levelUpEffect;
    public Bullet playershooting;

    public SpaceShip player;
    public Spawn enemyspawner;
    public Slider scoreSlider;

    public Animator levelupanimator;
    public Animator endgameanimator;
    Boss boss;
    int i = 0;

    private void awake()
    {
        
    }

    //start is called before the first frame update
    void start()
    {
        scoreSlider = GetComponent<Slider>();
        Boss boss = GetComponent<Boss>();
    }

    // update is called once per frame
    void update()
    {
        if (Boss.count == progression.LevelNextPoint[i])
        {
            Debug.Log("fucking called");
           
        }

    }


    
}

//    void UnlockReward(RewardTier reward)
//    {
//        Debug.Log("LEVEL UP!");

//        player.health += reward.healthBonus;
//        playerShooting.currentWeapon = reward.weapon;

//        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
//        foreach (GameObject enemy in enemies)
//        {
//            enemy.GetComponent<Enemy>().Remove();
//        }

//        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
//        foreach (GameObject bullet in bullets)
//        {
//            bullet.GetComponent<Bullet>().Remove();
//        }

//        StartCoroutine(LevelUp());
//    }