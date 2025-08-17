using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // prefab enemy
    public float timeToSpawn; // khoảng thời gian tạo enemy
    private float spawnConter; // bộ đếm thời gian tạo enemy
    public Transform MinPos, MaxPos; // vị trí tối thiểu để tạo enemy
    private Transform target; // đối tượng người chơi
    private float desman; // khoảng cách để hủy enemy
    private List<GameObject> spawnedEnemies = new List<GameObject>(); // danh sách các enemy đã được tạo
    public int checkPerFrame; // số lượng enemy kiểm tra mỗi khung hình
    private int enemyToCheck; // số lượng enemy cần kiểm tra trong mỗi khung hình

    void Start()
    {
        spawnConter = timeToSpawn; // khởi tạo bộ đếm thời gian
        target = PlayerHeathController.Instance.transform; // lấy đối tượng người chơi
        desman = Vector3.Distance(transform.position, MaxPos.position) + 4f; // tính khoảng cách để hủy enemy
    }

    void Update()
    {
        spawnConter -= Time.deltaTime; // giảm bộ đếm thời gian
        if (spawnConter <= 0f)
        {
            spawnConter = timeToSpawn; // đặt lại bộ đếm thời gian
            GameObject newEnemy = Instantiate(enemyPrefab, SelectSpawnPoint(), transform.rotation); // tạo enemy mới tại vị trí ngẫu nhiên
            spawnedEnemies.Add(newEnemy); // thêm enemy mới vào danh sách
        }
        transform.position = target.position; // cập nhật vị trí của EnemySpawner theo vị trí người chơi
        int checkTarget = enemyToCheck + checkPerFrame; // tính số lượng enemy cần kiểm tra trong mỗi khung hình

        while (enemyToCheck < checkTarget)
        {
            if (enemyToCheck < spawnedEnemies.Count)
            {
                if (spawnedEnemies[enemyToCheck] != null)
                {
                    if (Vector3.Distance(transform.position, spawnedEnemies[enemyToCheck].transform.position) > desman) // kiểm tra khoảng cách với enemy
                    {
                        Destroy(spawnedEnemies[enemyToCheck]); // hủy enemy nếu khoảng cách lớn hơn desman
                        spawnedEnemies.RemoveAt(enemyToCheck); // loại bỏ enemy khỏi danh sách
                        checkTarget--; // giảm chỉ số để kiểm tra lại vị trí hiện tại
                    }
                    else
                    {
                        enemyToCheck++; // tăng số lượng enemy cần kiểm tra
                    }
                }
                else
                {
                    spawnedEnemies.RemoveAt(enemyToCheck); // loại bỏ enemy đã bị hủy
                    checkTarget--; // giảm chỉ số để kiểm tra lại vị trí hiện tại
                }
            }
            else
            {
                enemyToCheck = 0; // đặt lại số lượng enemy cần kiểm tra
                checkTarget = 0; // đặt lại số lượng enemy cần kiểm tra
            }
        }
    }

    // protected void CheckEnemy()
    // {
        
    // }
    public Vector3 SelectSpawnPoint()
    {
        Vector3 spawnPoint = Vector3.zero; // khởi tạo điểm tạo enemy
        bool spawnVerticalEdge = Random.Range(0f, 1f) > 5f; // xác định xem có tạo enemy ở cạnh dọc hay ngang

        if (spawnVerticalEdge)
        {
            spawnPoint.y = Random.Range(MinPos.position.y, MaxPos.position.y); // chọn vị trí dọc ngẫu nhiên
            if (Random.Range(0f, 1f) > 0.5f)
            {
                spawnPoint.x = MinPos.position.x; // chọn vị trí ngang tối thiểu
            }
            else
            {
                spawnPoint.x = MaxPos.position.x; // chọn vị trí ngang tối đa
            }
        }
        else
        {
            spawnPoint.y = Random.Range(MinPos.position.y, MaxPos.position.y); // chọn vị trí dọc ngẫu nhiên
            if (Random.Range(0f, 1f) > 0.5f)
            {
                spawnPoint.x = MinPos.position.x; // chọn vị trí ngang tối thiểu
            }
            else
            {
                spawnPoint.x = MaxPos.position.x; // chọn vị trí ngang tối đa
            }
        }
        return spawnPoint; // trả về điểm tạo enemy
    }
}
