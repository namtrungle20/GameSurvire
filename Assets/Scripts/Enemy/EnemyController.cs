using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    private Transform target; // Đối tượng kẻ thù

    public float damage;
    public float health;
    public int exp;

    public float hitWaitTime; // Thời gian chờ giữa các lần tấn công
    private float hitCounter;
    public float knockBackTime; // Thời gian đẩy lùi sau khi bị tấn công
    private float knockBackCounter;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = FindAnyObjectByType<PlayerController>().transform; // Tìm đối tượng người chơi
    }

    // Update is called once per frame
    void Update()
    {

        MovingEnemy();

    }

    protected virtual void MovingEnemy()
    {
        KnockBackEnemy(); // Kiểm tra và xử lý đẩy lùi kẻ thù
        rb.linearVelocity = (target.position - transform.position).normalized * moveSpeed; // Tính toán hướng di chuyển về phía người chơi
        if (hitCounter > 0f)
        {
            hitCounter -= Time.deltaTime; // Giảm bộ đếm thời gian
        }
        
    }
    protected virtual void KnockBackEnemy()
    {
        if (knockBackCounter > 0f)
        {
            knockBackCounter -= Time.deltaTime; // Giảm bộ đếm thời gian đẩy lùi
            if (moveSpeed > 0)
            {
                moveSpeed = -moveSpeed * 2f; // Đảo ngược hướng di chuyển
            }
            if (knockBackCounter <= 0f)
            {
                moveSpeed = Mathf.Abs(moveSpeed * 0.5f); // Đặt lại tốc độ di chuyển về giá trị dương
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && hitCounter <= 0f) // Kiểm tra nếu va chạm với người chơi
        {
            PlayerHeathController.Instance.TakeDamage(damage); // Gọi hàm TakeDamage của PlayerHeathController khi kẻ thù va chạm với người chơi
            hitCounter = hitWaitTime; // Đặt lại bộ đếm thời gian
        }
    }
    public void TakeDamage(float getDamage)
    {
        health -= getDamage; // Giảm sức khỏe của kẻ thù
        if (health <= 0)
        {
            Destroy(gameObject); // Hủy kẻ thù nếu sức khỏe giảm xuống 0 hoặc thấp hơn
            ExperienceLevelController.instance.SpawnExp(transform.position, exp); // Hiện thị exp item
        }
         DamageNumberController.Instance.KhoiTaoSoSatThuong(getDamage, transform.position); // Hiển thị số sát thương khi kẻ thù bị tiêu diệt
    }
    public void TakeDamage(float getDamage, bool shouldKnockBack)
    {
        TakeDamage(getDamage); // Gọi hàm TakeDamage với sát thương
        if (shouldKnockBack == true)
        {
            knockBackCounter = knockBackTime; // Đặt lại bộ đếm thời gian đẩy lùi
        }
    }
}
