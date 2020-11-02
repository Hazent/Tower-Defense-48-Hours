using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Towers")]
    public GameObject selectedTower;
    public List<Towers> towerMakker;
    public Era currentTowerEra;
    public Towers towerInfo;

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
    public bool bossWave;

    [Header("UI")]
    public Text goldText;
    public Text enemyText;
    public Text waveText;
    public Text unitsText;
    public GameObject pauseMenu;
    public bool paused = false;

    private KeyCode[] keyCodes =
    {
        KeyCode.Alpha1,
        KeyCode.Alpha2,
        KeyCode.Alpha3,
        KeyCode.Alpha4,
        KeyCode.Alpha5,
        KeyCode.Alpha6
    };

    private void Awake()
    {
        selectedTower = towerMakker[0].towerObj;
        currentEnemy = maxEnemy;

        for(var i = 0; i < towerMakker.Count; i++)
        {
            towerMakker[i].UI.GetComponentInChildren<Text>().text = towerMakker[i].cost.ToString();
        }
    }

    void Update()
    {
        currentTowerEra = selectedTower.GetComponent<TowerController>().era;

        //UI Stuff
        goldText.text = "$" + gold;

        if (currentWave < maxWaves + 1)
        {
            waveText.text = currentWave + "/" + maxWaves;
        } 
        else
        {
            waveText.text = "BOSS WAVE";
            bossWave = true;
        }

        enemyText.text = currentEnemy + "/" + maxEnemy;

        unitsText.text = currentUnit + "/" + maxUnits; 

        //Tower Selection
        for(int i = 0; i < keyCodes.Length; i++)
        {
            if (Input.GetKeyDown(keyCodes[i]))
            {
                TowerSelection(i);
            }
        }

        //Pause Menu
        if(Input.GetButtonDown("Cancel") && !paused)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            paused = true;
        } else if (Input.GetButtonDown("Cancel") && paused)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            paused = false;
        }

        //Wave System
        if (currentEnemy == 0)
        {
            currentWave++;
            spawnEnemy = 0;
            currentEnemy = maxEnemy;
        }
    }

    void TowerSelection (int number)
    {
        towerInfo = towerMakker[number];
        selectedTower = towerInfo.towerObj;
        for (var i = 0; i < towerMakker.Count; i++)
        {
            towerMakker[i].UI.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        towerInfo.UI.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
    }
}

public enum Era
{
    Past,
    Current,
    Future
}