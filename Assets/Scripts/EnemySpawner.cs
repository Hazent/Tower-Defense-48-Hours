using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemies;
    public float startTimeBtwSpawn;
    public float timeBtwSpawn;

    void Start()
    {
        timeBtwSpawn = startTimeBtwSpawn;
    }

    void Update()
    {
        timeBtwSpawn -= Time.deltaTime;

        if(timeBtwSpawn <= 0)
        {
            int rand = Random.Range(0, enemies.Count - 1);
            Instantiate(enemies[rand], transform.position, transform.rotation);
            timeBtwSpawn = startTimeBtwSpawn;
        }
    }
}
