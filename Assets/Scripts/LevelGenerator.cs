using UnityEngine;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] GameObject[] InitialChunkPrefabs;
    [SerializeField] GameObject[] ChunkPrefabs;
    public float chunkHeight = 30f;
    public float spawnOffset = 60f;

    Vector2 currentOffset = Vector2.zero;
    Queue<GameObject> chunkQueue = new Queue<GameObject>();
    int chunkIndex = 0;

    void Update()
    {
        if (player.position.y + spawnOffset > currentOffset.y)
        {
            SpawnNextChunk();
        }
    }

    void SpawnNextChunk()
    {
        var chunk = chunkIndex < InitialChunkPrefabs.Length ?
            InitialChunkPrefabs[chunkIndex] : 
            ChunkPrefabs[Random.Range(0, ChunkPrefabs.Length)];
        
        chunkIndex += 1;

        var instance = Instantiate(chunk, currentOffset, Quaternion.identity, transform);
        currentOffset.y += chunkHeight;
        chunkQueue.Enqueue(instance);
        if (chunkQueue.Count > 3) DespawnFirstChunk();
    }

    void DespawnFirstChunk()
    {
        var firstChunk = chunkQueue.Dequeue();
        Destroy(firstChunk);
    }
}