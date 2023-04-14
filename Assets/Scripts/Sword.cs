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

    // Start is called before the first frame update
    void Start()
    {
        player = Player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Turn();
        Slash();
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
        if(Input.GetKey(KeyCode.X))
        {
            if (player.isRight)
            {
                transform.position = Vector3.MoveTowards(transform.position, activeSwordTransform.position, speed * Time.deltaTime);
                transform.localRotation = Quaternion.Euler(-180, 0, 0);
                if (Input.GetMouseButton(0))
                {
                    transform.position = Vector3.MoveTowards(transform.position, slashSwordTransform.position, speed * Time.deltaTime);
                    //Quaternion neededRotation = Quaternion.LookRotation(slashSwordTransform.position - transform.position);
                    //transform.rotation = Quaternion.Slerp(transform.rotation, slashSwordTransform.rotation, Time.deltaTime);
                    //transform.localPosition = Vector3.MoveTowards(transform.position, slashSwordTransform.position, speed * Time.deltaTime);
                    //transform.localRotation = Quaternion.Euler(-180, 0, 155);
                    //transform.localRotation = Quaternion.RotateTowards(transform.rotation, slashSwordTransform.rotation, 50f);
                }
            }
            if (!player.isRight)
            {
                transform.position = Vector3.MoveTowards(transform.position, activeSwordTransform.position, speed * Time.deltaTime);
                transform.localRotation = Quaternion.Euler(-180, 180, 0);
                if (Input.GetMouseButton(0))
                {
                    transform.position = Vector3.MoveTowards(transform.position, slashSwordTransform.position, speed * Time.deltaTime);
                    transform.localRotation = Quaternion.Euler(-180, 0, -35);
                }
            }

        }
    }
}
