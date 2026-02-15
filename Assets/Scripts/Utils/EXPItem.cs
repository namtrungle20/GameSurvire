using UnityEngine;

public class EXPItem : MonoBehaviour
{
    public int expValue;
    private bool moveToPlayer;
    public float moveSpeed;

    public float timeBetweenCheck;
    private float checkCounter;
    private PlayerController player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = PlayerHeathController.Instance.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveToPlayer == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            checkCounter -= Time.deltaTime;
            if (checkCounter <= 0)
            {
                checkCounter = timeBetweenCheck;
                if (Vector3.Distance(transform.position, player.transform.position) < player.itemRange) // khoảng cách người chơi đến gần tầm EXPItem
                {
                    moveToPlayer = true;
                    moveSpeed += player.moveSpeed;
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ExperienceLevelController.instance.getExp(expValue);
            Destroy(gameObject);
        }
    }
}
