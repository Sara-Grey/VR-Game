using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class DirtBehavior : MonoBehaviour
{
    public PlantController currentday;
    public SeedlingBehavior seedlingBehavior;

    public GameObject dirtObject;
    public GameObject carrot;
    public GameObject cabbage;
    //public GameObject potato;
    public GameObject carrotSeedling;
    public GameObject cabbageSeedling;
    //public GameObject potatoSeedling;
    public GameObject carrotJuvie;

    public GameObject plant; // Change this to be a seedling (stages: seedling, growing, full grown)
    
    public Material altmaterial;
    public MeshRenderer DirtRenderer1;
    public MeshRenderer DirtRenderer2;
    public MeshRenderer DirtRenderer3;

    public bool TILLED;
    public bool PLANTED;
    public bool FILLED; 
    public int dirtFillCounter;
    public int waterFillCounter;
    private int plantlimit;
    private int plantJuvilimit;
    private string seedname;
    public int dayPlanted;
    public bool WATERED;
    // Start is called before the first frame update
    void Start()
    {
        plantlimit = 1;
        plantJuvilimit = 1;
        //seedlingBehavior = seedling.GetComponent<SeedlingBehavior>();
        TILLED = false;
        PLANTED = false;
        FILLED = false;
        WATERED = false;
        dirtObject.GetComponent<MeshRenderer>().enabled = false;
        DirtRenderer1.enabled = false;
        DirtRenderer2.enabled = false;
        DirtRenderer3.enabled = false;
        dirtFillCounter = 0;
        waterFillCounter = 0;
        dayPlanted = -1;
    }

    private void OnTriggerEnter(Collider other)
    {
        // FILL WITH DIRT 
        if (other.gameObject.tag == "DirtDroplet")
        {
            if (dirtFillCounter < 3)
            {
                Destroy(other.gameObject);
                dirtFillCounter++;
                print(dirtFillCounter);
            }

            if (dirtFillCounter == 3)
            {
                print("FILLED");
                FILLED = true;
            }
        }
        // PLANT SEED 
        if (other.gameObject.name.EndsWith("Seed") && TILLED && !PLANTED)
        {
            seedname = other.gameObject.name;
            Destroy(other.gameObject);
            // Spawn seedling to be in the center of the dirt cube 
            if (other.gameObject.name.StartsWith("Carrot"))
            {
                Instantiate(carrotSeedling, dirtObject.GetComponent<Renderer>().bounds.center, carrotSeedling.transform.rotation);

            }
            if (other.gameObject.name.StartsWith("Cabbage"))
            {
                Instantiate(cabbageSeedling, dirtObject.GetComponent<Renderer>().bounds.center, cabbageSeedling.transform.rotation);

            }
            /*
            if (other.gameObject.name.StartsWith("Potato"))
            {
                Instantiate(seedling, dirtObject.GetComponent<Renderer>().bounds.center, seedling.transform.rotation);

            }
            */
            PLANTED = true;
            dayPlanted = currentday.day;
            // prints once no matter how many duplicates. 
            
        }

        // WATER
        if (other.gameObject.tag == "Water" && TILLED && PLANTED)
        {
            if (waterFillCounter < 3)
            {
                Destroy(other.gameObject);
                waterFillCounter++;
                print(waterFillCounter);
            }

            if (waterFillCounter == 3)
            {
                print("WATERED");
                WATERED = true;
            }
        }
        
        
        
    }

    public void Planting()
    {
        
        if (currentday.day == (dayPlanted + 1) && PLANTED && WATERED)
        {
            if (seedname == "CabbageSeed" && plantlimit > 0)
            {
                GameObject cabbageInstance;
                cabbageInstance = Instantiate(cabbage, cabbageSeedling.GetComponent<Transform>().position, cabbageSeedling.GetComponent<Transform>().rotation) as GameObject;
                Destroy(cabbageSeedling);
                plantlimit--;
            }

            if (seedname == "CarrotSeed" && plantJuvilimit >0)
            {
                GameObject carrotInstance;
                carrotInstance = Instantiate(carrotJuvie, carrotSeedling.GetComponent<Transform>().position, carrotSeedling.GetComponent<Transform>().rotation) as GameObject;
                Destroy(carrotSeedling);
                plantJuvilimit--;
            }

        }
        if (currentday.day == (dayPlanted + 2) && PLANTED && WATERED)
        {
            if(seedname == "CarrotSeed" && plantlimit >0)
            {
                GameObject carrotInstance;
                carrotInstance = Instantiate(carrot, carrotJuvie.GetComponent<Transform>().position, carrotJuvie.GetComponent<Transform>().rotation) as GameObject;
                Destroy(carrotSeedling);
                plantlimit--;
            }
        }
    }
     
    private void OnTriggerExit(Collider other)
    {
        // TILL DIRT
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
        Planting();
             
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

        //print("current value: " + currentday.day);
        //print("DayPlanted + 1: " + (dayPlanted + 1));
    

    }
}
