using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject Enemy;
    public Vector2 sp1;
    public Vector2 sp2;
    public Vector2 sp3;
    public Vector2 sp4;
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
            Instantiate(Enemy, sp1, transform.rotation);
            Instantiate(Enemy, sp2, transform.rotation);
            Instantiate(Enemy, sp3, transform.rotation);
            Instantiate(Enemy, sp4, transform.rotation);
        }
    }
}
