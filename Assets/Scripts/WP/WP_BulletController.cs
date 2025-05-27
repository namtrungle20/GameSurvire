using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WP_BulletController : WP_Controller
{
    // Start is called before the first frame update
    protected override void Start()
    {
       base.Start(); 
    }

    // Update is called once per frame
    protected override void Attack()
    {
        base.Attack();
        GameObject bullet = Instantiate(perfab);
        bullet.transform.position = transform.position;
    }
}
