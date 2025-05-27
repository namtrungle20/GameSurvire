using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] float moveSpeed;
    [SerializeField] float damage;
    private Vector3 moveDirEnemy;
    [SerializeField] private GameObject DestroyEffect;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Player.instance.gameObject.activeSelf)
        {
             if(Player.instance.transform.position.x < transform.position.x)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
        moveDirEnemy = (Player.instance.transform.position - transform.position).normalized;
        rb.velocity = new Vector2(moveDirEnemy.x * moveSpeed, moveDirEnemy.y * moveSpeed);
        }else
        {
            rb.velocity = Vector2.zero;
        }
       
    }
    //Diem va cham
    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Player"))  
        {
            Player.instance.TakeDamage(damage);
            Destroy(gameObject);
            Instantiate(DestroyEffect, transform.position, transform.rotation);
        }
    }
}
