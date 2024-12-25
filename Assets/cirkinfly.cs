using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cirkinfly : MonoBehaviour
{
    public Transform[] spawnPoints; // Array of spawn points
    public GameObject[] randomNuke; // Array of nuke prefabs

    public int startSpawnTimeMin = 20; // Minimum value for startSpawnTime
    public int startSpawnTimeMax = 30; // Maximum value for startSpawnTime
    public int spawnTimeMin = 25; // Minimum value for spawnTime
    public int spawnTimeMax = 35; // Maximum value for spawnTime

    private int startSpawnTime; // Final randomly selected startSpawnTime
    private int spawnTime; // Final randomly selected spawnTime

    // Use this for initialization
    void Start()
    {
        // Generate random values for startSpawnTime and spawnTime
        startSpawnTime = Random.Range(startSpawnTimeMin, startSpawnTimeMax);
        spawnTime = Random.Range(spawnTimeMin, spawnTimeMax);

        // Call the Spawn function after a delay of startSpawnTime and then continue to call after spawnTime
        InvokeRepeating("Spawn", startSpawnTime, spawnTime);
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
