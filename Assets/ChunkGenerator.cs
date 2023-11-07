using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkGenerator : MonoBehaviour
{

    public Transform player;
    public ChunkObject chunkObject;
    public float chunkSize = 100.0f; // Adjust this to your needs.
    public int loadDistance = 5; // Adjust this to control how many chunks are loaded around the player.

    private Vector3 lastPlayerPosition;

    private void Start()
    {
        lastPlayerPosition = player.position;
        GenerateChunksAroundPlayer();   
    }

    private void Update()
    {
        Vector3 playerMovement = player.position - lastPlayerPosition;

        // Check if the player has moved more than a chunk's width.
        if (Mathf.Abs(playerMovement.x) >= chunkSize || Mathf.Abs(playerMovement.z) >= chunkSize)
        {
            GenerateChunksAroundPlayer();
            lastPlayerPosition = player.position;
        }
    }

    private void GenerateChunksAroundPlayer()
    {
        Vector3 playerPosition = player.position;
        // Calculate the player's current chunk coordinates.
        int playerChunkX = Mathf.FloorToInt(playerPosition.x / chunkSize);
        int playerChunkZ = Mathf.FloorToInt(playerPosition.z / chunkSize);

        // Load chunks within the loadDistance around the player.
        for (int x = -loadDistance; x <= loadDistance; x++)
        {
            for (int z = -loadDistance; z <= loadDistance; z++)
            {
                Vector3 chunkPosition = new Vector3(
                    (playerChunkX + x) * chunkSize,
                    0,
                    (playerChunkZ + z) * chunkSize
                );

                // Instantiate a new chunk if it doesn't exist.
                if (!ChunkExistsAtPosition(chunkPosition))
                {
                    ChunkObject chunk = Instantiate(chunkObject, chunkPosition, Quaternion.identity);
                    loadedChunks.Add(chunk);
                }
            }
        }
    }

    public  List<ChunkObject> loadedChunks = new List<ChunkObject>();

    // ...

    private bool ChunkExistsAtPosition(Vector3 position)
    {
        // Check if a chunk exists at the given position by comparing positions.
        foreach (ChunkObject chunk in loadedChunks)
        {
            if (chunk != null) // Make sure the chunk hasn't been destroyed.
            {
                if (Vector3.Distance(chunk.transform.position, position) < chunkSize)
                {
                    return true; // A chunk exists at this position.
                }
            }
        }

        return false; // No chunk exists at this position.
    }

   
}
