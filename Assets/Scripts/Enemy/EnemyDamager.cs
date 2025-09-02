using System.Collections.Generic;
using UnityEngine;

public class EnemyDamager : MonoBehaviour
{
    public float damage; // Sát thương của kẻ thù
    public float lifetime, growSpeed; // Thời gian tồn tại của đạn lửa và tốc độ lớn dần
    private Vector3 targetSize;
    public bool shouldKnockBack; // Biến để xác định có nên đẩy lùi kẻ thù hay không
    public bool destroyWP; // Biến để xác định có nên hủy vũ khí
    public bool damageOverTime; // Biến để xác định có sát thương theo thời gian
    public bool destroyOnHit; // Biến để xác định có nên hủy đạn lửa khi va chạm
    public float timeBetweenDamage; // Thời gian giữa các lần
    private float damageCounter; // Bộ đếm sát thương theo thời gian
    private List<EnemyController> enemiesInRange = new List<EnemyController>(); // Danh sách kẻ thù trong phạm vi đạn lửa

    void Start()
    {
        // Destroy(gameObject, lifetime); // Hủy đối tượng sau một khoảng thời gian nhất định
        targetSize = transform.localScale; // Tính toán kích thước mục tiêu dựa trên tốc độ lớn dần
        transform.localScale = Vector3.zero; // Đặt kích thước ban đầu của đạn lửa là 0
    }
    void Update()
    {
        transform.localScale = Vector3.MoveTowards(transform.localScale, targetSize, growSpeed * Time.deltaTime); // Đặt vị trí của đạn lửa trên mặt phẳng 2D
        lifetime -= Time.deltaTime; // Giảm thời gian tồn tại
        if (lifetime <= 0) // Kiểm tra nếu thời gian tồn tại đã hết
        {
            targetSize = Vector3.zero; // Đặt kích thước mục tiêu về 0
            if (transform.localScale.x == 0f)
            {
                Destroy(gameObject); // Hủy đối tượng nếu kích thước hiện tại là 0
                if (destroyWP == true)
                {
                    Destroy(transform.parent.gameObject); // Hủy đối tượng cha nếu destroyWP là true
                }
            }
        }
        if (damageOverTime == true) // Kiểm tra nếu sát thương theo thời gian được bật
        {
            damageCounter -= Time.deltaTime; // Giảm bộ đếm sát thương theo thời gian
            if (damageCounter <= 0f) // Kiểm tra nếu bộ đếm đã hết
            {
                damageCounter = timeBetweenDamage; // Đặt lại bộ đếm
                for (int i = 0; i < enemiesInRange.Count; i++)
                {
                    if (enemiesInRange[i] != null)
                    {
                        enemiesInRange[i].TakeDamage(damage, shouldKnockBack);
                    }
                    else
                    {
                        enemiesInRange.RemoveAt(i);
                        i--;
                    }
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyController enemy = collision.GetComponent<EnemyController>();
        if (damageOverTime == false)
        {
            if (collision.CompareTag("Enemy")) // Kiểm tra nếu va chạm với người chơi
            {
                enemy.TakeDamage(damage, shouldKnockBack); // Gọi hàm TakeDamage của EnemyController khi kẻ thù va chạm với người chơi
                if (destroyOnHit == true)
                {
                    Destroy(gameObject); // Hủy đối tượng nếu destroyOnHit là true
                }
            }
        }
        else
        {
            if (collision.CompareTag("Enemy"))
            {
                enemiesInRange.Add(enemy);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        EnemyController enemy = collision.GetComponent<EnemyController>();
        if (damageOverTime == true)
        {
            if (collision.CompareTag("Enemy"))
            {
                enemiesInRange.Remove(enemy);
            }
        }
    }
}