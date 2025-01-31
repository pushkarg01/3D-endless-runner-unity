using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] float checkPointTimeIncrease = 5f;
    [SerializeField] float obsTimeDecrease = 5f;

    GameManager gameManager;
    ObstacleSpawnner spawnner;

    private void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        spawnner = FindFirstObjectByType<ObstacleSpawnner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag ("Player"))
        {
            gameManager.IncreaseTime(checkPointTimeIncrease);
            AudioManager.instance.CheckPointSound();
            spawnner.DecreaseObsSpawnTime(obsTimeDecrease);
        }
    }
}
