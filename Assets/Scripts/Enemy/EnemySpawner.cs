using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public GameObject enemyPrefab; // prefab enemy
        public float spawnTimer; //thoi gian tao enemy
        public float spawnInterval;// khoang thoi gian tao enemy
        public int EnemyWave; // so luong enemy trong wave
        public int EnemyCount; // so luong enemy da tao

    }
    public List<Wave> waves;
    public int WaveNumber;
    public Transform MinPos;
    public Transform MaxPos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Player.PlayerInstance.gameObject.activeSelf)
        {
            waves[WaveNumber].spawnTimer += Time.deltaTime;
            if (waves[WaveNumber].spawnTimer >= waves[WaveNumber].spawnInterval)
            {
                waves[WaveNumber].spawnTimer = 0;
                SpawnEnemy();
            }
            if (waves[WaveNumber].EnemyCount >= waves[WaveNumber].EnemyWave)
            {
                waves[WaveNumber].EnemyCount = 0;
                if (waves[WaveNumber].spawnInterval > 0.3f)
                {
                    waves[WaveNumber].spawnInterval *= 0.9f;
                }
                WaveNumber++;
            }
            if (WaveNumber >= waves.Count)
            {
                WaveNumber = 0;
            }
        }
    }
    private void SpawnEnemy()
    {
        Instantiate(waves[WaveNumber].enemyPrefab, RandomSpawnEnemy(), transform.rotation);
        waves[WaveNumber].EnemyCount++;
    }
    private Vector2 RandomSpawnEnemy()
    {
        Vector2 randomPos;
        if (Random.Range(0f, 1f) > 0.5)
        {
            randomPos.x = Random.Range(MinPos.position.x, MaxPos.position.x);
            if (Random.Range(0f, 1f) > 0.5)
            {
                randomPos.y = MinPos.position.y;
            }
            else
            {
                randomPos.y = MaxPos.position.y;
            }
        }
        else
        {
            randomPos.y = Random.Range(MinPos.position.y, MaxPos.position.y);
            if (Random.Range(0f, 1f) > 0.5)
            {
                randomPos.x = MinPos.position.x;
            }
            else
            {
                randomPos.x = MaxPos.position.x;
            }
        }
        return randomPos;
    }
}
