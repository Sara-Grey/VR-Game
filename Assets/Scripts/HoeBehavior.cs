using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoeBehavior : MonoBehaviour
{


    public Collider hoeHead;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hoeHead.enabled = true;
    }
}
