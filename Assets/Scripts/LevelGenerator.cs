using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] GameObject[] ChunkPrefabs;
    public float chunkHeight = 30f;
    public float spawnOffset = 60f;
    [SerializeField] private float snowDistance;
    
    Vector2 currentOffset = Vector2.zero;
    Queue<GameObject> chunkQueue = new Queue<GameObject>();
    [SerializeField] private List<SpriteRenderer> platformSprites;

    [SerializeField] Sprite frozenGrassSprite;
    [SerializeField] Sprite freshGrassSprite;

    void Update()
    {
        if (player.position.y + spawnOffset > currentOffset.y)
        {
            SpawnNextChunk();
        }

        foreach (var sprite in platformSprites)
		{
            if (sprite != null)
			{
                sprite.gameObject.transform.localScale = Vector3.one;
                var platformCollider = sprite.gameObject.GetComponent<BoxCollider2D>();
                platformCollider.size = new Vector2(3, 1);
                if (sprite.transform.position.y - GameManager.Snow.transform.position.y < snowDistance)
                {
                    sprite.sprite = frozenGrassSprite;
                }
                else
                    sprite.sprite = freshGrassSprite;
            }
		}    
    }

    void SpawnNextChunk()
    {
        var chunk = ChunkPrefabs[UnityEngine.Random.Range(0, ChunkPrefabs.Length)];
        var instance = Instantiate(chunk, currentOffset, Quaternion.identity, transform);
        currentOffset.y += chunkHeight;
        chunkQueue.Enqueue(instance);

        UpdateSpriteList();

        if (chunkQueue.Count > 3) DespawnFirstChunk();
    }

    void DespawnFirstChunk()
    {
        var firstChunk = chunkQueue.Dequeue();
        Destroy(firstChunk);
        UpdateSpriteList();
    }

	private void UpdateSpriteList()
	{
        var tempSpriteArray = GetComponentsInChildren<SpriteRenderer>();
        platformSprites = tempSpriteArray.ToList();
    }
}
