using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ThrownWeapon : MonoBehaviour
{
    public float throwPower; // Lực ném
    public Rigidbody2D rb; // Thành phần Rigidbody2D của vũ khí

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = gameObject.AddComponent<Rigidbody2D>(); // Thêm thành phần Rigidbody2D nếu chưa có
        // rb.velocity = new Vector2(Random.Range(-throwPower, throwPower), throwPower); // Đặt vận tốc ban đầu cho vũ khí

    }

    // Update is called once per frame
    void Update()
    {

    }
}
