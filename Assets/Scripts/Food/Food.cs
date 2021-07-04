using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider otherObj)
    {
        if(otherObj.gameObject.tag == "Cow")
        {
            Cow cow = otherObj.GetComponent<Cow>();
            cow.IncreaseFoodLevel();
            Destroy(this.gameObject);
        }
    }
}
