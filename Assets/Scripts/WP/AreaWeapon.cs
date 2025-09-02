// using System.Collections.Generic;
// using UnityEngine;

// public class AreaWeapon : MonoBehaviour
// {
//     // [SerializeField] protected GameObject prefab;
//     protected float moveSpeed; // Tốc độ di chuyển của vũ khí khu vực
//     private Vector3 targetSize; // Kích thước mục tiêu của vũ khí khu vực
//     public WeaponAttack wpAttack; // Tham chiếu đến vũ khí khu vực
//     public List<Enemy> enemiesInRange;
//     public float timer;
//     private float counter;


//     void Start()
//     {
//         // Lấy hướng di chuyển từ vũ khí khu vực
//         wpAttack = GameObject.Find("WeaponAttack").GetComponent<WeaponAttack>();
//         targetSize = Vector3.one * wpAttack.stats[wpAttack.weaponLevels].range; // Kích thước mục tiêu
//         transform.localScale = Vector3.zero; // Thiết lập kích thước ban đầu
//         enemiesInRange = new List<Enemy>(); // Khởi tạo danh sách kẻ thù trong phạm vi
//         timer = wpAttack.stats[wpAttack.weaponLevels].duration; // Lấy thời gian tồn tại của vũ khí khu vực
//         moveSpeed = wpAttack.stats[wpAttack.weaponLevels].speed; // Lấy tốc độ di chuyển từ vũ khí khu vực
//     }
//     void Update()
//     {
//         Move(); // Gọi hàm Move để di chuyển vũ khí khu vực
//     }

//     public void Move()
//     {
//         transform.localScale = targetSize; // Tăng kích thước vũ khí khu vực
//         transform.position += transform.right * moveSpeed * Time.deltaTime; // Di chuyển vũ khí theo hướng hiện tại
//         timer -= Time.deltaTime; // Giảm thời gian tồn tại
//         if (timer <= 0)
//         {
//             Destroy(gameObject); // Hủy vũ khí khi hết thời gian tồn tại
//         }
//         CounterAttack(); // Gọi hàm CounterAttack để tấn công kẻ thù trong phạm vi
//     }
//     public void CounterAttack()
//     {
//         counter -= Time.deltaTime;
//         if (counter <= 0)
//         {
//             counter = moveSpeed; // Thời gian giữa các lần tấn công
//             for (int i = 0; i < enemiesInRange.Count; i++)
//             {
//                 enemiesInRange[i].TakeDamage(wpAttack.stats[wpAttack.weaponLevels].damage); // Gọi hàm TakeDamage của kẻ thù
//             }
//         }
//     }

//     private void OnTriggerEnter2D(Collider2D collision)
//     {
//         if (collision.CompareTag("Enemy"))
//         {
//             Enemy enemy = collision.GetComponent<Enemy>();
//             if (enemy != null && wpAttack != null && !enemiesInRange.Contains(enemy))
//             {
//                 enemiesInRange.Add(enemy); // Xóa kẻ thù vào danh sách nếu chưa có
//                 enemy.TakeDamage(wpAttack.stats[wpAttack.weaponLevels].damage); // Gọi hàm TakeDamage của kẻ thù
//             }
//         }
//     }

//     private void OnTriggerExit2D(Collider2D collision)
//     {
//         if (collision.CompareTag("Enemy"))
//         {
//             Enemy enemy = collision.GetComponent<Enemy>();
//             if (enemy != null)
//             {
//                 enemiesInRange.Remove(collision.GetComponent<Enemy>()); // Xóa kẻ thù vào danh sách nếu chưa có
//             }
//         }
//     }
// }