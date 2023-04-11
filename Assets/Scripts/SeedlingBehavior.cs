using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedlingBehavior : MonoBehaviour
{
    public GameObject seedlingObject;
    public GameObject plantObject;
    public GameObject dirtObject;

    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Water")
        {
            
            Destroy(seedlingObject);
            Instantiate(plantObject);
            plantObject.transform.position = dirtObject.GetComponent<Renderer>().bounds.center;
            
        }
    }
}
