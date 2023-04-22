using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SignTrigger : MonoBehaviour
{
    Animator anim;
    Animator animPanel;
    public GameObject InfoScreen;
    public GameObject buttonText;
    public GameObject DialogPanel;
    private void Start()
    {
        anim = InfoScreen.GetComponent<Animator>();
        animPanel = DialogPanel.GetComponent<Animator>();
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Light")
        {
            buttonText.GetComponentInChildren<Button>().enabled = true;
            anim.SetInteger("State", 2);
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Light")
        {
            anim.SetInteger("State", 3);
            buttonText.GetComponentInChildren<Button>().enabled = false;
        }
    }
    public void ShowNote()
    {
        Debug.Log("Sasd");
        animPanel.SetInteger("State", 2);
    }
    public void HideNote()
    {
        animPanel.SetInteger("State", 3);
    }
    
    public void Sigh1()
    {
        DialogPanel.GetComponentInChildren<TMP_Text>().text = " 1                Lorem";
    }
    public void Sigh2()
    {
        DialogPanel.GetComponentInChildren<TMP_Text>().text = " 2                ipsum";
    }
    public void Sigh3()
    {
        DialogPanel.GetComponentInChildren<TMP_Text>().text = " 3                dolor";
    }
    public void Sigh4()
    {
        DialogPanel.GetComponentInChildren<TMP_Text>().text = " 4                sit";
    }
    public void Sigh5()
    {
        DialogPanel.GetComponentInChildren<TMP_Text>().text = " 5                amet,";
    }
    public void Sigh6()
    {
        DialogPanel.GetComponentInChildren<TMP_Text>().text = " 6                consectetur";
    }
    public void Sigh7()
    {
        DialogPanel.GetComponentInChildren<TMP_Text>().text = " 7                adipiscing";
    }
    public void Sigh8()
    {
        DialogPanel.GetComponentInChildren<TMP_Text>().text = " 8                elit";
    }
}
