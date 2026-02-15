
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelUpButton : MonoBehaviour
{
    public TMP_Text weaponName;
    public TMP_Text weaponInformation;
    public Image weaponIcon;
    private Weapon assignedWeapon; //Vũ khí được chỉ định

    public void ActivateButton(Weapon weapon)
    {
        if (weapon.gameObject.activeSelf == true)
        {
            weaponName.text = weapon.name + "\n" + "Level " + weapon.weaponLevel;
            weaponInformation.text = weapon.stats[weapon.weaponLevel].upgradeText;
            weaponIcon.sprite = weapon.icon;
        }
        else
        {
            weaponInformation.text = "Unlock " + weapon.name;
            weaponIcon.sprite = weapon.icon;
            weaponName.text = weapon.name;
        }

        assignedWeapon = weapon;
    }

    public void SelectUpgrade()
    {
        if (assignedWeapon != null)
        {
            if (assignedWeapon.gameObject.activeSelf == true)
            {
                assignedWeapon.LevelUp();
            }
            else
            {
                PlayerController.Instance.AddWeapon(assignedWeapon);
            }
            
            UIController.Instance.levelUpPanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
