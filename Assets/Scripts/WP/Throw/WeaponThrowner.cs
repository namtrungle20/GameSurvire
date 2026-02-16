using UnityEngine;

public class WeaponThrowner : Weapon
{
    public EnemyDamager damager;
    private float throwCounter; // thời gian ném vũ khí
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
            SetStatus();
            statsUpdated = false;
        }
        throwCounter -= Time.deltaTime;
        if (throwCounter <= 0)
        {
            throwCounter = stats[weaponLevel].timeBetweenAttacks;
            for(int i = 0; i < stats[weaponLevel].amount; i++) {
                Instantiate(damager, damager.transform.position, damager.transform.rotation).gameObject.SetActive(true);// tạo ra đạn 
            }
        }
    }
    void SetStatus()
    {
        damager.damage = stats[weaponLevel].damage; // gán sát thương

        damager.lifetime = stats[weaponLevel].duration; // gán thời gian tồn tại

        damager.transform.localScale = Vector3.one * stats[weaponLevel].range; // gán kích thước

        throwCounter = 0f; // đặt lại bộ đếm thời gian ném
    }
}
