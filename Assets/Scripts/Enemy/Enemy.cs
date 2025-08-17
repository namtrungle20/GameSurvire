// using System.Collections;
// using System.Collections.Generic;
// using Unity.VisualScripting;
// using UnityEngine;

// public class Enemy : MonoBehaviour
// {
//     // public static Enemy enemy; //đối tượng triển khai
//     public Transform enemy; //đối tượng kẻ thù
//     private Transform player; //đối tượng mục tiêu
//     private Vector3 moveDirEnemy;
//     [SerializeField] private SpriteRenderer sr;
//     [SerializeField] private Rigidbody2D rb;
//     [SerializeField] private float moveSpeed;
//     [SerializeField] private float damage;
//     [SerializeField] private float health;
//     [SerializeField] private int exp;
//     [SerializeField] private float pushTime;
//     private float pushCounter;

//     [SerializeField] private GameObject DestroyEffect;

//     void Awake()
//     {
//         rb = GetComponent<Rigidbody2D>();
//         sr = GetComponent<SpriteRenderer>();
//     }
//     void Start()
//     {
//         player = FindAnyObjectByType<Player>().transform; // Tìm đối tượng người chơi
//     }
//     // Update is called once per frame
//     void Update()
//     {
//         MovingEnemy();
//     }
//     protected virtual void MovingEnemy()
//     {
//         if (Player.PlayerInstance.gameObject.activeSelf)
//         {
//             if (Player.PlayerInstance.transform.position.x < transform.position.x)
//             {
//                 sr.flipX = true;
//             }
//             else
//             {
//                 sr.flipX = false;
//             }

//             // counter enemy
//             if (pushCounter > 0)
//             {
//                 pushCounter -= Time.deltaTime;
//                 if (moveSpeed > 0)
//                 {
//                     moveSpeed = -moveSpeed; // Dừng chuyển động
//                 }
//                 if (pushCounter <= 0)
//                 {
//                     moveSpeed = Mathf.Abs(moveSpeed); // Khôi phục tốc độ di chuyển
//                 }
//             }
//             moveDirEnemy = (player.position - transform.position).normalized * moveSpeed; // Tính toán hướng di chuyển về phía người chơi
//             rb.linearVelocity = new Vector2(moveDirEnemy.x * moveSpeed, moveDirEnemy.y * moveSpeed); // Di chuyển về hướng người chơi
//         }
//         else
//         {
//             rb.linearVelocity = Vector2.zero;
//         }
//     }
//     //Diem va cham
//     void OnCollisionEnter2D(Collision2D collision)
//     {
//         if (collision.gameObject.CompareTag("Player"))
//         {
//             Player.PlayerInstance.TakeDamage(damage);
//         }
//     }
//     public void TakeDamage(float damage)
//     {
//         health -= damage;
//         DamageNumberController.Instance.KhoiTaoSoSatThuong(damage, transform.position); // Hiển thị số sát thương
//         pushCounter = pushTime; // Đặt lại thời gian đẩy
//         if (health <= 0)
//         {
//             Destroy(gameObject);
//             Instantiate(DestroyEffect, transform.position, transform.rotation);
//             Player.PlayerInstance.GetKinhNghiem(exp); // Thêm kinh nghiệm cho người chơi
//         }
//     }
    
// }
