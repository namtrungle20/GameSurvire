using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpButton : MonoBehaviour
{
    public TMP_Text weaponName;
    public TMP_Text weaponInformation;
    public Image weaponIcon;
    private Weapon getWeapon; // Vũ khí liên kết với nút này


    public void ActivateButton(Weapon weapon)
    {
        weaponName.text = weapon.name;
        weaponInformation.text = weapon.stats[weapon.weaponLevels].information;
        weaponIcon.sprite = weapon.weaponImage;

        getWeapon = weapon; // Lưu vũ khí liên kết với nút này
    }

    public void SelectUpgrade()
    {
        getWeapon.levelUp(); // Tăng cấp vũ khí
        // UIController.Instance.LevelUpPanelClose(); // Đóng bảng nâng cấp
    }
}
