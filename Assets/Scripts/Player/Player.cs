using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player instance; //doi tuong trien khai
    public Vector3 moveDir;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    public float moveSpeed = 5f;
    public float PlayerMaxHealth;
    public float PLayerHeart;

    private bool isImmune; // bien kiem soat trang thai mien dich
    [SerializeField] private float immuneTime; // thoi gian mien dich
    [SerializeField] private float immunetyDuration; // thoi gian bat dau mien dich
    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();


    }
    // Start is called before the first frame update
    void Start()
    {
        PLayerHeart = PlayerMaxHealth;
        UIController.Instance.UpdatePlayerHeartSlider(PLayerHeart, PlayerMaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        InputManager();
    }
    void FixedUpdate()
    {
        MovePlayer();
        CheckXoay();
    }
    //Update
    void InputManager()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveX, moveY).normalized;

        if(immuneTime > 0)
        {
            immuneTime -= Time.deltaTime; // giam thoi gian mien dich
        }
        else
        {
            isImmune = false; // ket thuc trang thai mien dich
        }

    }
    //FixedUpdate 
    void MovePlayer()
    {
        rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
    }
    void CheckXoay()
    {
        if (moveDir.x > 0)
        {
            sr.flipX = false;
        }
        else if (moveDir.x < 0)
        {
            sr.flipX = true;
        }
    }
    public void TakeDamage(float damage)
    {
        if (!isImmune)
        {
            isImmune = true; // bat dau trang thai mien dich
            immuneTime = immunetyDuration;

            PLayerHeart -= damage;
            UIController.Instance.UpdatePlayerHeartSlider(PLayerHeart, PlayerMaxHealth);
            if (PLayerHeart <= 0)
            {
                gameObject.SetActive(false);
                GameManager.Instance.GameOver();
            }
        }
    }
}
