using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obelisk : MonoBehaviour
{
    public GameObject ShootPrefab;
    public GameObject ShootTPrefab;
    public Transform ShootT;
    private bool canShoot = true;
    private float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShootB();
        OnMouseMove();
    }
    public void ShootB()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (canShoot)
                StartCoroutine(Shoot());
        }
    }
    public void InstantiateShootPrefab()
    {
        Instantiate(ShootPrefab, ShootT.transform.position, transform.rotation);

    }
    IEnumerator Shoot()
    {
        canShoot = false;
        InstantiateShootPrefab();
        yield return new WaitForSeconds(1);
        canShoot = true;
    }
    public void ShootPrefabMove()
    {
        ShootPrefab.transform.Translate(0, 1, 0);
    }
    public void OnMouseMove()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
    }
}
