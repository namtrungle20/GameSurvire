using UnityEngine;
using UnityEngine.UI;

public class PlayerHeathController : MonoBehaviour
{
    public static PlayerHeathController Instance; // Biến tĩnh để truy cập từ các lớp khác
    void Awake()
    {
        Instance = this; // Gán instance hiện tại cho biến tĩnh
    }

    public float health, maxHealth;
    public Slider healthSlider; // Thanh trượt hiển thị sức khỏe

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth; // Khởi tạo sức khỏe của người chơi
        healthSlider.maxValue = maxHealth; // Đặt giá trị tối đa cho thanh trượt sức khỏe
        healthSlider.value = health; // Đặt giá trị ban đầu cho thanh trượt sức khỏe
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float damage)
    {
        health -= damage; // Giảm sức khỏe khi người chơi nhận sát thương
        if (health <= 0)
        {
            gameObject.SetActive(false); // Gọi hàm Die nếu sức khỏe giảm xuống 0 hoặc thấp hơn
        }
        healthSlider.value = health; // Cập nhật thanh trượt sức khỏe
    }
}
