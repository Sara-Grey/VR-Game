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
    //public DirtBehavior dirtBehavior;

    private void Start()
    {
        WATERED = false;
    }
    
    
    public void OnTriggerEnter(Collider other)
    {
    
        if (other.gameObject.tag == "Water" && WATERED == false)
        {
            WATERED = true;
            print("WATERED: " + WATERED);
        }
    }
    public void Test()
    {
        print("ENTERED FUNCTIOn");
        GameObject carrotInstance;
        carrotInstance = Instantiate(plantObject, parent.position, parent.rotation) as GameObject;
        Destroy(seedlingObject);
    }
    public void Update()
    {
        //Test();
    }
}
