using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignTrigger : MonoBehaviour
{
    Animator anim;
    public GameObject InfoScreen;
    private void Start()
    {
        anim = InfoScreen.GetComponent<Animator>();
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Light")
        {
            anim.SetInteger("State", 2);
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Light")
        {
            anim.SetInteger("State", 3);
        }
    }
}
