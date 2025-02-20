﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    public float startTimeBtwShots;
    public float timeBtwShots;
    public float health;
    public float damage;
    public Era era;
    public GameObject bullet;

    private Transform barrel;

    void Start()
    {
        timeBtwShots = startTimeBtwShots;
        barrel = this.gameObject.transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        timeBtwShots -= Time.deltaTime;

        if(timeBtwShots <= 0)
        {
            Instantiate(bullet, barrel.position, transform.rotation);
            bullet.GetComponent<Bullet>().damage = damage;
            timeBtwShots = startTimeBtwShots;
        }

        if(health <= 0)
        {
            Death();
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}

