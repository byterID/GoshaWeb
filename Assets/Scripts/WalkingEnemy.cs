using UnityEngine;
using UnityEngine.UI;

public class WalkingEnemy : MonoBehaviour
{
    public float MaxHealth = 150;
    float curHealth;
    Rigidbody2D rb;
    private Vector2 movement;
    public Transform e_Transform;
    public GameObject entity;

    public Image healthImage;
    float fillHp;
    private float movespeed = 5;

    private void Start()
    {
        entity = GameObject.Find("Player");
        e_Transform = entity.GetComponent<Transform>();
        curHealth = MaxHealth;
        rb = this.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Vector3 direction = e_Transform.position - transform.position;
        //healthImage.fillAmount = fillHp;
        fillHp = curHealth / 100;
        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    public void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * movespeed * Time.deltaTime));
    }
}
