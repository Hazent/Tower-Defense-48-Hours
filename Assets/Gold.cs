using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    public float value = 1f;

    public GameObject gameManager;
    public GameManager manager;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController");
        manager = gameManager.GetComponent<GameManager>();
    }

    private void OnMouseEnter()
    {
        manager.gold += value;
        Destroy(gameObject);
    }
}
