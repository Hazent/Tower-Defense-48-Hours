using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float damage;
    public float bulletSpeed;

    void Update()
    {
        transform.Translate(Vector3.left * bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Tower")
        {
            TowerController hit = coll.GetComponent<TowerController>();
            hit.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
