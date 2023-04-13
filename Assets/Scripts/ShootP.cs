using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootP : MonoBehaviour
{
    public float speed = 40;
    private int timeToDestroy = 4;
    void Start()
    {
        
    }

    void Update()
    {
        StartCoroutine(destroyBullet());
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    IEnumerator destroyBullet()
    {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

}
