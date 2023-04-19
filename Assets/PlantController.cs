using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlantController : MonoBehaviour
{
    public int day = 1;
    public TMP_Text dayText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void incrementDay()
    {
        day += 1;
        dayText.text = $"Day {day}";
        Debug.Log(day);
    }
}
