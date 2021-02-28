using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class F3DEnemy : MonoBehaviour
{
    [Header("Stats")]
    public int maxHealth = 100;
    public int health;

    public int damageCount = 10;

    public Transform target;
    public GameObject bloodEffect;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

        GetComponent<AIDestinationSetter>().target = target;

        health = maxHealth;
    } 


    private void Update()
    {
        Movement();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            Damage(damageCount);
        }

        Vector3 dir = collision.contacts[0].point - (Vector2)transform.position;
        dir = -dir.normalized;
        GetComponent<Rigidbody2D>().AddForce(dir * 50000, ForceMode2D.Impulse);
    }

    private void Movement()
    {
        if (target == null)
            return;

        transform.LookAt(new Vector3(target.position.x, target.position.y + 1.5f));
        transform.Rotate(new Vector3(0, -90), Space.Self);
    }

    private void Damage(int amount)
    {
        if (health - amount <= 0)
            Die();
        else
            health -= amount;

        Destroy(Instantiate(bloodEffect, transform.position, Quaternion.identity), 2f);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
