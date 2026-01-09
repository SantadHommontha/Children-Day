using UnityEngine;
using System.Collections.Generic;




public class Spawner : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GameObject prefabToSpawn;
    [SerializeField] private GameObject prefabToSpawnalp;
    [SerializeField] private BoxCollider2D spawnArea; 
    [SerializeField] private int maxObjects = 10;
    [SerializeField] private float minDistanceBetween = 1.5f; 
    [SerializeField] private float spawnInterval = 1.0f;
    [SerializeField] private LayerMask layerMask;

   

    [Header("Runtime Info")]
    public List<GameObject> spawnedObjects = new List<GameObject>();


    [Header("Debug")]
    [SerializeField] private bool showGizmos = false;
     private Vector2 randomPos_debug;
    void Start()
    {

        // เริ่มต้นเรียกใช้การ Spawn ซ้ำๆ ตามเวลาที่กำหนด
        InvokeRepeating(nameof(SpawnObject), 0f, spawnInterval);
    }

    void SpawnObject()
    {
       
        spawnedObjects.RemoveAll(item => item == null);
        if (spawnedObjects.Count >= maxObjects) return;
       
        Vector2 randomPos = GetRandomPosition();
      
       
        Collider2D hit = Physics2D.OverlapCircle(randomPos, minDistanceBetween, layerMask);
       
        if (hit == null)
        {
           
            GameObject newObj = Instantiate(prefabToSpawn, randomPos, Quaternion.identity);
            spawnedObjects.Add(newObj);
        }
    }

    Vector2 GetRandomPosition()
    {
        Bounds bounds = spawnArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        return new Vector2(x, y);
    }

    private void OnDrawGizmosSelected()
    {
        if (!showGizmos) return;
        Gizmos.color = Color.red;

        Gizmos.DrawSphere(randomPos_debug, minDistanceBetween);
    }
}
