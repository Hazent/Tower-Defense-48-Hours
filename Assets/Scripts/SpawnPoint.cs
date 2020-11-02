using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPoint : MonoBehaviour
{
    public GameObject gameManager;
    public GameManager manager;
    public Text guiText;
    public Era era;
    private SpriteRenderer sprite;
    public GameObject spawnedTower;
    private bool spawned = false;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController");
        manager = gameManager.GetComponent<GameManager>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        if (spawned == false)
        {
            sprite.color = new Color32(0, 255, 0, 125);
        } 
        else
        {
            sprite.color = new Color32(255, 0, 0, 125);
        }
    }

    private void OnMouseUp()
    {
        if (era == manager.currentTowerEra && spawned == false && manager.gold >= manager.towerInfo.cost && manager.maxUnits >= manager.currentUnit + manager.towerInfo.units)
        {
            spawnedTower = Instantiate(manager.selectedTower, transform.position, Quaternion.identity);
            manager.gold -= manager.towerInfo.cost;
            manager.currentUnit += manager.towerInfo.units;
            spawned = true;
        } 
        else if(manager.gold < manager.towerInfo.cost)
        {
            StartCoroutine(ShowMessage("Not enough Gold!", 2));
            Debug.Log("Not enough Gold");
        } 
        else if(manager.maxUnits < manager.currentUnit + manager.towerInfo.units)
        {
            StartCoroutine(ShowMessage("Not enough Units left!", 2));
        }
        else
        {
            StartCoroutine(ShowMessage("Not of the correct era!", 2));
            Debug.Log("Not the correct era!");
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(1))
        {
            Destroy(spawnedTower);
            manager.gold += manager.towerInfo.cost / 2;
            spawned = false;
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Tower")
        {
            spawned = false;
            manager.currentUnit -= manager.towerInfo.units;
        }
    }

    IEnumerator ShowMessage (string message, float delay)
    {
        guiText.text = message;
        guiText.enabled = true;
        yield return new WaitForSeconds(delay);
        guiText.enabled = false;

    }
}

