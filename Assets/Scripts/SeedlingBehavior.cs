using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedlingBehavior : MonoBehaviour
{
    public GameObject seedlingObject;
    public GameObject plantObject;
    public GameObject dirtObject; // currently this pulls from the prefab, not the object that actually exists
    public bool WATERED;
    public Transform parent;

    private void Start()
    {
        WATERED = false;
    }
    public bool Test()
    {
        if (WATERED)
        {
            print("Test Returned True");
            return true;
        }
        else
        {
            return false;
        }
        
        
    }
    public void OnTriggerEnter(Collider other)
    {
    
        if (other.gameObject.tag == "Water" && WATERED == false)
        {
            print("Plant is watered");
            
            WATERED = true;
            GameObject carrotInstance;
            carrotInstance = Instantiate(plantObject, parent.position, parent.rotation) as GameObject;
            Destroy(seedlingObject);
        }
    }

    private void Update()
    {
        Test();
        
    }
}
