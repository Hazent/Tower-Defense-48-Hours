using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Stats")]
    public float damage;
    public float health;
    public float speed;
    private float oldSpeed;
    public GameObject gold;

    [Header("Animations")]
    public GameObject hit;

    [Header("Combat")]
    public float startTimeBtwShots;
    public float timeBtwShots;
    public GameObject bullet;
    public float bulletSpeed;

    void Start()
    {
        oldSpeed = speed;
        timeBtwShots = startTimeBtwShots;
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (health <= 0)
        {
            death();
        }

        if(speed == 0)
        {
            timeBtwShots -= Time.deltaTime;
            if(timeBtwShots <= 0)
            {
                Instantiate(bullet, transform.position, transform.rotation);
                bullet.GetComponent<EnemyBullet>().damage = damage;
                bullet.GetComponent<EnemyBullet>().bulletSpeed = bulletSpeed;
                timeBtwShots = startTimeBtwShots;
            }
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Tower")
        {
            speed = 0f;
        }
    }
    private void OnTriggerExit2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Tower")
        {
            speed = oldSpeed;
        }
    }

    void death()
    {
        int amount = Random.Range(1, 5);
        for(var i = 0; i < amount; i++)
        {
            Instantiate(gold, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }
}

