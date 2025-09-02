using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ExperienceLevelController : MonoBehaviour
{
    public static ExperienceLevelController instance;
    private void Awake()
    {
        instance = this;
    }
    public EXPItem prefeb;
    public int statusExperience;
    public List<int> expLevels;
    public int level = 1, levelCount = 30;
    public List<Weapon> weaponsToUpgrade; // danh sách vũ khí để nâng cấp
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        while (expLevels.Count < levelCount)
        {
            expLevels.Add(Mathf.CeilToInt(expLevels[expLevels.Count - 1] * 1f)); // up level len +5
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void getExp(int getExp)
    {
        statusExperience += getExp;
        if (statusExperience >= expLevels[level])
        {
            LevelUp();
        }
        UIController.Instance.UpdateExperience(statusExperience, expLevels[level], level);
    }
    public void SpawnExp(Vector3 position, int expValue)
    {
        Instantiate(prefeb, position, Quaternion.identity).expValue = expValue;
    }
    void LevelUp()
    {
        statusExperience -= expLevels[level];
        level++;
        if (level >= expLevels.Count)
        {
            level = expLevels.Count - 1;
        }
        // PlayerController.Instance.activeWeapon.LevelUp();
        UIController.Instance.levelUpPanel.SetActive(true);
        Time.timeScale = 0f;


        weaponsToUpgrade.Clear();
        List<Weapon> allWeapons = new List<Weapon>();
        allWeapons.AddRange(PlayerController.Instance.assignedWeapons);

        if (allWeapons.Count > 0) // Chọn ngẫu nhiên một vũ khí đã gán để nâng cấp
        {
            int randomWP = UnityEngine.Random.Range(0, allWeapons.Count);
            weaponsToUpgrade.Add(allWeapons[randomWP]);
            allWeapons.RemoveAt(randomWP);
        }
        if (PlayerController.Instance.assignedWeapons.Count + PlayerController.Instance.fullyLevelWeapons.Count < PlayerController.Instance.maxWeaponCount) // Nếu số vũ khí đã gán nhỏ hơn giới hạn tối đa thì thêm các vũ khí chưa gán vào danh sách nâng cấp
        {
            allWeapons.AddRange(PlayerController.Instance.unassignedWeapons);
        }

        for (int i = weaponsToUpgrade.Count; i < 3; i++) // Chọn ngẫu nhiên vũ khí chưa gán để thêm vào danh sách nâng cấp gioi hạn tối đa 3 vũ khí
        {
            if (allWeapons.Count > 0)
            {
                int randomWP = UnityEngine.Random.Range(0, allWeapons.Count);
                weaponsToUpgrade.Add(allWeapons[randomWP]);
                allWeapons.RemoveAt(randomWP);
            }
        }
        for (int i = 0; i < weaponsToUpgrade.Count; i++) // Kích hoạt các nút nâng cấp với vũ khí được chọn
        {
            UIController.Instance.levelUpButtons[i].ActivateButton(weaponsToUpgrade[i]);
        }
        for (int i = 0; i < UIController.Instance.levelUpButtons.Length; i++)
        {
            if (i < weaponsToUpgrade.Count)
            {
                UIController.Instance.levelUpButtons[i].gameObject.SetActive(true);
            }
            else
            {
                UIController.Instance.levelUpButtons[i].gameObject.SetActive(false);
            }
        }
    }
}
