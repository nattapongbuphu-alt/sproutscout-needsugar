using UnityEngine;

public class PlantSpawnerUI : MonoBehaviour
{
    public GameObject plantPrefab; 

    public void SpawnPlant()
    {
        
        Vector3 randomPos = new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f));

        
        Instantiate(plantPrefab, randomPos, Quaternion.identity);
    }
}