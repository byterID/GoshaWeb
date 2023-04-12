using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform ShootT;
    public GameObject ShootPrefab;
    public GameObject GameControl;
    GameControl gameControl;
    public GameObject player;
    private float speed = 10;
    RaycastHit2D hit;
    private bool canShoot = true;


    void Start()
    {
        GameControl = GameObject.Find("GameControl");
        gameControl = GameControl.GetComponent<GameControl>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        MouseMove();
        ShootB();
    }

    public void Move()
    {
        float translationY = Input.GetAxis("Vertical") * speed;
        float translationX = Input.GetAxis("Horizontal") * speed;

        translationY *= Time.deltaTime;
        translationX *= Time.deltaTime;

        transform.localPosition += new Vector3(translationX, translationY, 0);
    }
    public void MouseMove()
    {
        // Point toward mouse
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);

        hit = Physics2D.Raycast(transform.position + new Vector3(1,0,0), Vector2.right);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            gameControl.Damage();
        }
    }
    public void ShootB()
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            if(canShoot)
                StartCoroutine(Shoot());
        }
    } 
    public void InstantiateShootPrefab()
    {
        Instantiate(ShootPrefab, ShootT.transform.position, transform.rotation);

    }
    IEnumerator Shoot()
    {
        canShoot = false;
        InstantiateShootPrefab();
        yield return new WaitForSeconds(1);
        canShoot = true;
    }
    public void ShootPrefabMove()
    {
        ShootPrefab.transform.Translate(0, 1, 0);
    }

}
