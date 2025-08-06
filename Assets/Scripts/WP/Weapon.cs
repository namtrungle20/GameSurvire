using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // [SerializeField] protected GameObject prefab;
    [SerializeField] protected float moveSpeed; // Tốc độ di
    public PlayerShooter playerShooter; // Tham chiếu đến vũ khí khu vực
    public List<Enemy> enemiesInRange;
    public float timer;
    private float counter;


    void Start()
    {
        // Lấy hướng di chuyển từ vũ khí khu vực
        playerShooter = GameObject.Find("PlayerShoot").GetComponent<PlayerShooter>();
        enemiesInRange = new List<Enemy>(); // Khởi tạo danh sách kẻ thù trong phạm vi
        timer = playerShooter.duration; // Lấy thời gian tồn tại của vũ khí khu vực
        moveSpeed = playerShooter.speed; // Lấy tốc độ di chuyển từ vũ khí khu vực
    }
    void Update()
    {
        transform.position += transform.right * moveSpeed * Time.deltaTime; // Di chuyển vũ khí theo hướng hiện tại
        timer -= Time.deltaTime; // Giảm thời gian tồn tại
        if (timer <= 0)
        {
            Destroy(gameObject); // Hủy vũ khí khi hết thời gian tồn tại
        }
         counter -= Time.deltaTime;
        if (counter <= 0)
        {
            counter = playerShooter.speed; // Thời gian giữa các lần tấn công
            for (int i = 0; i < enemiesInRange.Count; i++)
            {
                enemiesInRange[i].TakeDamage(playerShooter.damage); // Gọi hàm TakeDamage của kẻ thù
            }
        }
    }
    
     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            enemiesInRange.Add(enemy); // Xóa kẻ thù vào danh sách nếu chưa có
            enemy.TakeDamage(playerShooter.damage); // Gọi hàm TakeDamage của kẻ thù
        }
    }
   
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemiesInRange.Remove(collision.GetComponent<Enemy>()); // Xóa kẻ thù vào danh sách nếu chưa có
        }

    }
}
