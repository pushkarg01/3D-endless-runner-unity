using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class LevelGengerator : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject[] chunkPrefabs;
    [SerializeField] GameObject checkPointPrefab;
    [SerializeField] Transform chunkParent;
    [SerializeField] CameraController cameraController;
    [SerializeField] ScoreManager scoreManager;

    [Header("Level Settings")]
    [SerializeField] int startingChunksAmount = 12;
    [SerializeField] int checkPointInterval = 10;
    [SerializeField] float chunkLength = 10f;
    [SerializeField] float moveSpeed = 8f;
    [SerializeField] float minMoveSpeed = 2f;
    [SerializeField] float maxMoveSpeed = 20f;
    [SerializeField] float minGravityZ = -22f;
    [SerializeField] float maxGravityZ = -2f;

    List<GameObject> chunks= new List<GameObject>();
    int chunkSpawned = 0;

    void Start()
    {
        SpawnStartingChunks();
    }

    private void Update()
    {
        MoveChunks();
    }

    public void ChangeChunkSpeed(float speedAmount)
    {
        float newMoveSpeed = moveSpeed + speedAmount;
        newMoveSpeed = Mathf.Clamp(newMoveSpeed,minMoveSpeed,maxMoveSpeed);

        if (newMoveSpeed !=moveSpeed)
        {
            moveSpeed = newMoveSpeed;

            float newGravityZ = Physics.gravity.z - speedAmount;
            newGravityZ = Mathf.Clamp(newGravityZ,minGravityZ,maxGravityZ);

            Physics.gravity = new Vector3(Physics.gravity.x, Physics.gravity.y, Physics.gravity.z - speedAmount);

            cameraController.ChangeCameraPOV(speedAmount);
        }
    }

    private void SpawnStartingChunks()
    {
        for (int i = 0; i < startingChunksAmount; i++)
        {
            SpawnChunk();
        }
    }

   void SpawnChunk()
    {
        float spwanPosZ = ChunkSpawnPositionZ();

        Vector3 chunkSpawnPos = new Vector3(transform.position.x, transform.position.y, spwanPosZ);
        GameObject chunkToSpawn = ChooseChunkToSpawn();

        GameObject newChunkGO = Instantiate(chunkToSpawn, chunkSpawnPos, Quaternion.identity, chunkParent);
        chunks.Add(newChunkGO);
        Chunk newChunk = newChunkGO.GetComponent<Chunk>();
        newChunk.Init(this, scoreManager);

        chunkSpawned++;
    }

    private GameObject ChooseChunkToSpawn()
    {
        GameObject chunkToSpawn;
        if (chunkSpawned % checkPointInterval == 0 && chunkSpawned !=0)
        {
            chunkToSpawn = checkPointPrefab;
        }
        else
        {
            chunkToSpawn = chunkPrefabs[Random.Range(0, chunkPrefabs.Length)];
        }

        return chunkToSpawn;
    }

    private float ChunkSpawnPositionZ()
    {
        float spwanPosZ;
        if (chunks.Count == 0)
        {
            spwanPosZ = transform.position.z;
        }
        else
        { 
            spwanPosZ = chunks[chunks.Count - 1].transform.position.z + chunkLength;
        }

        return spwanPosZ;
    }

    void MoveChunks()
    {
        for (int i = 0; i < chunks.Count; i++)
        {
            GameObject chunk = chunks[i];
            chunk.transform.Translate(-transform.forward * (moveSpeed * Time.deltaTime));

            if(chunk.transform.position.z <= Camera.main.transform.position.z - chunkLength)
            {
                chunks.Remove(chunk);
                Destroy(chunk);
                SpawnChunk();
            }
        }
    }
}
