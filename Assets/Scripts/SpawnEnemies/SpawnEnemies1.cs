using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies1 : MonoBehaviour
{
    public GameObject Enemy;
    Vector2 spawn1 = new Vector2(-11, -29);
    Vector2 spawn2 = new Vector2(-2, -34);
    Vector2 spawn3 = new Vector2(1, -40);
    Vector2 spawn4 = new Vector2(1, -27);
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            SpawnEnemy();
        }
    }
    public void SpawnEnemy()
    {
        Instantiate(Enemy, spawn1, transform.rotation);
        Instantiate(Enemy, spawn2, transform.rotation);
        Instantiate(Enemy, spawn3, transform.rotation);
        Instantiate(Enemy, spawn4, transform.rotation);
    }
}
