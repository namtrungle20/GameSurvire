using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Enemy enemy; //đối tượng triển khai
    public static Enemy EnemyInstance;
    private Vector3 moveDirEnemy;
    public Vector3 MoveDirEnemy
    {
        get { return moveDirEnemy; }
        set { moveDirEnemy = value; }
    }
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] float moveSpeed;
    [SerializeField] float damage;
    [SerializeField] float health;
    
    [SerializeField] private GameObject DestroyEffect;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        MovingEnemy();
    }
    protected virtual void MovingEnemy()
    {
        if(Player.player.gameObject.activeSelf)
        {
             if(Player.player.transform.position.x < transform.position.x)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
        moveDirEnemy = (Player.player.transform.position - transform.position).normalized;
        rb.linearVelocity = new Vector2(moveDirEnemy.x * moveSpeed, moveDirEnemy.y * moveSpeed);
        }else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }
    //Diem va cham
    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Player"))  
        {
            Player.player.TakeDamage(damage);
        }
    }
    void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(DestroyEffect, transform.position, transform.rotation);
        }
    }
}
