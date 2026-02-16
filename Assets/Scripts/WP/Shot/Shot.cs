using UnityEngine;
using UnityEngine.UIElements;

public class Shot : MonoBehaviour
{
    public float moveSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * moveSpeed * Time.deltaTime; // Di chuyển vũ khí theo hướng đã định với tốc độ đã định
    }
}
