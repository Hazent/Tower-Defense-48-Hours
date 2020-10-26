using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject gameManager;
    public GameManager manager;
    private SpriteRenderer sprite;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController");
        manager = gameManager.GetComponent<GameManager>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseUp()
    {
        Instantiate(manager.tower, transform.position, Quaternion.identity);
        sprite.enabled = false;
    }

    private void OnMouseOver()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
    }
}
