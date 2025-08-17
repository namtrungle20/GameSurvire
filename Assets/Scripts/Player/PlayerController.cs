using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform target; // Biến để lưu trữ đối tượng người chơi
    private Vector3 moveInput; // Biến để lưu trữ đầu vào di chuyển
    public float moveSpeed; // Tốc độ di chuyển của người chơi
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveInput = Vector3.zero; // Reset đầu vào di chuyển mỗi khung hình
        target = PlayerHeathController.Instance.transform; // Lấy đối tượng người chơi từ PlayerHeathController
    }

    // Update is called once per frame
    void Update()
    {
        InputManager();
        AnimationController();
    }
    protected void InputManager()
    {
        
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize(); // Chuẩn hóa đầu vào di chuyển

        transform.position += moveInput * moveSpeed * Time.deltaTime; // Di chuyển người chơi theo đầu vào
    }
    protected void AnimationController()
    {
        if (moveInput != Vector3.zero)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }
}
