using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WP_Controller : MonoBehaviour
{
    public GameObject perfab;
    public float damage; // Sát thương
    public float speed; // Tốc độ
    public float cooldown; // hồi chiêu
    float cooldownTime; // Thời gian hồi chiêu
    public int pierce; // Số lần xuyên thấu
    // Start is called before the first frame update
    virtual protected void Start()
    {
        cooldownTime = cooldown;
    }

    // Update is called once per frame
    virtual protected void Update()
    {
        cooldownTime -= Time.deltaTime;
        if(cooldownTime <= 0)
        {
            Attack();
        }
    }
    virtual protected void Attack()
    {
        cooldownTime = cooldown;
    }
}
