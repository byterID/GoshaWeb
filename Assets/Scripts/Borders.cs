using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Borders : MonoBehaviour
{
    Animator anim;
    public GameObject DarknessText;
    private void Start()
    {
        anim = DarknessText.GetComponent<Animator>();
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            anim.SetInteger("State", 3);
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetInteger("State", 2);
        }
    }
}
