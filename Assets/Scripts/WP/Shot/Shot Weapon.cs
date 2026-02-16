using UnityEngine;

public class ShotWeapon : Weapon
{
    public EnemyDamager damager;
    public Shot wpShot;
    private float shotCounter; // Bộ đếm thời gian để bắn đạn

    public float weaponRanger; // Tầm bắn của vũ khí
    public LayerMask whatIsEnemy; // Lớp của kẻ thù để kiểm tra va chạm

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetStatus();
    }

    // Update is called once per frame
    void Update()
    {
        if (statsUpdated == true)
        {
            statsUpdated = false;
            SetStatus();
        }
        
        shotCounter -= Time.deltaTime; // Giảm bộ đếm thời gian
        if (shotCounter <= 0f) // Kiểm tra nếu bộ đếm thời gian đã đến 0
        {
            shotCounter = stats[weaponLevel].timeBetweenAttacks; // Đặt lại bộ đếm thời gian  

            Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, weaponRanger * stats[weaponLevel].range, whatIsEnemy); // Tìm tất cả các kẻ thù trong phạm vi tấn công
            if (enemies.Length > 0)
            {
                for (int i = 0; i < stats[weaponLevel].amount; i++)
                {
                    Vector3 targetPosition = enemies[Random.Range(0, enemies.Length)].transform.position; // Chọn ngẫu nhiên một kẻ thù trong phạm vi tấn công

                    Vector3 direction = targetPosition - transform.position; // Tính toán hướng từ vũ khí đến kẻ thù
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Tính toán góc giữa hướng và trục x
                    angle -= 90; // Điều chỉnh góc để phù hợp với hướng của vũ khí
                    wpShot.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); // Xoay vũ khí về phía kẻ thù

                    Instantiate(wpShot, wpShot.transform.position, wpShot.transform.rotation).gameObject.SetActive(true); // Tạo một bản sao của vũ khí và kích hoạt nó
                }
            }
        }
    }
    void SetStatus()
    {
        damager.damage = stats[weaponLevel].damage;

        wpShot.moveSpeed = stats[weaponLevel].speed;

        damager.lifetime = stats[weaponLevel].duration;

        damager.transform.localScale = Vector3.one * stats[weaponLevel].range;

        shotCounter = 0f;

        
        
    }
}

