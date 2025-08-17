using UnityEngine;

public class SpinWeapon : MonoBehaviour
{
    public Transform holder, fireballToSpawn; // Biến để lưu trữ vị trí của vũ khí và nơi sẽ sinh ra đạn lửa
    public float rotateSpeed;
    public float timeBetweenSpawns; // Thời gian giữa các lần sinh ra đạn lửa
    private float spawnCounter; // Bộ đếm thời gian để sinh ra đạn lửa
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z + (rotateSpeed * Time.deltaTime)); // Xoay vũ khí theo tốc độ đã định
        spawnCounter -= Time.deltaTime; // Giảm bộ đếm thời gian
        if (spawnCounter <= 0f) // Kiểm tra nếu bộ đếm thời gian đã đến 0
        {
            spawnCounter = timeBetweenSpawns; // Đặt lại bộ đếm thời gian
            Instantiate(fireballToSpawn, fireballToSpawn.position, fireballToSpawn.rotation, holder).gameObject.SetActive(true); // Sinh ra đạn lửa tại vị trí và góc của vũ khí
        }
    }
}
