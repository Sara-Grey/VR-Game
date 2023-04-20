using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class DirtBehavior : MonoBehaviour
{
    public GameObject dirtObject;
    public SeedlingBehavior seedlingBehavior;
    public GameObject seedling;


    public GameObject plant; // Change this to be a seedling (stages: seedling, growing, full grown)
    public Material altmaterial;
    
    public MeshRenderer DirtRenderer1;
    public MeshRenderer DirtRenderer2;
    public MeshRenderer DirtRenderer3;
   // public Collider watercollider;
    public bool TILLED;
    public bool PLANTED;
    public bool FILLED;
    public int filledCounter;

    public PlantController currentday;
    public int dayPlanted;
    public bool REPLACE;

    // Start is called before the first frame update
    void Start()
    {
        seedlingBehavior = seedling.GetComponent<SeedlingBehavior>();
        REPLACE = false;
        TILLED = false;
        PLANTED = false;
        FILLED = false;
        dirtObject.GetComponent<MeshRenderer>().enabled = false;
        DirtRenderer1.enabled = false;
        DirtRenderer2.enabled = false;
        DirtRenderer3.enabled = false;
        filledCounter = 0;
        dayPlanted = -1;
    }

    private void OnTriggerEnter(Collider other)
    {
        // PLANT SEED 
        if (other.gameObject.tag == "Seed" && TILLED && !PLANTED)
        {
            Destroy(other.gameObject);
            // Spawn seedling to be in the center of the dirt cube 
            Instantiate(seedling, dirtObject.GetComponent<Renderer>().bounds.center, seedling.transform.rotation);
            PLANTED = true;
            dayPlanted = currentday.day;
            // prints once no matter how many duplicates. 
            
        }

        if (other.gameObject.tag == "Water" && TILLED && PLANTED)
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
        
        // FILL WITH DIRT 
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
    // TILL DIRT 
    private void OnTriggerExit(Collider other)
    {
        // Becomes Tilled upon Collision with Hoe Head leaving the cube's collider
        if (other.gameObject.tag == "Hoe" && FILLED)
        {
            
            TILLED = true;
            
        }
        if (other.gameObject.tag == "Shovel" && FILLED)
        {
            DirtRenderer1.enabled = false;
            DirtRenderer2.enabled = false;
            DirtRenderer3.enabled = false;
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        
        /*
        if (seedling.GetComponent<SeedlingBehavior>() != null)
        {
            print("ABLE TO FIND IT ");
        }
        */
        //print(seedling.GetComponent<SeedlingBehavior>().WATERED);        
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
            DirtRenderer2.enabled = false;
            DirtRenderer3.enabled = true;
        }


        // Add more tags for more seeds
        // Then make it so if tag was this do this 
        // More booleans? 
        if (currentday.day == (dayPlanted + 1) && PLANTED)
        {

            seedlingBehavior.Test();
            REPLACE = true;
            print("MADE IT ");
            //print("DIRT Truth Value: " + REPLACE);
             //print("current value: " + currentday.day);
             //print("DayPlanted + 1: " + (dayPlanted + 1));
        }
        /*
         if (currentday.day > (dayPlanted + 1) && PLANTED)
         {
             REPLACE = true;
             print("overshot ");
             print("current value: " + currentday.day);
             print("DayPlanted + 1: " + (dayPlanted + 1));
         }
         if (currentday.day < (dayPlanted + 1) && PLANTED)
         {
             REPLACE = true;
             print("undershot ");
             print("current value: " + currentday.day);
             print("DayPlanted + 1: " + (dayPlanted + 1));
         }
            */

    }
}
