using System.Threading;
using UnityEngine;

public class AreaWeapon : MonoBehaviour
{
    
    [SerializeField] protected GameObject prefab;
    private float spawnCounter; // thời gian phản hồi
    public float cooldown;
    public float duration;

    void FixedUpdate()
    {
        spawnCounter -= Time.deltaTime;
        if (spawnCounter <= 0)
        {
            spawnCounter = cooldown; // thời gian nạp lại
           Instantiate(prefab, transform.position, transform.rotation);
        }
    }
    
}
