using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_spawn : MonoBehaviour
{
    public Transform[] spawnPoints; // Array of spawn points
    public GameObject[] randomNuke; // Array of nuke prefabs

    public int startSpawnTime = 10; // Initial delay before spawning
    public int spawnTime = 5; // Time interval between spawns

    // Use this for initialization
    void Start()
    {
        // Call the Spawn function after a delay of startSpawnTime and then continue to call after spawnTime
        InvokeRepeating("Spawn", startSpawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        // Any update logic can be added here
    }

    void Spawn()
    {
        // Ensure there are spawn points and random nukes to select from
        if (spawnPoints.Length > 0 && randomNuke.Length > 0)
        {
            // Find a random index for the spawn points and random nukes
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            int randomNukeIndex = Random.Range(0, randomNuke.Length);

            // Create an instance of the random nuke prefab at the selected spawn point's position and rotation
            Instantiate(randomNuke[randomNukeIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        }
        else
        {
            Debug.LogWarning("Spawn points or random nukes array is empty!");
        }
    }
}
