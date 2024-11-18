
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class extra_grounded : MonoBehaviour
{
    // Array of points where extra grounded can appear
    public Transform[] extragroundedPoints;

    // Array of prefabs for random nukes to spawn
    public GameObject[] extragroundedRandomNukes;

    // Initial delay before spawning extra lives
    public int startExtragroundedTime = 10;

    // Time interval between consecutive extra grounded spawns
    public int extragroundedTime = 5;

    // Start is called before the first frame update
    void Start()
    {
        // Invoke the SpawnExtragrounded function after a delay of startExtragroundedTime, and then repeatedly after extragroundedTime
        InvokeRepeating("SpawnExtragrounded", startExtragroundedTime, extragroundedTime);
    }

    // Function to spawn a random extra grounded
    void SpawnExtragrounded()
    {
        // Ensure there are extra grounded points and random nukes to select from
        if (extragroundedPoints.Length > 0 && extragroundedRandomNukes.Length > 0)
        {
            // Find a random index for the extra grounded points and random nukes
            int extragroundedPointIndex = Random.Range(0, extragroundedPoints.Length);
            int extragroundedRandomNukeIndex = Random.Range(0, extragroundedRandomNukes.Length);

            // Instantiate a random nuke prefab at the selected extra grounded point's position and rotation
            Instantiate(extragroundedRandomNukes[extragroundedRandomNukeIndex], extragroundedPoints[extragroundedPointIndex].position, extragroundedPoints[extragroundedPointIndex].rotation);
        }
        else
        {
            Debug.LogWarning("Extra grounded points or random nukes array is empty!");
        }
    }
}
