using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class DirtBehavior : MonoBehaviour
{
    public GameObject dirtObject;
    public GameObject seedling;
    public GameObject plant; // Change this to be a seedling (stages: seedling, growing, full grown)
    public Material altmaterial;
    public SeedlingBehavior seedlingBehavior;
    public MeshRenderer DirtRenderer1;
    public MeshRenderer DirtRenderer2;
    public MeshRenderer DirtRenderer3;
   // public Collider watercollider;
    public bool TILLED;
    public bool PLANTED;
    public bool FILLED;
    public int filledCounter;
    // Start is called before the first frame update
    void Start()
    {
        TILLED = false;
        PLANTED = false;
        FILLED = false;
        dirtObject.GetComponent<MeshRenderer>().enabled = false;
        DirtRenderer1.enabled = false;
        DirtRenderer2.enabled = false;
        DirtRenderer3.enabled = false;
        filledCounter = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Destroys Seed upon Collision
        if (other.gameObject.tag == "Seed" && TILLED && !PLANTED)
        {
            Destroy(other.gameObject);
            // Spawn seedling to be in the center of the dirt cube 
            Instantiate(seedling, dirtObject.GetComponent<Renderer>().bounds.center, seedling.transform.rotation);
            PLANTED = true; 
        }
        if (other.gameObject.tag == "DirtDroplet")
        {
            if (filledCounter < 3)
            {
                Destroy(other.gameObject);
                filledCounter++;
                print(filledCounter);
            }
            
            if (filledCounter == 3)
            {
                print("FILLED");
                FILLED = true;
            }
            
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        // Becomes Tilled upon Collision with Hoe Head leaving the cube's collider
        if (other.gameObject.tag == "Hoe" && FILLED)
        {
            
            TILLED = true;
            
        }
    } 

    // Update is called once per frame
    void Update()
    {
        if (FILLED)
        {
            DirtRenderer1.enabled = true;
        }
        if (TILLED)
        {
            DirtRenderer1.enabled = false;
            DirtRenderer2.enabled = true;
        }
        if (PLANTED)
        {
            DirtRenderer2.enabled=false;
            DirtRenderer3.enabled = true;   
        }
    }
}
