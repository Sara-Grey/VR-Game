using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class DirtBehavior : MonoBehaviour
{
    public PlantController currentday;
    public TaskChecker taskChecker;
    public SeedlingBehavior seedlingBehavior;

    public GameObject dirtObject;
    public GameObject carrot;
    public GameObject cabbage;
    //public GameObject potato;
    public GameObject carrotSeedling;
    public GameObject cabbageSeedling;
    //public GameObject potatoSeedling;
    public GameObject carrotJuvie;
    private GameObject plantInstance;
    private GameObject carrotInstance;
    private GameObject carrotFinalInstance;
    private GameObject finalCarrotInstance;
    

    public GameObject dirtDroplet;
    public Material altmaterial;
    public MeshRenderer DirtRenderer1;
    public MeshRenderer DirtRenderer2;
    public MeshRenderer DirtRenderer3;

    public bool DEAD;
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
        DEAD = false;
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
        Debug.Log(other.gameObject.name);
        // FILL WITH DIRT 
        if (other.gameObject.tag == "DirtDroplet")
        {
            dirtFillCounter++;
            if (dirtFillCounter <= 3)
            {
                Destroy(other.gameObject);
                print(dirtFillCounter);
            }

            if (dirtFillCounter >= 3)
            {
                print("FILLED");
                FILLED = true;
                taskChecker.checkTask(0);
            }
            /*
            if (dirtFillCounter >= 4)
            {
                DirtRenderer1.enabled = false;
                DirtRenderer2.enabled = false;
                DirtRenderer3.enabled = false;
                WATERED = false;
                TILLED = false;
                PLANTED = false;
                FILLED = false;

            }
            */
        }
        // PLANT SEED 
        if (other.gameObject.tag.EndsWith("Seed") && TILLED && FILLED && !PLANTED)
        {
            seedname = other.gameObject.tag;
            Destroy(other.gameObject);
            // Spawn seedling to be in the center of the dirt cube 
            if (other.gameObject.tag == "CarrotSeed")
            {
                plantInstance = Instantiate(carrotSeedling, dirtObject.GetComponent<Renderer>().bounds.center, carrotSeedling.transform.rotation);
                taskChecker.checkTask(2);
                PLANTED = true;

            }
            if (other.gameObject.tag == "CabbageSeed")
            {
                plantInstance = Instantiate(cabbageSeedling, dirtObject.GetComponent<Renderer>().bounds.center, cabbageSeedling.transform.rotation);
                taskChecker.checkTask(2);
                PLANTED = true;

            }
            /*
            if (other.gameObject.name.StartsWith("Potato"))
            {
                Instantiate(seedling, dirtObject.GetComponent<Renderer>().bounds.center, seedling.transform.rotation);

            }
            */
            dayPlanted = currentday.day;
            // prints once no matter how many duplicates. 
            
        }

        // WATER
        if (other.gameObject.tag == "Water" && TILLED && PLANTED)
        {
            waterFillCounter++;
            if (waterFillCounter < 3)
            {
                Destroy(other.gameObject);
                print(waterFillCounter);
            }

            if (waterFillCounter == 3)
            {
                Destroy(other.gameObject);

                print("WATERED");
                WATERED = true;
                taskChecker.checkTask(3);
            }
            // over watered
            if (waterFillCounter >= 4)
            {
                Destroy(other.gameObject);

                DirtRenderer1.enabled = false;
                DirtRenderer2.enabled = false;
                DirtRenderer3.enabled = true;
                WATERED = false;
                TILLED = false;
                PLANTED = false;
                FILLED = false;
                plantInstance.GetComponent<Renderer>().material = altmaterial;
                print("OverFILLED");
            }
        }

        if (other.gameObject.tag == "Carrot" || other.gameObject.tag == "Cabbage")
        {
            print("READY FOR HARVEST");
        }

    } // END OF ON-TRIGGER-ENTER FUNCTION

    public void Planting()
    {
        // ONE DAY  
        if (currentday.day == (dayPlanted + 1) && PLANTED && WATERED && plantlimit > 0)
        {
            if (seedname == "CabbageSeed" && plantlimit > 0)
            {
                print("made it to cabbage growth");
                GameObject cabbageInstance;
                cabbageInstance = Instantiate(cabbage, dirtObject.GetComponent<Transform>().position, cabbageSeedling.GetComponent<Transform>().rotation) as GameObject;
                Destroy(plantInstance.gameObject);
                plantlimit--;
            }

            
            if  (seedname == "CarrotSeed" && plantJuvilimit >0)
            {
                
                carrotInstance = Instantiate(carrotJuvie, dirtObject.GetComponent<Transform>().position, carrotSeedling.GetComponent<Transform>().rotation) as GameObject;
                Destroy(plantInstance.gameObject);
                plantJuvilimit--;
                WATERED = false;
                waterFillCounter = 0;
            }
            
        }
        // DOS DIAS  
        if (currentday.day > (dayPlanted + 2) && PLANTED && WATERED)
        {
            if(seedname == "CarrotSeed" && plantlimit >0)
            {
        
                finalCarrotInstance = Instantiate(carrot, dirtObject.GetComponent<Transform>().position, carrotJuvie.GetComponent<Transform>().rotation) as GameObject;
                Destroy(carrotInstance.gameObject);
                plantlimit--;

            }
        }
    }
     
    private void OnTriggerExit(Collider other)
    {
        // TILL DIRT
        // Becomes Tilled upon Collision with Hoe Head leaving the cube's collider
        if (other.gameObject.tag == "Hoe" && FILLED && !TILLED)
        {
            TILLED = true;
            taskChecker.checkTask(1);
        }
        if (other.gameObject.tag == "Shovel")
        {
            DirtRenderer1.enabled = false;
            DirtRenderer2.enabled = false;
            DirtRenderer3.enabled = false;
            WATERED = false;
            TILLED = false;
            PLANTED = false;
            FILLED = false;
            dirtFillCounter = 0;
            waterFillCounter = 0;
            dayPlanted = -1;
        }
        if (other.gameObject.tag == "Carrot" || other.gameObject.tag == "Cabbage")
        {
            DirtRenderer1.enabled = false;
            DirtRenderer2.enabled = false;
            DirtRenderer3.enabled = false;
            WATERED = false;
            TILLED = false;
            PLANTED = false;
            FILLED = false;
            dirtFillCounter = 0;
            waterFillCounter = 0;
            dayPlanted = -1;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Planting();
             
        if (FILLED)
        {
            DirtRenderer1.enabled = true;
        }
        
        if (FILLED && TILLED)
        {
            DirtRenderer1.enabled = false;
            DirtRenderer2.enabled = true;
        }
        if (FILLED && TILLED && PLANTED)
        {
            DirtRenderer2.enabled = false;
            DirtRenderer3.enabled = true;
        }

        //print("current value: " + currentday.day);
        //print("DayPlanted + 1: " + (dayPlanted + 1));
    

    }
}
