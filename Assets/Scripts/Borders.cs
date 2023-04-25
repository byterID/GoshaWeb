using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Borders : MonoBehaviour
{
    public bool isCovered = false;
    public Sprite[] screenTheme;

    Animator anim;
    public GameObject Screen;
    public GameObject DarknessText;
    private void Start()
    {
        anim = DarknessText.GetComponent<Animator>();
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StopCoroutine(EnterBorder());
            anim.SetInteger("State", 3);
            StartCoroutine(EnterBorder());
            isCovered = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StopCoroutine(ExitBorder());
            anim.SetInteger("State", 2);
            StartCoroutine(ExitBorder());
            isCovered = false;
        }
    }
    public IEnumerator EnterBorder()
    {
        if(!isCovered)
        {
            Screen.GetComponent<Image>().sprite = screenTheme[0];
            yield return new WaitForSeconds(0.3f);
            Screen.GetComponent<Image>().sprite = screenTheme[1];
            yield return new WaitForSeconds(0.3f);
            Screen.GetComponent<Image>().sprite = screenTheme[2];
            yield return new WaitForSeconds(0.3f);
            StopCoroutine(EnterBorder());
        }
    }
    public IEnumerator ExitBorder()
    {
        if (isCovered)
        {
            Screen.GetComponent<Image>().sprite = screenTheme[2];
            yield return new WaitForSeconds(0.3f);
            Screen.GetComponent<Image>().sprite = screenTheme[1];
            yield return new WaitForSeconds(0.3f);
            Screen.GetComponent<Image>().sprite = screenTheme[0];
            yield return new WaitForSeconds(0.3f);
            Screen.GetComponent<Image>().sprite = screenTheme[3];
            StopCoroutine(ExitBorder());
        }
    }
}
