using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelBehavior : MonoBehaviour
{


    public Collider shovelHead;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Seedling" || other.tag == "Carrot" ||  other.tag == "Cabbage" || other.tag == "DirtDroplet")
        {
            Destroy(other.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        shovelHead.enabled = true;
    }
}
