using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemies;
    public GameObject boss;
    public float startTimeBtwSpawn;
    public float timeBtwSpawn;
    private bool bossSpawned;
    private Transform spawnPoint;

    private GameObject gameManager;
    private GameManager manager;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController");
        manager = gameManager.GetComponent<GameManager>();
        timeBtwSpawn = startTimeBtwSpawn;
        spawnPoint = this.gameObject.transform.GetChild(0);
    }

    void Update()
    {
        timeBtwSpawn -= Time.deltaTime;

        if(timeBtwSpawn <= 0 && manager.spawnEnemy < manager.maxEnemy && !manager.bossWave)
        {
            int rand = Random.Range(0, enemies.Count - 1);
            Instantiate(enemies[rand], spawnPoint.position, transform.rotation);
            manager.spawnEnemy++;
            timeBtwSpawn = startTimeBtwSpawn;
        }

        if(timeBtwSpawn <= 0 && manager.bossWave && !bossSpawned)
        {
            Instantiate(boss, spawnPoint.position, transform.rotation);
            bossSpawned = true;
        }
    }
}
