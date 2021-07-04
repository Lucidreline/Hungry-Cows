using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // rotate towards camera
        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
        Vector3 cameraPos = camera.transform.position - transform.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, cameraPos, 5f * Time.deltaTime, 0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
