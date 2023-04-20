using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public Sprite[] book;
    public Image sp;
    public float deltaAlpha = 1f;
    public TMP_Text spText;
    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<Image>();
        spText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TurnPage()
    {
        StartCoroutine(TurnPageAnim());
        StartCoroutine(TransText());
    }
    IEnumerator TransText()
    {
        float color = 0;
        while (color != 255f)
        {
            color += deltaAlpha * Time.deltaTime;
            spText.color = new Color(1, 1, 1, color);
        }
        yield return new WaitForSeconds(0.1f);
    }

    IEnumerator TurnPageAnim()
    {
        sp.sprite = book[0];
        yield return new WaitForSeconds(0.1f);
        sp.sprite = book[1];
        yield return new WaitForSeconds(0.1f);
        sp.sprite = book[2];
        yield return new WaitForSeconds(0.1f);
        sp.sprite = book[3];
        yield return new WaitForSeconds(0.1f);
        sp.sprite = book[4];
        yield return new WaitForSeconds(0.1f);
        sp.sprite = book[5];
        yield return new WaitForSeconds(0.1f);
        sp.sprite = book[6];
        yield return new WaitForSeconds(0.1f);
        sp.sprite = book[7];
        yield return new WaitForSeconds(0.1f);
    }
}
