using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtBehavior : MonoBehaviour
{
    public GameObject dirtObject;
    public Material altmaterial;
    public bool TILLED;

    // Start is called before the first frame update
    void Start()
    {
        TILLED = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Destroys Seed upon Collision
        if (other.gameObject.tag == "Seed" && TILLED)
        {
            Destroy(other.gameObject);
        }

        // Becomes Tilled upon Collision
        if (other.gameObject.tag == "Hoe")
        {
            dirtObject.GetComponent<MeshRenderer>().material = altmaterial;
            TILLED =true;
            // TEST THIS BOOLEAN WHEN YOU GET BACK


        }
    }




    

    // Update is called once per frame
    void Update()
    {
        
    }
}
