using UnityEngine;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] GameObject[] ChunkPrefabs;
    public float chunkHeight = 30f;

    const float spawnOffset = 60f;
    Vector2 currentOffset = Vector2.zero;
    Queue<GameObject> chunkQueue = new Queue<GameObject>();

    void Update()
    {
        if (player.position.y + spawnOffset > currentOffset.y)
        {
            SpawnNextChunk();
        }
    }

    void SpawnNextChunk()
    {
        var chunk = ChunkPrefabs[Random.Range(0, ChunkPrefabs.Length)];
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
