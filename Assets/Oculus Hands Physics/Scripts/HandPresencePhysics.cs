using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPresencePhysics : MonoBehaviour
{

    public Transform target;
    private Rigidbody rb;
    public Renderer nonPhysicalHand;
    public float showNonPhysicalHandDistance = 0.05f; // 5 centimeters
    private Collider[] handcolliders;
    private bool grabbing;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        handcolliders = GetComponentsInChildren<Collider>();
        grabbing = false;
    }

    public void EnableHandCollider()
    {
        // Enable collider of item and hand
        foreach (var item in handcolliders)
        {
            item.enabled = true;
        }
    }
    public void DisableHandCollider()
    {
        // Disable collider of item and hand
        foreach (var item in handcolliders)
        {
            item.enabled = false;
        }
        grabbing = true;
    }

 

    public void EnableHandColliderDelay(float delay)
    {

        if (!grabbing)
        {
            Invoke("EnableHandCollider", delay);
        }
 
        // Call the function after some seconds of delay
        
    }


    private void Update()
    {
        // compare distance between physical and non physical hand
        float distance = Vector3.Distance(transform.position, target.position);

        // Render non physical hand 
        if (distance > showNonPhysicalHandDistance)
        {
            nonPhysicalHand.enabled = true;
        }
        // Don't render non physical hand 
        else
        {
            nonPhysicalHand.enabled = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //position
        rb.velocity = (target.position - transform.position) / Time.fixedDeltaTime;

        //rotation
        Quaternion rotationDifference = target.rotation * Quaternion.Inverse(transform.rotation);
        rotationDifference.ToAngleAxis(out float angleInDegree, out Vector3 rotationAxis);

        Vector3 rotationDifferenceInDegree = angleInDegree * rotationAxis;

        rb.angularVelocity = (rotationDifferenceInDegree * Mathf.Deg2Rad / Time.fixedDeltaTime);
    }
}
