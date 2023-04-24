using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadBorder : MonoBehaviour
{
    public GameObject GameControl;
    GameControl gameControl;
    void Start()
    {
        GameControl = GameObject.Find("GameControl");
        gameControl = GameControl.GetComponent<GameControl>();
    }

    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gameControl.ShowDeadCanvas();
        }
    }
}
