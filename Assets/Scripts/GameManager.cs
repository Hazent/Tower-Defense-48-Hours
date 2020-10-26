using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Towers")]
    public GameObject tower;
    public List<GameObject> UI;
    public List<GameObject> towers;
    public List<Towers> towerMakker;

    [Header("Game Stats")]
    public float gold;
    public float currentUnit = 0f;
    public float maxUnits;
    public float currentWave;

    [Header("Waves")]
    public float maxWaves;
    public float spawnEnemy;
    public float currentEnemy;
    public float maxEnemy;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            tower = towers[0];
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            tower = towers[1];
        }
    }
}
