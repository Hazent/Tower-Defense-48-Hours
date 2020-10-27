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

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController");
        manager = gameManager.GetComponent<GameManager>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnMouseUp()
    {
        if(era == manager.currentTowerEra)
        {
            Instantiate(manager.tower, transform.position, Quaternion.identity);
            sprite.enabled = false;
        } else
        {
           // StartCoroutine(ShowMessage("Not of the correct era!", 2));
            Debug.Log("Not the correct era!");
        }
    }

    private void OnMouseOver()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
    }

    /* IEnumerator ShowMessage (string message, float delay)
    {
        guiText.text = message;
        guiText.enabled = true;
        yield return new WaitForSeconds(delay);
        guiText.enabled = false;

    } */
}

