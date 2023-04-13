using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObelisk : MonoBehaviour
{
    public Transform obelTransform;
    private float speed = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, obelTransform.position, speed * Time.deltaTime);
    }
}
