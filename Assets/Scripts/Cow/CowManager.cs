using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowManager : MonoBehaviour
{
    [SerializeField] GameObject offspringSpawnPoint;
    [SerializeField] GameObject cowPrefab;
    // Start is called before the first frame update
    void Start()
    {
        // give all cows a family id
        GameObject[] allCows = GameObject.FindGameObjectsWithTag("Cow");
        int counter = 1;
        foreach(GameObject cow in allCows)
        {
            cow.GetComponent<Cow>().familyID = counter;
            counter++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnOffspring(GameObject motherCow)
    {
        Cow mother = motherCow.GetComponent<Cow>();

        GameObject offspringObj = Instantiate(cowPrefab, offspringSpawnPoint.transform.position, Quaternion.identity);
        Cow offspring = offspringObj.GetComponent<Cow>();

        offspring.familyID = mother.familyID;
        offspringObj.GetComponent<CowMovement>().baseSpeed = motherCow.GetComponent<CowMovement>().baseSpeed + Random.Range(-0.1f, 0.1f);
        mother.foodLevel -= 3;
    }
}
