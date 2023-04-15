using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public Transform swordTransform;
    public Transform activeSwordTransform;
    public Transform slashSwordTransform;
    private float speed = 14;
    public GameObject Player;
    Player player;
    public bool isActive;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        player = Player.GetComponent<Player>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Turn();
        Slash();
        if(isActive)
           GetComponent<BoxCollider2D>().enabled = true;
        else
            GetComponent<BoxCollider2D>().enabled = false;
    }
    public void Turn()
    {
        if (player.isRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, swordTransform.position, speed * Time.deltaTime);
            transform.localRotation = Quaternion.Euler(-180, 0, -126.357f);
        }
        if (!player.isRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, swordTransform.position, speed * Time.deltaTime);
            transform.localRotation = Quaternion.Euler(-180, 180, -126.357f);
        }
    }
    public void Slash()
    {
        if(Input.GetKeyDown(KeyCode.X) && !isActive)
        {
            transform.parent = player.transform;
            if (player.isRight)
            {
                anim.SetInteger("State", 2);
                isActive = true;
            }
            if (!player.isRight)
            {
                anim.SetInteger("State", 2);
                isActive = true;
            }
        }
        if (Input.GetMouseButton(1) && isActive)
        {
            StartCoroutine(SlashSword());
            anim.SetInteger("State", 4);
        }
        if (Input.GetMouseButton(1) && isActive)
        {
            Debug.Log("sasd");
            anim.SetInteger("State", 4);
            StartCoroutine(SlashSword());
        }
        if(Input.GetKeyUp(KeyCode.X) && isActive)
        {
            StartCoroutine(DeactivateSword());
        }
    }
    IEnumerator DeactivateSword()
    {
        anim.SetInteger("State", 3);
        yield return new WaitForSeconds(0.2f);
        anim.SetInteger("State", 0);
        isActive = false;
    }
    IEnumerator SlashSword()
    {
        yield return new WaitForSeconds(1);
        anim.SetInteger("State", 0);
        isActive = false;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Emeny")
        {
            Destroy(collision.gameObject);
        }
    }
}
