using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [Header("Stats")]
    public float damage;
    public float health;
    public float speed;
    private float oldSpeed;
    public GameObject gold;

    [Header("Animations")]
    public GameObject hit;
    public GameObject death;

    [Header("Combat")]
    public float startTimeBtwShots;
    public float timeBtwShots;
    public GameObject bullet;
    public float bulletSpeed;
    private GameObject baseObj;
    public string baseName;
    private Transform barrel;

    private GameObject gameManager;
    private GameManager manager;

    void Start()
    {
        oldSpeed = speed;
        timeBtwShots = startTimeBtwShots;
        gameManager = GameObject.FindGameObjectWithTag("GameController");
        manager = gameManager.GetComponent<GameManager>();
        barrel = this.gameObject.transform.GetChild(0);
        baseObj = GameObject.Find(baseName);
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (health <= 0)
        {
            Death();
        }

        if (speed == 0)
        {
            timeBtwShots -= Time.deltaTime;
            if (timeBtwShots <= 0)
            {
                baseObj.GetComponent<BaseController>().TakeDamage(damage);
                timeBtwShots = startTimeBtwShots;
            }
        }
    }

    public void TakeDamage(float amount, Transform bullet)
    {
        //Instantiate(hit, bullet.position, bullet.rotation);
        health -= amount;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Tower" || coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "Base")
        {
            speed = 0f;
        }
    }
    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Tower" || coll.gameObject.tag == "Enemy")
        {
            speed = oldSpeed;
        }
    }

    void Death()
    {
        Instantiate(death, transform.position, transform.rotation);
        manager.currentEnemy--;
        int amount = Random.Range(1, 5);
        for (var i = 0; i < amount; i++)
        {
            Instantiate(gold, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }
}

