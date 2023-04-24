using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractPilar : MonoBehaviour
{
    public GameObject InteractText;
    Animator anim;
    public bool isActive;
    public GameObject puzzleMenu;
    void Start()
    {
        anim = InteractText.GetComponent<Animator>();
    }

    void Update()
    {
        ClosePuzzleEsc();
        Interact();
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isActive = true;
            anim.SetInteger("State", 2);
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isActive = false;
            anim.SetInteger("State", 3);
        }
    }
    public void Interact()
    {
        if(Input.GetKey(KeyCode.F))
        {
            if(isActive)
            {
                puzzleMenu.SetActive(true);
            }
        }
    }
    public void ClosePuzzleButton()
    {
        puzzleMenu.SetActive(false);
    }
    public void ClosePuzzleEsc()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            if (isActive)
                puzzleMenu.SetActive(false);
        }
    }
}
