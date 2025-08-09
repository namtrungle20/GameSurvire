using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int weaponLevels; // Cấp độ của vũ khí
    public List<WeaponStats> stats; // Danh sách thông số vũ khí
    public Sprite weaponImage; // Biểu tượng vũ khí
    public void levelUp()
    {
        if (weaponLevels >= stats.Count - 1)
        {
            weaponLevels++; // Cập nhật cấp độ vũ khí theo cấp độ người chơi
        }
    }
}

[System.Serializable]
public class WeaponStats
{
    public float cooldown; // thời gian nạp lại
    public float duration; // thời gian tồn tại của vũ khí
    public float damage; // sát thương của vũ khí
    public float range;
    public float speed; // tốc độ của vũ khí
    public string information; // thông tin về vũ khí
}