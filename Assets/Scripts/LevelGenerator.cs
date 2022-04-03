using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] GameObject[] ChunkPrefabs;
    public float chunkHeight = 30f;
    public float spawnOffset = 60f;
    public float platformFreezeDistance;

    [SerializeField] Sprite frozenGrassSprite;
    [SerializeField] Sprite freshGrassSprite;

    Vector2 currentOffset = Vector2.zero;
    Queue<GameObject> chunkQueue = new Queue<GameObject>();

    public List<SpriteRenderer> platformSprites = new List<SpriteRenderer>();

    void Update()
    {
        if (player.position.y + spawnOffset > currentOffset.y)
        {
            SpawnNextChunk();
        }

        foreach (SpriteRenderer sprite in platformSprites)
		{
            if (sprite != null)
			{
                sprite.gameObject.transform.localScale = Vector3.one;
                var collider = sprite.GetComponent<BoxCollider2D>();
                collider.size = new Vector2(3, 1);
                if (sprite.transform.position.y - GameManager.Snow.transform.position.y < platformFreezeDistance)
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
        var chunk = ChunkPrefabs[Random.Range(0, ChunkPrefabs.Length)];
        var instance = Instantiate(chunk, currentOffset, Quaternion.identity, transform);
        currentOffset.y += chunkHeight;
        chunkQueue.Enqueue(instance);
        ResetActiveSprites();
        if (chunkQueue.Count > 3) DespawnFirstChunk();
    }

    void DespawnFirstChunk()
    {
        var firstChunk = chunkQueue.Dequeue();
        Destroy(firstChunk);
        ResetActiveSprites();
	}

	void ResetActiveSprites()
	{
        var tempSprites = GetComponentsInChildren<SpriteRenderer>();
        platformSprites = tempSprites.ToList();
	}

}
