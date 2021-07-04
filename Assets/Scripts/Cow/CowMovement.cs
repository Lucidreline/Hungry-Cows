using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowMovement : MonoBehaviour
{
    public float baseSpeed;
    [SerializeField] float speed;
    [SerializeField] float rotationSpeed = 5f;
    [SerializeField] bool userControlled = false;


    // Start is called before the first frame update
    void Start()
    {
        baseSpeed = Random.Range(0.25f, 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (userControlled)
        {
            if (Input.GetAxis("Vertical") > 0)
                this.transform.Translate(Vector3.forward * Time.deltaTime * speed * Input.GetAxis("Vertical"));

            if (Input.GetAxis("Vertical") < 0)
                this.transform.Translate(Vector3.forward * Time.deltaTime * speed * Input.GetAxis("Vertical"));

            if (Input.GetAxis("Horizontal") > 0)
                this.transform.Rotate(Vector3.up * rotationSpeed * Input.GetAxis("Horizontal"));

            if (Input.GetAxis("Horizontal") < 0)
                this.transform.Rotate(Vector3.up * rotationSpeed * Input.GetAxis("Horizontal"));
        }

        MoveTowardsFood();

    }

    void MoveTowardsFood()
    {
        speed = baseSpeed + (GetComponent<Cow>().foodLevel * 0.1f);

        Vector3 foodPos = ClosestFoodLocation();
        transform.position = Vector3.MoveTowards(transform.position, foodPos, speed * Time.deltaTime); // moves towards food

        // rotate towards food
        Vector3 foodDirection = foodPos - transform.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, foodDirection, rotationSpeed * Time.deltaTime, 0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }

    Vector3 ClosestFoodLocation()
    {
        GameObject[] allFood = GameObject.FindGameObjectsWithTag("Food");

        if(allFood.Length > 0)
        {
            GameObject ClosestFood = allFood[0];
            foreach (GameObject food in allFood)
            {                
                if(DistanceFromCow(food) < DistanceFromCow(ClosestFood))
                {
                    ClosestFood = food;
                }
            }
            return ClosestFood.transform.position;
        }

        return this.gameObject.transform.position;
    }

    float DistanceFromCow(GameObject otherObj)
    {
        Vector3 cowPos = this.gameObject.transform.position;
        Vector3 objPos = otherObj.transform.position;

        return Vector3.Distance(cowPos, objPos);
    }
}
