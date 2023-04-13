using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject GameControl;
    GameControl gameControl;
    public GameObject player;
    private float speed = 5;
    int maxHp = 3;
    public int curHp;
    bool isHit = false;

    RaycastHit2D hit;

    public bool isMove;

    Animator anim;

    void Start()
    {
        curHp = maxHp;
        GameControl = GameObject.Find("GameControl");
        gameControl = GameControl.GetComponent<GameControl>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckMove();
        Move();
        MouseMove();
        Flip();
    }
    public void RecountHp(int deltaHp)
    {
        curHp = curHp + deltaHp;
        if (deltaHp < 0)
        {
            curHp = curHp + deltaHp;
            StopCoroutine(OnHit());
            isHit = true;
            StartCoroutine(OnHit());
        }
        else if (curHp > maxHp)
        {
            curHp = curHp + deltaHp;
            curHp = maxHp;//если игрок подберет +1жизнь, а у него их уже 3, то хп останется на том же уровне
        }
        if (curHp <= 0)
        {
            Debug.Log("Помер");
        }
    }
    IEnumerator OnHit()
    {
        if (isHit)
            GetComponent<SpriteRenderer>().color = new Color(1f, GetComponent<SpriteRenderer>().color.g - 0.04f, GetComponent<SpriteRenderer>().color.b - 0.04f);
        else
            GetComponent<SpriteRenderer>().color = new Color(1f, GetComponent<SpriteRenderer>().color.g + 0.04f, GetComponent<SpriteRenderer>().color.b + 0.04f);
        if (GetComponent<SpriteRenderer>().color.g == 1f)
        {
            StopCoroutine(OnHit());
        }
        if (GetComponent<SpriteRenderer>().color.g <= 0)

            isHit = false;
        yield return new WaitForSeconds(0.02f);
        StartCoroutine(OnHit());
    }
    void Flip()
    {
        if (Input.GetAxis("Horizontal") > 0)
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        if (Input.GetAxis("Horizontal") < 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
    }

    public void CheckMove()
    {
        if(Input.GetAxis("Vertical")!=0 || Input.GetAxis("Horizontal")!=0)
        {
            isMove = true;
        }
        else
        {
            isMove = false;
        }
    }
    public void Move()
    {
        float translationY = Input.GetAxis("Vertical") * speed;
        float translationX = Input.GetAxis("Horizontal") * speed;

        translationY *= Time.deltaTime;
        translationX *= Time.deltaTime;

        transform.localPosition += new Vector3(translationX, translationY, 0);
        if(isMove)
        {
            anim.SetInteger("State", 2);
        }
        else
        {
            anim.SetInteger("State", 1);
        }
    }
    public void MouseMove()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);

        hit = Physics2D.Raycast(transform.position + new Vector3(1,0,0), Vector2.right);
    }
}
