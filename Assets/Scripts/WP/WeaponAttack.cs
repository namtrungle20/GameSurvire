using UnityEngine;

public class WeaponAttack : Weapon
{

    [SerializeField] protected GameObject prefab;
    private float spawnCounter; // thời gian phản hồi

    void Start()
    {
        // damage = 1f; // thiết lập sát thương mặc định
        // range = 1f; // thiết lập phạm vi tấn công mặc định
        // speed = 0.2f; // tốc độ của vũ khí
    }
    void Update()
    {
        TargetEnemy(); // gọi hàm tìm mục tiêu
    }
    void FixedUpdate()
    {
        spawnCounter -= Time.deltaTime;
        if (spawnCounter <= 0)
        {
            spawnCounter = stats[weaponLevels].cooldown; // thời gian nạp lại
            Instantiate(prefab, transform.position, transform.rotation); // tạo vũ khí mới
        }
    }

    protected virtual void TargetEnemy()
    {
        Enemy target = GameObject.FindAnyObjectByType<Enemy>();
        float minAttack = Mathf.Infinity; // khoảng cách tối thiểu để tấn công'
        foreach (Enemy enemy in GameObject.FindObjectsByType<Enemy>(FindObjectsSortMode.None))
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position); // khoảng cách đến kẻ thù
            if (distance < minAttack)
            {
                minAttack = distance; // cập nhật khoảng cách tối thiểu
                target = enemy; // cập nhật mục tiêu
            }
        }
        if (target != null)
        {
            Vector3 direction = target.transform.position - transform.position; // hướng đến mục tiêu
            direction.z = 0f; // cố định trục z
            direction.Normalize(); // chuẩn hóa hướng
            transform.right = direction; // xoay vũ khí về hướng mục tiêu
        }
    }
}
