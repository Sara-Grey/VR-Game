using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WateringCanBehavior : MonoBehaviour
{
    public float speed = 1f;
    public GameObject waterDropletObject;
    public Transform frontOfWateringCan;
    public XRGrabInteractable interactable;

    public void Water()
    {
        
       
        {
            GameObject dripping = Instantiate(waterDropletObject, frontOfWateringCan.position, frontOfWateringCan.rotation);
            Destroy(dripping, 2f);
        }
        
    }
}
