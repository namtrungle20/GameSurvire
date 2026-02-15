using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    private void Awake()
    {
        Instance = this;
    }
    private Transform target; // Biến để lưu trữ đối tượng người chơi
    private Vector3 moveInput; // Biến để lưu trữ đầu vào di chuyển
    public float moveSpeed; // Tốc độ di chuyển của người chơi
    public float itemRange;
    public int maxWeaponCount = 3;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    // public Weapon activeWeapon;
    public List<Weapon> unassignedWeapons, assignedWeapons; // danh sách vũ khí chưa gán và đã gán

    [HideInInspector]
    public List<Weapon> fullyLevelWeapons = new List<Weapon>(); // danh sách vũ khí đã đạt cấp tối đa


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (assignedWeapons.Count == 0)
        {
            AddWeapon(Random.Range(0, unassignedWeapons.Count));
        }
        moveInput = Vector3.zero; // Reset đầu vào di chuyển mỗi khung hình
        target = PlayerHeathController.Instance.transform; // Lấy đối tượng người chơi từ PlayerHeathController
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
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
    public void AddWeapon(int weaponNumber)
    {
        if (weaponNumber < unassignedWeapons.Count)
        {
            assignedWeapons.Add(unassignedWeapons[weaponNumber]);
            unassignedWeapons[weaponNumber].gameObject.SetActive(true);
            unassignedWeapons.RemoveAt(weaponNumber);
        }
    }
    public void AddWeapon(Weapon weaponToAdd)
    {
        weaponToAdd.gameObject.SetActive(true);
        assignedWeapons.Add(weaponToAdd);
        unassignedWeapons.Remove(weaponToAdd);
    }
}
