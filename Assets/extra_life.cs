using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLife : MonoBehaviour
{
    // Array of points where extra life can appear
    public Transform[] extraLifePoints;

    // Array of prefabs for random nukes to spawn
    public GameObject[] extraLifeRandomNukes;

    // Initial delay before spawning extra lives
    public int startExtraLifeTime = 10;

    // Time interval between consecutive extra life spawns
    public int extraLifeTime = 5;

    // Start is called before the first frame update
    void Start()
    {
        // Invoke the SpawnExtraLife function after a delay of startExtraLifeTime, and then repeatedly after extraLifeTime
        InvokeRepeating("SpawnExtraLife", startExtraLifeTime, extraLifeTime);
    }

    // Function to spawn a random extra life
    void SpawnExtraLife()
    {
        // Ensure there are extra life points and random nukes to select from
        if (extraLifePoints.Length > 0 && extraLifeRandomNukes.Length > 0)
        {
            // Find a random index for the extra life points and random nukes
            int extraLifePointIndex = Random.Range(0, extraLifePoints.Length);
            int extraLifeRandomNukeIndex = Random.Range(0, extraLifeRandomNukes.Length);

            // Instantiate a random nuke prefab at the selected extra life point's position and rotation
            Instantiate(extraLifeRandomNukes[extraLifeRandomNukeIndex], extraLifePoints[extraLifePointIndex].position, extraLifePoints[extraLifePointIndex].rotation);
        }
        else
        {
            Debug.LogWarning("Extra Life points or random nukes array is empty!");
        }
    }
}
