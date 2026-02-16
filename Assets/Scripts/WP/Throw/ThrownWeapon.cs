using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ThrownWeapon : MonoBehaviour
{
    public float throwPower; // Lực ném
    public float rotateSpeed; // Tốc độ xoay
    public Rigidbody2D rb; // Thành phần Rigidbody2D của vũ khí


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.linearVelocity = new Vector2(Random.Range(-throwPower, throwPower), throwPower); // Đặt vận tốc ban đầu cho vũ khí
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z + (rotateSpeed * 360f * Time.deltaTime * Mathf.Sign(rb.linearVelocity.x))); // Xoay vũ khí
    }
}
