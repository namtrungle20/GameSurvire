using UnityEngine;

public class CloseAttackWeapon : Weapon
{
    public EnemyDamager damager;
    private float attackCounter, direction; // Bộ đếm thời gian để tấn công và hướng tấn công
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetStats();
    }

    // Update is called once per frame
    void Update()
    {
        if (statsUpdated == true)
        {
            statsUpdated = false;
            SetStats();
        }

        attackCounter -= Time.deltaTime; // Giảm bộ đếm thời gian
        if (attackCounter <= 0) // Kiểm tra nếu bộ đếm thời
        {
            attackCounter = stats[weaponLevel].timeBetweenAttacks; // Đặt lại bộ đếm thời gian
            direction = Input.GetAxisRaw("Horizontal"); // Lấy hướng tấn công từ người chơi

            if (direction != 0)
            {
                if (direction > 0)
                {
                    damager.transform.rotation = Quaternion.identity; // Hướng về bên phải
                }
                else
                {
                    damager.transform.rotation = Quaternion.Euler(0f, 0f, 180f); // Hướng về bên trái
                }
            }
            Instantiate(damager, damager.transform.position, damager.transform.rotation, transform).gameObject.SetActive(true);

            for(int i = 1; i < stats[weaponLevel].amount; i++) {
                float rot = (360f / stats[weaponLevel].amount) * i;
                Instantiate(damager, damager.transform.position, Quaternion.Euler(0f, 0f,  damager.transform.rotation.eulerAngles.z + rot), transform).gameObject.SetActive(true); // Tạo vũ khí mới xoay quanh nhân vật
            }
        }
    }

    void SetStats()
    {
        damager.damage = stats[weaponLevel].damage; // Thiết lập sát thương của vũ khí

        transform.localScale = Vector3.one * stats[weaponLevel].range; // Thiết lập phạm vi tấn công của vũ khí

        damager.lifetime = stats[weaponLevel].duration; // Thiết lập thời gian tồn tại của sát thương

        attackCounter = 0f; // Khởi tạo bộ đếm thời gian tấn công
    }
}
