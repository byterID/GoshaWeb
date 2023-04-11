using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    public GameObject Player;
    public Transform target;
    private float speed = 10;

    void Start()
    {
        Player = GameObject.Find("Player");
        target = Player.GetComponent<Transform>();
    }

    void Update()
    {
        MoveTo();
    }
    public void MoveTo()
    {
        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, 5f * Time.deltaTime);
        
    }
}
