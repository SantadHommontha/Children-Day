using UnityEngine;
using System.Collections.Generic;
using System.Collections;




public class Spawner : MonoBehaviour
{
   [Header("References")]
    public SpriteRenderer spawnAreaSquare;
    public GameObject prefabToSpawn;

    [Header("Settings")]
    public int maxObjects = 10;
    public float minDistanceBetween = 1.2f;
    public float spawnInterval = 0.5f;

    [Header("Status")]
    public bool isSpawning = false; 

    private List<GameObject> spawnedObjects = new List<GameObject>();
    private float timer;

    void Update()
    {
       
        if (isSpawning)
        {
            timer += Time.deltaTime;
            if (timer >= spawnInterval)
            {
                TrySpawn();
                timer = 0;
            }
        }
    }

    public void ClearSpawn()
    {
        for(int i =0;i<spawnedObjects.Count;i++)
        {
            Destroy(spawnedObjects[i].gameObject);
        }
        spawnedObjects.Clear();
    }
  
    public void StartSpawning()
    {
        isSpawning = true;
        Debug.Log("Spawn Started");
    }

    public void StopSpawning()
    {
        isSpawning = false;
        Debug.Log("Spawn Stopped");
    }

    void TrySpawn()
    {
      
        spawnedObjects.RemoveAll(item => item == null);

       
        if (spawnedObjects.Count >= maxObjects) return;

     
        Bounds bounds = spawnAreaSquare.bounds;

      
        for (int i = 0; i < 15; i++) 
        {
            float randomX = Random.Range(bounds.min.x, bounds.max.x);
            float randomY = Random.Range(bounds.min.y, bounds.max.y);
            Vector2 spawnPos = new Vector2(randomX, randomY);

           
            if (Physics2D.OverlapCircle(spawnPos, minDistanceBetween) == null)
            {
                GameObject newObj = Instantiate(prefabToSpawn, spawnPos, Quaternion.identity);
                spawnedObjects.Add(newObj);
                break; 
            }
        }
    }
}
