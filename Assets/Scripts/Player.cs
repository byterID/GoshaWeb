using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject GameControl;
    GameControl gameControl;
    public GameObject player;
    private float speed = 5;
    float maxHp = 100;
    public float curHp;
    public Image bar;
    public float fillHp;
    public bool isHit = false;

    [SerializeField] private float XSkillKD = 5;
    [SerializeField] private float XSkillCurTime;
    public Image SkillKDImage;
    public float fillKD;

    Rigidbody2D rb;
    RaycastHit2D hit;

    public bool isMove;

    Animator anim;
    public bool isDash = false;
    public float dashDistance = 10f;
    KeyCode lastKeyCode;
    float doubleTapTime;
    float mx;

    public GameObject bloodPanel;
    public Sprite[] bloodScreen;

    public float KDDashTime = 0.0001f;

    public bool isRight;

    void Start()
    {
        curHp = maxHp;
        GameControl = GameObject.Find("GameControl");
        gameControl = GameControl.GetComponent<GameControl>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        fillHp = curHp / 100;
        bar.fillAmount = fillHp;
        CheckMove();
        Move();
        MouseMove();
        Flip();
        Skill3();
        if(curHp <40)
        {
            bloodPanel.GetComponent<Image>().sprite = bloodScreen[0];
        }
        if (curHp < 20)
        {
            bloodPanel.GetComponent<Image>().sprite = bloodScreen[1];
        }
        if (curHp < 10)
        {
            bloodPanel.GetComponent<Image>().sprite = bloodScreen[2];
        }
        EndGame();
    }
    public void RecountHp()
    {
        if (curHp > maxHp)
        {
            curHp = maxHp;
        }
        if (curHp <= 0)
        {
            Debug.Log("Помер");
        }

    }

    void Flip()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            isRight = true;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            isRight = false;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
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
            if(!isDash)
            {
                anim.SetInteger("State", 2);
            }
        }
        else
        {
            if(!isDash)
            {
                anim.SetInteger("State", 1);
            }
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

    public void Skill1()
    {
        if(Input.GetButton("Z"))
        {
            //sdasd
        }
    }
    public void Skill2()
    {
        if (Input.GetButton("X"))
        {
            //sdasd

        }
    }
    public void Skill3()
    {
        XSkillCurTime += Time.deltaTime + 0.0001f;
        fillKD = XSkillCurTime / 5;
        SkillKDImage.fillAmount = fillKD;
        if (Input.GetKeyDown(KeyCode.D))//dddddddddddddddddddddddd
        {
            if (XSkillCurTime >= XSkillKD)
            {
                if (doubleTapTime > Time.time && lastKeyCode == KeyCode.D)
                {
                    XSkillCurTime = 0;
                    StartCoroutine(DashX(1f));
                    Debug.Log("sad");
                }
                else
                {
                    doubleTapTime = Time.time + 0.5f;
                }
                lastKeyCode = KeyCode.D;
            }
        }
        if (Input.GetKeyDown(KeyCode.W))//////////////////wwwwwwwwww
        {
            if (XSkillCurTime >= XSkillKD)
            {
                if (doubleTapTime > Time.time && lastKeyCode == KeyCode.W)
                {
                    XSkillCurTime = 0;
                    StartCoroutine(DashY(1f));
                    Debug.Log("sad");
                }
                else
                {
                    doubleTapTime = Time.time + 0.5f;
                }
                lastKeyCode = KeyCode.W;
            }

        }
        if (Input.GetKeyDown(KeyCode.S))//ssssssssssssssss
        {
            if (XSkillCurTime >= XSkillKD)
            {
                if (doubleTapTime > Time.time && lastKeyCode == KeyCode.S)
                {
                    XSkillCurTime = 0;
                    StartCoroutine(DashY(-1f));
                    Debug.Log("sad");
                }
                else
                {
                    doubleTapTime = Time.time + 0.5f;
                }
                lastKeyCode = KeyCode.S;
            }
        }
        if (Input.GetKeyDown(KeyCode.A))//////////Aaa
        {
            if (XSkillCurTime >= XSkillKD)
            {
                if (doubleTapTime > Time.time && lastKeyCode == KeyCode.A)
                {
                    XSkillCurTime = 0;
                    StartCoroutine(DashX(-1f));
                    Debug.Log("saasdd");
                }
                else
                {
                    doubleTapTime = Time.time + 0.5f;
                }
                lastKeyCode = KeyCode.A;
            }
        }
    }
    IEnumerator DashX(float direction)
    {
        isDash = true;
        anim.SetInteger("State", 3);
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(new Vector2(dashDistance * direction, 0f), ForceMode2D.Impulse);
        yield return new WaitForSeconds(1);
        isDash = false;
    }
    IEnumerator DashY(float direction)
    {
        isDash = true;
        anim.SetInteger("State", 3);
        rb.velocity = new Vector2(0f, rb.velocity.y);
        rb.AddForce(new Vector2(0f, dashDistance * direction), ForceMode2D.Impulse);
        yield return new WaitForSeconds(1);
        isDash = false;
    }
    private void FixedUpdate()
    {
        if(!isDash)
        {
            rb.velocity = new Vector2(mx * speed, rb.velocity.y);
            rb.velocity = new Vector2(mx * speed, rb.velocity.x);
        }
    }

    public void EndGame()
    {
        if(curHp <= 0)
        {
            gameControl.ShowDeadCanvas();
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
