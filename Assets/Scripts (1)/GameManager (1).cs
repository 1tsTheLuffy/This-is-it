using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //[SerializeField] Spawn spawn;
    public static GameManager instance;
    public Animator levelupanimator;
    public Animator endgameanimator;

    public GameObject levelUpEffect;
    Spawn spawn;
    int i;

    private void Start()
    {
        //  bacteria = GameObject.FindGameObjectWithTag("Bacteria").GetComponent<Bacteria>();
        spawn = GetComponent<Spawn>();
    }

    private void Update()
    {
        if(Boss.count == progression.LevelNextPoint[i])
        {
            MoveInCircle.Shoot -= 0.4f;
            StartCoroutine(LevelUp());
           //progression.NextLevel += 10;
            Debug.Log("Level Up!!!!!!!!");
            Boss.isShooter = true;
            Spawn.referanceNumber = 2;
            progression.Growth -= 0.2f;
            i++;
        }

        if (Input.GetKey(KeyCode.K))
        {
            StopAllCoroutines();
        }
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;

        Time.timeScale = 0.5f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }

    public void PlayerDied()
    {
        StartCoroutine(RestartGame());
    }

    IEnumerator RestartGame()
    {
        Time.timeScale = .5f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;

        yield return new WaitForSecondsRealtime(2f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator EndTheGame()
    {
        //IsGrowing = true;
        Time.timeScale = .3f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        GameObject effect = Instantiate(levelUpEffect, SpaceShip.Position, Quaternion.identity);
        Destroy(effect, 10f);
        // endGameAnimator.SetTrigger("EndGame");
        yield return new WaitForSecondsRealtime(10f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator LevelUp()
    {

        Time.timeScale = .3f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        GameObject effect = Instantiate(levelUpEffect, SpaceShip.Position, Quaternion.identity);
        Destroy(effect, 10f);
        yield return new WaitForSecondsRealtime(.1f);

        float baseScale = progression.Growth;
        float factor = 1.3f;

        float t = 0f;
        while (t < 1f)
        {
            float growth = Mathf.Lerp(1f, factor, t);
            progression.Growth = baseScale * growth;
            t += Time.fixedDeltaTime * 1f;
            yield return 0;
        }

        progression.Growth = baseScale * factor;

        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;

        progression.IsGrowing = false;
    }
}
