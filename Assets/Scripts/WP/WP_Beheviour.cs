using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WP_Beheviour : WP_HanhVi
{

    WP_Controller bullet;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        bullet = GetComponent<WP_Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveDirection * bullet.speed * Time.deltaTime; // Di chuyển theo hướng đã chỉ định
    }
}