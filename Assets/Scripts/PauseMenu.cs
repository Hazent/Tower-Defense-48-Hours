using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private GameObject manager;
    private void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("GameController");
    }
    public void Continue()
    {
        manager.GetComponent<GameManager>().paused = false;        
        Time.timeScale = 1f;
        this.gameObject.SetActive(false);
    }

    public void ExitLevel(string name)
    {
        SceneManager.LoadScene(name);
    }
}
