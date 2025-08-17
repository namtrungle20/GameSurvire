using UnityEngine;

public class EnemyDamager : MonoBehaviour
{
    public float damage; // Sát thương của kẻ thù
    public float lifetime, growSpeed; // Thời gian tồn tại của đạn lửa và tốc độ lớn dần
    public bool shouldKnockBack; // Biến để xác định có nên đẩy lùi kẻ thù hay không
    private Vector3 targetSize;
    void Start()
    {
        // Destroy(gameObject, lifetime); // Hủy đối tượng sau một khoảng thời gian nhất định
        targetSize = transform.localScale * growSpeed; // Tính toán kích thước mục tiêu dựa trên tốc độ lớn dần
        transform.localScale = Vector3.zero; // Đặt kích thước ban đầu của đạn lửa là 0
    }
    void Update()
    {
        transform.localScale = Vector3.MoveTowards(transform.localScale, targetSize, growSpeed * Time.deltaTime); // Đặt vị trí của đạn lửa trên mặt phẳng 2D
        lifetime -= Time.deltaTime; // Giảm thời gian tồn tại
        if (lifetime <= 0f) // Kiểm tra nếu thời gian tồn tại đã hết
        {
           targetSize = Vector3.zero; // Đặt kích thước mục tiêu về 0
            if (transform.localScale.x == 0f)
            {
                Destroy(gameObject); // Hủy đối tượng nếu kích thước hiện tại là 0
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) // Kiểm tra nếu va chạm với người chơi
        {
            collision.GetComponent<EnemyController>().TakeDamage(damage, shouldKnockBack); // Gọi hàm TakeDamage của EnemyController khi kẻ thù va chạm với người chơi
        }
    }
}