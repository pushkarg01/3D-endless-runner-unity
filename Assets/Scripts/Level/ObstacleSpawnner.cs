using UnityEngine;
using System.Collections;

public class ObstacleSpawnner : MonoBehaviour
{
    [SerializeField] GameObject[] obstaclePrefabs;
    [SerializeField] float spawnTime = 2f;
    [SerializeField] float minObsSpawnTime = 1f;
    [SerializeField] Transform obstacleParent;
    [SerializeField] float spawnWidth = 4f;
    private void Start()
    {
        StartCoroutine(SpawnObstacle());
    }

    public void DecreaseObsSpawnTime(float amount)
    {
        spawnTime -= amount;
        if (spawnTime < minObsSpawnTime)
        {
            spawnTime = minObsSpawnTime;
        }
    }

   IEnumerator SpawnObstacle()
    {
        while (true)
        {
            GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            Vector3 spawnPos = new Vector3(Random.Range(-spawnWidth, spawnWidth),transform.position.y,transform.position.z);

            yield return new WaitForSeconds(spawnTime);
            Instantiate(obstaclePrefab, spawnPos,Random.rotation, obstacleParent);
            
        }
    }
}
