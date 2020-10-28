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

    private void Awake()
    {
        selectedTower = towerMakker[0].towerObj;
        currentEnemy = maxEnemy;
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
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            towerInfo = towerMakker[0];
            selectedTower = towerInfo.towerObj;
            for (var i = 0; i < towerMakker.Count; i++)
            {
                towerMakker[i].UI.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                towerMakker[i].UI.GetComponentInChildren<Text>().text = "Inactive";
            }
            towerInfo.UI.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
            towerInfo.UI.GetComponentInChildren<Text>().text = "Active";            
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            towerInfo = towerMakker[1];
            selectedTower = towerInfo.towerObj;
            for (var i = 0; i < towerMakker.Count; i++)
            {
                towerMakker[i].UI.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                towerMakker[i].UI.GetComponentInChildren<Text>().text = "Inactive";
            }
            towerInfo.UI.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
            towerInfo.UI.GetComponentInChildren<Text>().text = "Active";            
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            towerInfo = towerMakker[2];
            selectedTower = towerInfo.towerObj;
            for (var i = 0; i < towerMakker.Count; i++)
            {
                towerMakker[i].UI.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                towerMakker[i].UI.GetComponentInChildren<Text>().text = "Inactive";
            }
            towerInfo.UI.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
            towerInfo.UI.GetComponentInChildren<Text>().text = "Active";
        }

        if (currentEnemy == 0)
        {
            currentWave++;
            spawnEnemy = 0;
            currentEnemy = maxEnemy;
        }
    }
}
public enum Era
{
    Past,
    Current,
    Future
}