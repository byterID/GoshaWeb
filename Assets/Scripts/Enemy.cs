using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Player playerScript;
    public GameObject Player;
    public Transform player;
    public float movespeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    void Start()
    {
        Player = GameObject.Find("Player");
        player = Player.GetComponent<Transform>();
        playerScript = Player.GetComponent<Player>();
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
        Flip();
    }
    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    public void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * movespeed * Time.deltaTime));
    }
    void Flip()//--------
    {
        if (transform.rotation.z <= 90 || transform.rotation.z >= -90)
            transform.Rotate(0, 0, 0);
        if (transform.rotation.z <= -90 || transform.rotation.z >= 90)
            transform.Rotate(0, 180, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerScript.curHp -= 10;
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Katana")
        {
            Destroy(gameObject);
        }
    }
}
