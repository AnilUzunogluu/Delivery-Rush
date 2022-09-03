using System.Linq;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    private System.Random random = new System.Random();
    private Vector3[] spawnLocations;
    private GameObject objectToSpawn;
    private bool ifDestroyed;
    private float timerToDestroy;
    private int arrayLength;
public SpawnManager(Vector3[] spawnLocations, GameObject toSpawn, bool isDestroyed, float timer, int objectCount)
{
    this.spawnLocations = spawnLocations;
    objectToSpawn = toSpawn;
    ifDestroyed = isDestroyed;
    timerToDestroy = timer;
    arrayLength = objectCount;
}

public void Spawn()
{
    GameObject[] objects = new GameObject[arrayLength];
        // There is a problem with the boost spawn locations where sometimes random.next can select the same place for boosts to spawn at.  
    for (int j = 0; j < arrayLength; j++)
    {
        int i = random.Next(0, spawnLocations.Length);
        objects[j] = Instantiate(objectToSpawn, spawnLocations[i], quaternion.identity);
    }
    if (ifDestroyed)
    {
        for (int i = 0; i < arrayLength; i++)
        {
                Destroy(objects[i], random.Next(3, (int) timerToDestroy));
        }
    }
    
    
    
}
}
