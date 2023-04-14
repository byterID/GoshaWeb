using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootP : MonoBehaviour
{
    public float speed = 40;
    private int timeToDestroy = 4;
    public ParticleSystem DeathParticles;

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
            StartCoroutine(Death());
            Destroy(collision.gameObject);
        }
    }
    IEnumerator Death()
    {
        DeathParticles.Play();
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}
