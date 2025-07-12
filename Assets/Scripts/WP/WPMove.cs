using UnityEngine;

public class WPMove : MonoBehaviour
{

    [SerializeField] protected float moveSpeed = 5f; // Tốc độ di
    public AreaWeapon areaWeapon; // Tham chiếu đến vũ khí khu vực
    public float timer;


    void Start()
    {
        // Lấy hướng di chuyển từ vũ khí khu vực
        areaWeapon = GameObject.FindObjectOfType<AreaWeapon>();
        timer = areaWeapon.duration; // Lấy thời gian tồn tại của vũ khí khu vực
    }
    void Update()
    {
        Move(); // Gọi hàm di chuyển
    }
    protected virtual void Move()
    {
        transform.position += transform.right * moveSpeed * Time.deltaTime; // Di chuyển vũ khí theo hướng hiện tại
       timer -= Time.deltaTime; // Giảm thời gian tồn tại
        if (timer <= 0)
        {
            Destroy(gameObject); // Hủy vũ khí khi hết thời gian tồn tại
        }
    }
}
