using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DirtBehavior : MonoBehaviour
{
    public GameObject dirtObject;
    public GameObject seedling;
    public GameObject plant; // Change this to be a seedling (stages: seedling, growing, full grown)
    public Material altmaterial;
    public SeedlingBehavior seedlingBehavior;
   // public Collider watercollider;
    public bool TILLED;
    public bool FILLED;
    // Start is called before the first frame update
    void Start()
    {
        TILLED = false;
        FILLED = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Destroys Seed upon Collision
        if (other.gameObject.tag == "Seed" && TILLED && !FILLED)
        {
            Destroy(other.gameObject);
            // Spawn seedling to be in the center of the dirt cube 
            Instantiate(seedling, dirtObject.GetComponent<Renderer>().bounds.center, seedling.transform.rotation);
            FILLED = true; 
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        // Becomes Tilled upon Collision with Hoe Head leaving the cube's collider
        if (other.gameObject.tag == "Hoe")
        {
            dirtObject.GetComponent<MeshRenderer>().material = altmaterial;
            TILLED = true;
        }
    } 

    // Update is called once per frame
    void Update()
    {
     
    }
}
