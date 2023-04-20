using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class DirtBagBehavior : MonoBehaviour
{
    public GameObject dirtspeck;
    public Transform frontOfDirtBag;
   
    public void Dirt(bool value)
    {
        if (value)
        {
            GameObject dripping = Instantiate(dirtspeck, frontOfDirtBag.position, frontOfDirtBag.rotation);
        }
    }
    /*
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Dirt" )
        {
            Destroy(dirtspeck);
        }
    }
    */
    public void Update()
    {
        
    }
}
