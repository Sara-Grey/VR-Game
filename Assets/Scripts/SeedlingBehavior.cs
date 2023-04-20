using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedlingBehavior : MonoBehaviour
{
    public GameObject seedlingObject;
    public GameObject plantObject;
    public GameObject dirtObject; // currently this pulls from the prefab, not the object that actually exists
    public bool WATERED;
    public bool COMMANDED;

    public Transform parent;
    //public DirtBehavior dirtBehavior;

    private void Start()
    {
        WATERED = false;
        COMMANDED = false;
    }
    
    public void Test()
    {
        print("Ayo I'm walkin here");

    }
    public void OnTriggerEnter(Collider other)
    {
    
        if (other.gameObject.tag == "Water" && WATERED == false)
        {
            print("Plant is watered");
            WATERED = true;
            
        }
    }

    private void Update()
    {
        //print("SEEDLING Truth Value: " + dirtObject.GetComponent<DirtBehavior>().REPLACE);
        if (COMMANDED && WATERED)
        {
            print("ENTERED STATEMENT");
            GameObject carrotInstance;
            carrotInstance = Instantiate(plantObject, parent.position, parent.rotation) as GameObject;
            Destroy(seedlingObject);

        }

    }
}
