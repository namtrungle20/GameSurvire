// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class Player : MonoBehaviour
// {
//     public static Player PlayerInstance;
//     public Vector3 moveInput;
//     [SerializeField] private SpriteRenderer sr;
//     [SerializeField] private Rigidbody2D rb;
//     [SerializeField] private Animator animator;
//     public float moveSpeed = 5f;
//     public float PlayerMaxHealth;
//     public float PLayerHeart;
//     public int experience; // Kinh nghiệm của người chơi
//     public int Level; // Cấp độ của người chơi
//     public int maxLevel; // Cấp độ tối đa của người chơi
//     public List<int> playerLevels; // Danh sách cấp độ của người chơi
//     public Weapon activeWeapon;

//     private bool isImmune; // bien kiem soat trang thai mien dich
//     [SerializeField] private float immuneTime; // thoi gian mien dich
//     [SerializeField] private float immunetyDuration; // thoi gian bat dau mien dich




//     // Start is called before the first frame update
//     void Awake()
//     {
//         if (PlayerInstance != null && PlayerInstance != this)
//         {
//             Debug.LogError("There is more than one Player in the scene");
//             Destroy(this);
//         }
//         else
//         {
//             PlayerInstance = this;
//         }
//         rb = GetComponent<Rigidbody2D>();
//         sr = GetComponent<SpriteRenderer>();


//     }
//     // Start is called before the first frame update
//     void Start()
//     {
//         for (int i = playerLevels.Count; i < maxLevel; i++)
//         {
//             playerLevels.Add(Mathf.CeilToInt(playerLevels[playerLevels.Count - 1] * 1f + 5)); // Giả sử mỗi cấp độ cần 100 kinh nghiệm
//         }
//         PLayerHeart = PlayerMaxHealth;
//         UIController.Instance.UpdatePlayerHeartSlider();
//         UIController.Instance.UpdatePlayerExperieceSlider();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         InputManager();
//         AnimationController();
//     }
//     void FixedUpdate()
//     {
//         // MovePlayer();
//         CheckXoay();
//     }
//     //Update
//     void InputManager()
//     {
//         moveInput.x = Input.GetAxisRaw("Horizontal");
//         moveInput.y = Input.GetAxisRaw("Vertical");

//         moveInput.Normalize(); // Chuẩn hóa đầu vào di chuyển
//         rb.linearVelocity = new Vector3(moveInput.x * moveSpeed, moveInput.y * moveSpeed);

//         Debug.Log($"Player Move Input: {moveInput}");

//         if (immuneTime > 0)
//         {
//             immuneTime -= Time.deltaTime; // giam thoi gian mien dich
//         }
//         else
//         {
//             isImmune = false; // ket thuc trang thai mien dich
//         }

//     }
//     void AnimationController()
//     {
//         if(moveInput != Vector3.zero)
//         {
//             animator.SetBool("isMoving", true);
//         }
//         else
//         {
//             animator.SetBool("isMoving", false);
//         }
//     }
//     //FixedUpdate 
//     // void MovePlayer()
//     // {
//     //     rb.linearVelocity = new Vector3(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
//     // }
//     void CheckXoay()
//     {
//         if (moveInput.x > 0)
//         {
//             sr.flipX = false;
//         }
//         else if (moveInput.x < 0)
//         {
//             sr.flipX = true;
//         }
//     }
//     public void TakeDamage(float damage)
//     {
//         if (!isImmune)
//         {
//             isImmune = true; // bat dau trang thai mien dich
//             immuneTime = immunetyDuration;

//             PLayerHeart -= damage;
//             UIController.Instance.UpdatePlayerHeartSlider();
//             if (PLayerHeart <= 0)
//             {
//                 gameObject.SetActive(false);
//                 GameManager.instance.GameOver(); // goi ham ket thuc tro choi
//             }
//         }
//     }
//     public void GetKinhNghiem(int getexp)
//     {
//         experience += getexp; // Cộng kinh nghiệm cho người chơi
//         UIController.Instance.UpdatePlayerExperieceSlider();
//         if (experience >= playerLevels[Level - 1])
//         {
//             LevelUp();
//         }
//     }
//     public void LevelUp()
//     {
//         Level++;
//         experience = 0; // Đặt lại kinh nghiệm sau khi lên cấp
//         UIController.Instance.UpdatePlayerExperieceSlider();
//         UIController.Instance.levelUpButtons[0].ActivateButton(activeWeapon); // Cập nhật thông tin vũ khí trên giao diện
//         UIController.Instance.LevelUpPanelOpen(); // Mở giao diện lên cấp
//     }
// }
