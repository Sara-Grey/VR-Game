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
    public int waterLimit = 5;
    public int dropsRemaining;
    public Renderer waterRenderer;
    public void Start()
    {
        waterLimit = 10; // This should be 5 but for testing purposes I changed it - <3 Colin
        dropsRemaining = waterLimit;
    }

    public void Water()
    {
        if (dropsRemaining > 0) 
        {
            GameObject dripping = Instantiate(waterDropletObject, frontOfWateringCan.position, frontOfWateringCan.rotation);
            Destroy(dripping, 1f);
            dropsRemaining--;
        }
        
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Well")
        {
            print("Refilled");
            dropsRemaining = 5;
        }
    }

    public void Update()
    {
        if (dropsRemaining <= 0)
        {
            waterRenderer.enabled = false;
        }
        if (dropsRemaining > 0)
        {
            waterRenderer.enabled = true;
        }
    }
}
