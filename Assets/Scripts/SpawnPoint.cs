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

    private void OnMouseUp()
    {
        if (era == manager.currentTowerEra && spawned == false)
        {
            spawnedTower = Instantiate(manager.selectedTower, transform.position, Quaternion.identity);
            sprite.color = new Color32(255, 0, 0, 125);
            spawned = true;
        } else
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
            sprite.color = new Color32(0, 255, 0, 125);
            spawned = false;
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

