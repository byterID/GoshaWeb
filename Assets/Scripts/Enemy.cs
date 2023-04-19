using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    Player playerScript;
    public GameObject Player;
    public Transform player;
    public float movespeed = 5f;
    private Rigidbody2D rb;
    public Vector2 movement;
    public GameObject enem_sprite;
    public Sprite en1;
    public Sprite en2;
    public SpriteRenderer curSprite;


    GameControl control;
    public GameObject gameControl;
    void Start()
    {
        curSprite = enem_sprite.GetComponent<SpriteRenderer>();
        gameControl = GameObject.Find("GameControl");
        control = gameControl.GetComponent<GameControl>();
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
        if (movement.x > 0)
        {
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            curSprite.sprite = en1;
        }
        if (movement.x < 0)
        {
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            curSprite.sprite = en2;
        }
    }
    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    public void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * movespeed * Time.deltaTime));
    }
    private void LateUpdate()
    {

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
            control.Score++;
        }
    }
}
