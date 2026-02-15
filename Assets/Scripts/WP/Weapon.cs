using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public List<WeaponStats> stats;
    public int weaponLevel;
    public Sprite icon;

    [HideInInspector]
    public bool statsUpdated; // Biến để kiểm tra xem các chỉ số đã được cập nhật hay chưa
    public void LevelUp()
    {
        if (weaponLevel < stats.Count - 1)
        {
            weaponLevel++;
            statsUpdated = true;
            if (weaponLevel >= stats.Count - 1)
            {
                PlayerController.Instance.fullyLevelWeapons.Add(this);
                PlayerController.Instance.assignedWeapons.Remove(this);
            }
        }
    }

}
[System.Serializable]
public class WeaponStats
{
    public float speed, damage, range, timeBetweenAttacks, amount, duration; //toc do, sat thuong, tam tan con, thoi gian giua cac don danh, so luong, khoang thoi gian;
    public string upgradeText;
}