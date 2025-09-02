using System.Collections.Generic;
using UnityEngine;

public class DamageNumberController : MonoBehaviour
{
    public static DamageNumberController Instance; // singleton instance
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        Instance = this;
    }
    public DamageNumber prefab; // prefab của số sát thương
    public Transform numberCanvas; // canvas chứa số sát thương

    private List<DamageNumber> damageNumbers = new List<DamageNumber>(); // danh sách các số sát thương đã tạo

    // Update is called once per frame
    public void KhoiTaoSoSatThuong(float valueDamage, Vector3 location)
    {
        int rounded = Mathf.RoundToInt(valueDamage); // làm tròn giá trị sát thương
        DamageNumber damageNumber = GetDamageNumberCanvas(); // tạo số sát thương mới
        damageNumber.SetDamageValue(rounded); // đặt giá trị sát thương cho số sát thương
        damageNumber.gameObject.SetActive(true); // kích hoạt số sát thương
        damageNumber.transform.position = location; // đặt vị trí của số sát thương
    }
    public DamageNumber GetDamageNumberCanvas() // ds luu trữ số sát thương
    {
        DamageNumber listDamageNumberCanvas = null;
        if (damageNumbers.Count == 0)
        {
            listDamageNumberCanvas = Instantiate(prefab, numberCanvas); // tạo một số sát thương mới nếu danh sách rỗng
        }
        else
        {
            listDamageNumberCanvas = damageNumbers[0];
            damageNumbers.RemoveAt(0); // lấy số sát thương đầu tiên từ danh sách
        } // lấy số sát thương đầu tiên từ danh sách
        return listDamageNumberCanvas; // trả về số sát thương từ canvas
    }
    public void DSListLuuTru(DamageNumber numberLuuTru) // lưu trữ số thiệt hại vào danh sách
    {
        numberLuuTru.gameObject.SetActive(false); // ẩn số sát thương đã lưu trữ

        damageNumbers.Add(numberLuuTru); // thêm số sát thương vào danh sách nếu chưa có
    }
}
