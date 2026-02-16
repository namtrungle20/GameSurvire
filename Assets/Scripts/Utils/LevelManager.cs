using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance; // singleton instance
    void Awake()
    {
        Instance = this; // set the singleton instance
    }

    private bool gameActive; // Trạng thái của trò chơi (đang hoạt động hay không)
    public float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameActive == true)
        {
            timer += Time.deltaTime; // Cập nhật thời gian chơi
            UIController.Instance.UpdateTimer(timer); // Cập nhật giao diện người dùng để hiển thị thời gian chơi
        }
    }
    public void EndLevel()
    {
        gameActive = false; // Kết thúc trò chơi
    }
}
