using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator TwoSecondDelay()
    {
        print("delaying....");
        yield return new WaitForSeconds(2);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DirtDroplet")
        {
            StartCoroutine(TwoSecondDelay());
            print(" done");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
