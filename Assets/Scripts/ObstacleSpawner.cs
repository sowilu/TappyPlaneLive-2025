using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public List<GameObject> obstaclePrefabs;
    public float cooldown = 3;
    
    private float lastSpawnTime;

    
    void Update()
    {
        if (Time.time - lastSpawnTime > cooldown)
        {
            lastSpawnTime = Time.time;
            GameObject obstacle = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Count)];
            Instantiate(obstacle); //position, rotation, parent
        }
    }
}
