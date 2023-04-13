using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeAnimate : MonoBehaviour
{
    Animator anim;
    public bool isEntered = false;
    // Start is called before the first frame update
    void Start()
    {
        anim= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isEntered)
        {
            anim.Play("Tork");
        }
        else
            anim.Play("IdleTree");
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isEntered=true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(waitIdle());
        }
    }
    IEnumerator waitIdle()
    {
        yield return new WaitForSeconds(1);
        isEntered = false;
    }
}
