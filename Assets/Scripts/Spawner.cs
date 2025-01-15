using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField] 
    private GameObject tankPrefab;
    
    [SerializeField]
    private Vector2 spawnInterval = new Vector2(1, 3);
    [SerializeField]
    private float spawnZRange = 5;
    [SerializeField]
    private int maxEnemies = 10;
    
    private void Start()
    {
        SpawnEnemy();
    }
    
    private void SpawnEnemy()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < maxEnemies)
        {
            var randomNumber = Random.value;
            SpawnPrefab(randomNumber < 0.1f ? tankPrefab : enemyPrefab);
        }
        Invoke(nameof(SpawnEnemy), Random.Range(spawnInterval.x, spawnInterval.y));
    }
    
    private void SpawnPrefab(GameObject prefab)
    {
        var enemy = Instantiate(prefab, transform.position, Quaternion.identity);
        enemy.transform.position += new Vector3(0, 0, Random.Range(-spawnZRange, spawnZRange));
    }
}
