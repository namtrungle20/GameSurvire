using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform player; // Biến để lưu trữ đối tượng người chơi
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Tìm đối tượng người chơi theo tag
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z); // Cập nhật vị trí camera theo vị trí người chơi
    }
}
