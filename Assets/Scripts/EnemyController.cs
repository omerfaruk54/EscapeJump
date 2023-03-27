using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class EnemyController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText, highScoreText;

    [SerializeField] private GameObject[] enemies;

    [SerializeField] float spawnRangeX, spawnRangeY, enemySpawnTime, startDelay;
    [SerializeField] float destroyRangeX, destroyRangeY;

    public int score, highScore;

    [SerializeField] private GameObject enemyParent;

    private GameObject newEnemy;
    private GameObject newEnemy2;
    private GameObject newEnemy3;
    private GameObject newEnemy4;

    void Start()
    {
        InvokeRepeating("SpawnManager", startDelay, enemySpawnTime);
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        DestroyEnemy();
        
    }

    void SpawnManager()
    {
        int randomIndex = Random.Range(0, 2);
        float spawnX = Random.Range(-11f, 8f);
        float spawnY = Random.Range(4, -5f);

        Vector3 randomRange = new Vector3(spawnX, spawnRangeY, 0f);
        Vector3 randomRangeY = new Vector3(spawnRangeX, spawnY, 0f);
        Vector3 randomRange2 = new Vector3(Random.Range(5, 10), Random.Range(10, 15), 0f);
        Vector3 randomRange3 = new Vector3(Random.Range(-14,-20), Random.Range(3, -5), 0f); // 4. OBje tamamlanmadý daha

        newEnemy = Instantiate(enemies[randomIndex], randomRange, enemies[0].transform.rotation, enemyParent.transform);
        newEnemy2 = Instantiate(enemies[2], randomRangeY, enemies[0].transform.rotation, enemyParent.transform);

        if (score >= 100)
        {
            newEnemy3 = Instantiate(enemies[3], randomRange2, enemies[3].transform.rotation, enemyParent.transform);

        }

        if (score >= 250)
        {
            newEnemy4 = Instantiate(enemies[4], randomRange3, enemies[4].transform.rotation, enemyParent.transform);

        }

    }

    public void DestroyEnemy()
    {
        if (newEnemy != null && newEnemy.transform.position.y < destroyRangeY) 
        {
            score += 10;
            Destroy(newEnemy);
            scoreText.text = "" + score;
            Addpoint(score);

            if (score >= 100) 
            {
                enemySpawnTime = 2f;
            }

        }

        if (newEnemy2 != null && newEnemy2.transform.position.x > destroyRangeX)
        {
            Destroy(newEnemy2);
            score += 10;
            scoreText.text = "" + score;
            Addpoint(score);
        }

        if (newEnemy3 != null && newEnemy3.transform.position.y < destroyRangeY)
        {
            score += 15;
            Destroy(newEnemy3);
            scoreText.text = "" + score;
            Addpoint(score);

        }

        if (newEnemy4 != null && newEnemy.transform.position.y < destroyRangeY)
        {
            score += 20;
            Destroy(newEnemy4);
            scoreText.text = "" + score;
            Addpoint(score);
        }

        


    }

    public void Addpoint(int points)
    {
        scoreText.text = "" + score.ToString();

        if (score > highScore)
        {
            highScore = score;
            highScoreText.text = "High Score: " + highScore.ToString();
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }


    public void SetScore(int newScore)
    {
        score = newScore;
    }
}
