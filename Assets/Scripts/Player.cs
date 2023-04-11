using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameControl gameControl;
    public GameObject player;
    private float speed = 10;
    private float rotationSpeed = 100;
    RaycastHit2D hit;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        MouseMove();
    }

    public void Move()
    {
        float translationY = Input.GetAxis("Vertical") * speed;
        float translationX = Input.GetAxis("Horizontal") * speed;

        translationY *= Time.deltaTime;
        translationX *= Time.deltaTime;

        transform.localPosition += new Vector3 (translationX, translationY, 0);
    }
    public void MouseMove()
    {
        // Point toward mouse
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation,rotation,speed * Time.deltaTime);

        hit = Physics2D.Raycast(transform.position, Vector2.right);
        Debug.Log(hit.collider);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            gameControl.Damage();
        }
    }
}
