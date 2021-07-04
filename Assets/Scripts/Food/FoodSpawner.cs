using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] GameObject spawnLocation;
    [SerializeField] GameObject[] food = new GameObject[2];

    [SerializeField] float spawnRate = 1f;
    [SerializeField] int foodPerSpawn = 2;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitToSpawn());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator WaitToSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate); // waits x seconds before executing next line of code
            SpawnFood();
        }
    }

    // get random location
    Vector3 RandomLocation()
    {
        Vector3 floorSize = spawnLocation.GetComponent<Collider>().bounds.size;
        float length = (floorSize.z / 2f) - 2.5f;
        float width = (floorSize.x / 2f) - 2.5f;

        float z = Random.Range(-length, length);
        float x = Random.Range(-width, width);

        return new Vector3(x, 0, z);
    }

    // Pick a food prefab and spawn in
    void SpawnFood()
    {
        for (int i = 0; i < foodPerSpawn; i++)
        {
            int index = Random.Range(0, food.Length);
            Instantiate(food[index], RandomLocation(), Quaternion.identity);
        }
    }
}
