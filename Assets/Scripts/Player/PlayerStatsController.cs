using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsController : MonoBehaviour
{
    public static PlayerStatsController Instance; // singleton instance
    void Awake()
    {
        Instance = this; // set the singleton instance
    }
    public List<PlayerStatsValue> moveSpeed, health, pickUpRange, maxWeapon;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

[System.Serializable]
public class PlayerStatsValue
{
    public int cost; // chi phí nâng cấp
    public float value; // giá trị nâng cấp
}
