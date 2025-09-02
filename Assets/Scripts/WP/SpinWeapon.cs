using System.Numerics;
using UnityEngine;

public class SpinWeapon : Weapon
{
    public Transform holder, fireballToSpawn; // Biến để lưu trữ vị trí của vũ khí và nơi sẽ sinh ra đạn lửa
    public float rotateSpeed;
    public float timeBetweenSpawns; // Thời gian giữa các lần sinh ra đạn lửa
    private float spawnTime, spawnCounter; // Bộ đếm thời gian để sinh ra đạn lửa
    public EnemyDamager damager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetStatus();

        // UIController.Instance.levelUpButtons[0].ActivateButton(this);

    }

    // Update is called once per frame
    void Update()
    {
        holder.rotation = UnityEngine.Quaternion.Euler(0f, 0f, holder.rotation.eulerAngles.z + (rotateSpeed * Time.deltaTime * stats[weaponLevel].speed)); // Xoay vũ khí theo tốc độ đã định
        spawnCounter -= Time.deltaTime; // Giảm bộ đếm thời gian
        if (spawnCounter <= 0f) // Kiểm tra nếu bộ đếm thời gian đã đến 0
        {
            spawnCounter = timeBetweenSpawns; // Đặt lại bộ đếm thời gian  
            for (int i = 0; i < stats[weaponLevel].amount; i++)
            {
                float spin = (360f / stats[weaponLevel].amount) * i;

                Instantiate(fireballToSpawn, fireballToSpawn.position, UnityEngine.Quaternion.Euler(0f, 0f, spin), holder).gameObject.SetActive(true);
            }
        }
        if (statsUpdated == true)
        {
            statsUpdated = false;
            SetStatus();
        }
    }
    public void SetStatus()
    {
        damager.damage = stats[weaponLevel].damage;

        transform.localScale = UnityEngine.Vector3.one * stats[weaponLevel].range;

        timeBetweenSpawns = stats[weaponLevel].timeBetweenAttacks;

        damager.lifetime = stats[weaponLevel].duration;

        spawnTime = stats[weaponLevel].timeBetweenAttacks;

        spawnCounter = 0f;

    }
}
