using UnityEngine;

public class DamageNumberController : MonoBehaviour
{
    public static DamageNumberController Instance; // singleton instance
    public DamageNumber prefab; // prefab của số sát thương
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    public void KhoiTaoSoSatThuong(float value, Vector3 location)
    {
        DamageNumber damageNumber = Instantiate(prefab, location, transform.rotation, transform); // tạo số sát thương mới
        damageNumber.SetDamageValue(Mathf.RoundToInt(value)); // thiết lập giá trị sát thương
    }
}
