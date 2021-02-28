using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Stats")]
    public int maxHealth;
    public int health;

    public int maxAmmo;
    public int ammo;

    [Header("Movement")]
    public float movementSpeed;
    public float jumpForce;

    private bool isGrounded;
    private bool isMoving;
    private Rigidbody2D rb;

    [Header("Shooting")]
    public Transform gunArm;

    private Camera theCam;

    [Header("Other")]
    public GameManager gameManager;
    public GameObject fallDetector;

    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        theCam = Camera.main;


        health = maxHealth;
        ammo = maxAmmo;
    }

    void Update()
    {
        Movement();

        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);

        if(mousePos.x < screenPoint.x)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            gunArm.localScale = new Vector3(-1f, -1f, 1f);
        }
        else
        {
            transform.localScale = Vector3.one;
            gunArm.localScale = Vector3.one;
        }

        //rotate
        Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        gunArm.rotation = Quaternion.Euler(0, 0, angle);

        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "fallDetector")
            Die();

        else if (collision.gameObject.tag == "Enemy")
            Damage(20);
    }

    private void Movement()
    {
        isGrounded = Mathf.Abs(rb.velocity.y) < .001f;
        isMoving = Mathf.Abs(rb.velocity.x) > .001f;

        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * movementSpeed * Time.deltaTime;

        if (Input.GetButton("Jump") && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void Damage(int amount)
    {
        if (health - amount <= 0)
            Die();
        else
            health -= amount;
    }

    private void Heal(int amount)
    {
        if (health + amount >= maxHealth)
            health = maxHealth;
        else
            health += amount;
    }

    private void Die()
    {
        //Destroy(gameObject);

        gameManager.RestartGame();
    }
}