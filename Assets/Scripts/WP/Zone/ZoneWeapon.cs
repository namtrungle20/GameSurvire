using System.Collections.Generic;
using UnityEngine;

public class ZoneWeapon : Weapon
{
    public EnemyDamager damager;
    private float spawnTime, spawnCount; // Thời gian giữa các lần sinh ra vùng
    private List<GameObject> activeDamagers = new List<GameObject>();
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
        spawnCount -= Time.deltaTime; // Giảm bộ đếm thời gian
        if (spawnCount <= 0f) // Kiểm tra nếu bộ đếm
        {
            spawnCount = spawnTime; // Đặt lại bộ đếm thời gian
            Instantiate(damager, damager.transform.position, Quaternion.identity, transform).gameObject.SetActive(true); // Sinh ra vùng tại vị trí của vũ khí
        }
    }
    void SetStatus()
    {
        damager.damage = stats[weaponLevel].damage;

        damager.lifetime = stats[weaponLevel].duration;

        damager.timeBetweenDamage = stats[weaponLevel].speed;

        damager.transform.localScale = Vector3.one * stats[weaponLevel].range;

        spawnTime = stats[weaponLevel].timeBetweenAttacks;

        spawnCount = 0f;
    }
}
