using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WP_HanhVi : MonoBehaviour
{
    protected Vector3 moveDirection; // Di Chuyển hướng
    public float timeDestroy = 2f; // Thời gian hủy đối tượng

    // Start is called before the first frame update
    virtual protected void Start()
    {
        Destroy(gameObject, timeDestroy); //Phá hủy đối tượng trò chơi này sau 'timeDestroy' giây
    }

    // Update is called once per frame
    public void Dirrection(Vector3 direction)
    {
        moveDirection = direction; // Đặt hướng di chuyển
    }
}